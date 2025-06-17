using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite; // Изменение: System.Data.SQLite
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration; // Для ConfigurationManager

namespace Owen
{
    public partial class Import : Form
    {
        private string currentTableName;
        private readonly string sqliteConnectionString = ConfigurationManager.ConnectionStrings["LiteConnectionString"].ConnectionString;

        public Import()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            string filePath = TxtFilePath.Text.Trim();
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Файл PGN не найден или путь не указан.");
                return;
            }

            currentTableName = TxtTableName.Text.Trim();
            if (string.IsNullOrWhiteSpace(currentTableName))
            {
                MessageBox.Show("Имя таблицы не может быть пустым.");
                return;
            }

            PrgImport.Visible = true;
            PrgImport.Style = ProgressBarStyle.Marquee;
            LblStatus.Visible = true;
            LblStatus.Text = "Импорт...";
            BtnImport.Enabled = false;

            backgroundWorker.RunWorkerAsync(filePath);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument as string;
            ImportPgnFile(filePath);
        }

        private void ImportPgnFile(string filePath)
        {
            using (var conn = new SQLiteConnection(sqliteConnectionString)) // Изменение: SQLiteConnection
            {
                conn.Open();
                CreateNewTable(conn, currentTableName);

                int gameCount = 0;
                var gameLines = new List<string>();
                int state = 0; // 0: waiting for game, 1: collecting tags, 2: collecting moves

                int lineNumber = 0;
                foreach (string rawLine in File.ReadLines(filePath))
                {
                    lineNumber++;
                    string line = rawLine.Trim();

                    if (state == 0) // Waiting for game start
                    {
                        if (line.StartsWith("["))
                        {
                            gameLines.Add(line);
                            state = 1; // Transition to tag collection
                        }
                    }
                    else if (state == 1) // Collecting tags
                    {
                        if (line.StartsWith("["))
                        {
                            gameLines.Add(line);
                        }
                        else if (string.IsNullOrEmpty(line))
                        {
                            state = 2; // Empty line after tags -> moves
                        }
                        else
                        {
                            // Unexpected data (not a tag and not an empty line)
                            gameLines.Add(line);
                        }
                    }
                    else if (state == 2) // Collecting moves
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            // Empty line means end of game
                            if (gameLines.Count > 0)
                            {
                                ProcessGame(gameLines, conn, currentTableName, lineNumber);
                                gameCount++;
                                gameLines.Clear();
                                state = 0; // Reset for next game
                                if (gameCount % 100 == 0)
                                {
                                    backgroundWorker.ReportProgress(0, $"Обработано игр: {gameCount}");
                                }
                            }
                        }
                        else
                        {
                            gameLines.Add(line);
                        }
                    }
                }

                // Process last game (if no trailing empty line)
                if (state == 2 && gameLines.Count > 0)
                {
                    ProcessGame(gameLines, conn, currentTableName, lineNumber);
                    gameCount++;
                }

                backgroundWorker.ReportProgress(0, $"Всего обработано игр: {gameCount}");
            }
        }

        private void ProcessGame(List<string> gameLines, SQLiteConnection conn, string tableName, int lineNumber) // Изменение: SQLiteConnection
        {
            try
            {
                var tags = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                var movesBuilder = new StringBuilder();

                foreach (string line in gameLines)
                {
                    if (line.StartsWith("["))
                    {
                        Match m = Regex.Match(line, @"\[(\w+)\s+""([^""]*)""\]");

                        if (m.Success)
                        {
                            tags[m.Groups[1].Value] = m.Groups[2].Value;
                        }
                    }
                    else
                    {
                        movesBuilder.Append(line).Append(' ');
                    }
                }

                string cleanMoves = SimplifyMoves(movesBuilder.ToString().Trim());

                string insertSql = $@"
                    INSERT INTO {tableName} 
                    (Event, Site, Date, Round, White, Black, Result, 
                     WhiteElo, BlackElo, ECO, MovesSAN, ImportDate)
                    VALUES 
                    (@Event, @Site, @Date, @Round, @White, @Black, @Result, 
                     @WhiteElo, @BlackElo, @ECO, @MovesSAN, CURRENT_TIMESTAMP)"; // Изменение: CURRENT_TIMESTAMP

                using (var cmd = new SQLiteCommand(insertSql, conn)) // Изменение: SQLiteCommand
                {
                    AddParameter(cmd, "@Event", GetTagValue(tags, "Event"));
                    AddParameter(cmd, "@Site", GetTagValue(tags, "Site"));
                    AddParameter(cmd, "@Date", GetTagValue(tags, "Date"));
                    AddParameter(cmd, "@Round", GetTagValue(tags, "Round"));
                    AddParameter(cmd, "@White", GetTagValue(tags, "White"));
                    AddParameter(cmd, "@Black", GetTagValue(tags, "Black"));
                    AddParameter(cmd, "@Result", GetTagValue(tags, "Result"));
                    AddParameter(cmd, "@ECO", GetTagValue(tags, "ECO"));
                    AddParameter(cmd, "@MovesSAN", cleanMoves);
                    AddParameter(cmd, "@WhiteElo", ParseElo(GetTagValue(tags, "WhiteElo"))); // Изменение: nullable int
                    AddParameter(cmd, "@BlackElo", ParseElo(GetTagValue(tags, "BlackElo"))); // Изменение: nullable int

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine($"ОШИБКА В СТРОКЕ {lineNumber}:");
                error.AppendLine(ex.Message);
                error.AppendLine("Содержимое игры:");
                error.AppendLine(string.Join(Environment.NewLine, gameLines));
                backgroundWorker.ReportProgress(0, error.ToString());
            }
        }

        // Изменение: для SQLiteCommand
        private void AddParameter(SQLiteCommand cmd, string name, object value)
        {
            if (value == null)
                cmd.Parameters.AddWithValue(name, DBNull.Value);
            else
                cmd.Parameters.AddWithValue(name, value);
        }

        // Изменение: для nullable int
        private void AddParameter(SQLiteCommand cmd, string name, int? value)
        {
            if (value.HasValue)
                cmd.Parameters.AddWithValue(name, value.Value);
            else
                cmd.Parameters.AddWithValue(name, DBNull.Value);
        }

        private string SimplifyMoves(string movesText)
        {
            StringBuilder clean = new StringBuilder();
            bool inComment = false;
            bool inVariation = false;
            foreach (char c in movesText)
            {
                if (c == '{') inComment = true;
                else if (c == '}') inComment = false;
                else if (c == '(') inVariation = true;
                else if (c == ')') inVariation = false;
                else if (!inComment && !inVariation) clean.Append(c);
            }

            string result = clean.ToString();
            result = Regex.Replace(result, @"(1\-0|0\-1|1\/2\-1\/2|\*)\s*$", "");
            result = Regex.Replace(result, @"\s+", " ").Trim();
            return result;
        }

        // Изменение: возвращает nullable int
        private int? ParseElo(string eloValue)
        {
            if (int.TryParse(eloValue, out int elo))
            {
                return elo;
            }
            return null; // Изменение: null вместо DBNull.Value
        }

        private string GetTagValue(Dictionary<string, string> tags, string key)
        {
            if (tags.TryGetValue(key, out string value))
            {
                return value;
            }
            return null;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                LblStatus.Text = e.UserState.ToString();
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrgImport.Style = ProgressBarStyle.Blocks;
            PrgImport.Value = 100;
            BtnImport.Enabled = true;

            if (e.Error != null)
            {
                LblStatus.Text = "Ошибка: " + e.Error.Message;
            }
            else
            {
                LblStatus.Text = "Импорт завершен успешно!";
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PGN files (*.pgn)|*.pgn|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TxtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void CreateNewTable(SQLiteConnection conn, string tableName) // Изменение: SQLiteConnection
        {
            string createTableSql = $@"
                CREATE TABLE IF NOT EXISTS {tableName} (
                    GameID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Event TEXT,
                    Site TEXT,
                    Date TEXT,
                    Round TEXT,
                    White TEXT,
                    Black TEXT,
                    Result TEXT,
                    WhiteElo INTEGER,
                    BlackElo INTEGER,
                    ECO TEXT,
                    MovesSAN TEXT,
                    ImportDate DATETIME DEFAULT CURRENT_TIMESTAMP
                );
                CREATE INDEX IF NOT EXISTS IX_{tableName}_Event ON {tableName}(Event);
                CREATE INDEX IF NOT EXISTS IX_{tableName}_WhiteBlack ON {tableName}(White, Black);";

            using (var cmd = new SQLiteCommand(createTableSql, conn)) // Изменение: SQLiteCommand
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void Import_Load(object sender, EventArgs e)
        {
            TxtTableName.Text = $"Games_{DateTime.Now:yyyyMMdd_HHmmss}";
        }

        private void toolStripBackButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите вернуться?", "Возврат на форму выбора", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Selection frm = new Selection();
                frm.Show();
                this.Hide();
            }
        }
    }
}