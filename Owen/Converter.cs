using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SQLite; // Изменение: System.Data.SQLite
using System.Configuration; // Для ConfigurationManager
namespace Owen
{
    public partial class Converter : Form
    {
        private ChessGameManager _gameManager;
        private List<(string WhiteMove, string BlackMove)> _allMoves;
        // Изменение: Строка подключения из app.config
        private readonly string sqliteConnectionString = ConfigurationManager.ConnectionStrings["LiteConnectionString"].ConnectionString;
        public Converter()
        {
            InitializeComponent();
            LoadTables();
        }
        private void Back_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите вернуться?", "Возврат на форму выбора", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Selection frm = new Selection();
                frm.Show();
                this.Hide();
            }
        }
        private List<(string WhiteMove, string BlackMove)> ParseGame(string pgnText)
        {
            var moves = new List<(string, string)>();
            StringBuilder cleanPgn = new StringBuilder();
            bool inComment = false;
            foreach (char c in pgnText)
            {
                if (c == '{') inComment = true;
                if (!inComment) cleanPgn.Append(c);
                if (c == '}') inComment = false;
            }
            string cleanText = cleanPgn.ToString()
                .Replace("1-0", "").Replace("0-1", "").Replace("1/2-1/2", "")
                .Replace("\r", " ").Replace("\n", " ").Replace("  ", " ");
            // Improved regex for move parsing (more robust against multiple spaces, etc.)
            var moveMatches = Regex.Matches(cleanText, @"(\d+)\.\s*(\S+?)(?:\s+(\S+?))?(?=\s*\d+\.|\s*$|\s*\{|\s*$)"); // Added lookahead for comments/variations
            foreach (Match match in moveMatches)
            {
                string whiteMove = match.Groups[2].Value;
                string blackMove = match.Groups[3].Success ? match.Groups[3].Value : null;
                whiteMove = Regex.Replace(whiteMove, @"[\?!+#]+$", "");
                blackMove = blackMove != null ? Regex.Replace(blackMove, @"[\?!+#]+$", "") : null;
                moves.Add((whiteMove, blackMove));
            }
            return moves;
        }
        private void DisplayMoves()
        {
            dgvMoves.Rows.Clear();
            for (int i = 0; i < _allMoves.Count; i++)
            {
                int moveNumber = i + 1;
                string whiteMove = _allMoves[i].WhiteMove;
                string blackMove = _allMoves[i].BlackMove ?? "";
                dgvMoves.Rows.Add(moveNumber, whiteMove, blackMove);
            }
            NudFromMove.Minimum = 1;
            NudFromMove.Value = 1;
            NudFromMove.Maximum = _allMoves.Count;
            NudToMove.Maximum = _allMoves.Count;
            NudToMove.Value = _allMoves.Count;
        }
        // ----------- УПРАВЛЕНИЕ ------------------
        private int _currentMoveIndex = 0;
        private void dgvMoves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;
            // Убедимся, что клик по реальному ходу, а не по пустому месту
            if (e.ColumnIndex == 2 && string.IsNullOrEmpty(dgvMoves[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                // Если клик по пустой ячейке для черных, то это ход белых
                _currentMoveIndex = e.RowIndex * 2 + 1; // Ход белых
            }
            else
            {
                _currentMoveIndex = e.RowIndex * 2 + (e.ColumnIndex - 1) + 1; // 0-based index for move pair, then 1 or 2 for white/black
            }
            _gameManager.GoToMove(_currentMoveIndex);
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_gameManager == null) return;
            if (_currentMoveIndex > 0)
            {
                _currentMoveIndex--;
                _gameManager.GoToMove(_currentMoveIndex);
                UpdateMoveSelection();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_gameManager == null) return;
            int totalMoves = _allMoves.Count * 2;
            // Adjust for games ending on white's move
            if (_allMoves.Any() && string.IsNullOrEmpty(_allMoves.Last().BlackMove))
            {
                totalMoves--;
            }
            if (_currentMoveIndex < totalMoves)
            {
                _currentMoveIndex++;
                _gameManager.GoToMove(_currentMoveIndex);
                UpdateMoveSelection();
            }
        }
        private void BtnMoveFirst_Click(object sender, EventArgs e)
        {
            if (_gameManager == null) return;
            _currentMoveIndex = 0;
            _gameManager.GoToMove(_currentMoveIndex);
            UpdateMoveSelection();
        }
        private void BtnMoveLast_Click(object sender, EventArgs e)
        {
            if (_gameManager == null) return;
            int lastMoveIndex = _allMoves.Count * 2;
            if (_allMoves.Any() && string.IsNullOrEmpty(_allMoves.Last().BlackMove))
            {
                lastMoveIndex--; // Game ended on white's move
            }
            _currentMoveIndex = lastMoveIndex;
            _gameManager.GoToMove(_currentMoveIndex);
            UpdateMoveSelection();
        }
        private void UpdateMoveSelection()
        {
            try
            {
                int row = (_currentMoveIndex - 1) / 2;
                int col = (_currentMoveIndex - 1) % 2 + 1;

                // Проверяем, что индексы находятся в пределах допустимых значений
                if (row >= 0 && row < dgvMoves.Rows.Count && col >= 1 && col <= 2)
                {
                    dgvMoves.ClearSelection();
                    dgvMoves.Rows[row].Cells[col].Selected = true;
                    dgvMoves.FirstDisplayedScrollingRowIndex = row; // Прокрутка к выбранной строке
                }
            }
            catch { /* Игнорируем ошибки, если DGV не готова или индекс вне диапазона */ }
        }
        // --------------------- ПОЛУЧЕНИЕ ДАННЫХ ----------------
        private void LoadTables()
        {
            var tables = GetDatabaseTables(sqliteConnectionString);
            comboBoxTables.DataSource = tables;
        }
        // Изменение: для SQLite
        public List<string> GetDatabaseTables(string connectionString)
        {
            var tables = new List<string>();
            // В SQLite нет INFORMATION_SCHEMA.TABLES, используем sqlite_master
            var excludedTables = new HashSet<string> {
                "sqlite_sequence", "sqlite_master", // Системные таблицы SQLite
                "auth", "Class_schedule", "OpeningRatings", "Openings",
                "Students", "Teachers", "TheoryMaterials", "Tournaments", "Training_programs"
            };
            using (var connection = new SQLiteConnection(connectionString)) // Изменение: SQLiteConnection
            {
                connection.Open();
                string query = "SELECT name FROM sqlite_master WHERE type='table'"; // Изменение: запрос для SQLite
                using (var command = new SQLiteCommand(query, connection)) // Изменение: SQLiteCommand
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tableName = reader.GetString(0);
                        if (!excludedTables.Contains(tableName))
                        {
                            tables.Add(tableName);
                        }
                    }
                }
            }
            return tables;
        }
        private int iffirst = 0; // Флаг для первого запуска (или первого выбора таблицы)
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedItem != null && iffirst > 0)
            {
                string selectedTable = comboBoxTables.SelectedItem.ToString();
                // Изменение: Теперь TableDataForm должна работать с SQLite
                var tableForm = new TableDataForm(selectedTable, sqliteConnectionString);
                tableForm.RowSelected += (selectedRow) =>
                {
                    // Логика для отображения данных из выбранной строки
                    // Предполагается, что столбцы в таблице Games_YYYYMMDD_HHMMSS имеют стандартные названия
                    // и ваш PGN импорт работает корректно.
                    // Очищаем lbls перед заполнением
                    EventLbl.Text = SiteLbl.Text = DateLbl.Text = RoundLbl.Text = WhiteLbl.Text = BlackLbl.Text =
                    ResultLbl.Text = WhiteEloLbl.Text = BlackEloLbl.Text = ECOLbl.Text = "";
                    txtGame.Text = ""; // Очищаем поле с ходами
                    MainInfoPanel.Visible = true; // Сброс видимости панели
                    RoundLbl.Visible = WhiteLbl.Visible = BlackLbl.Visible = ResultLbl.Visible =
                    WhiteEloLbl.Visible = BlackEloLbl.Visible = ECOLbl.Visible = true;
                    // Упрощенная логика на основе количества столбцов
                    // Если у вас 4 столбца - это для OpeningRatings или Openings (примера)
                    if (selectedRow.Table.Columns.Count == 4)
                    {
                        try
                        {
                            EventLbl.Text = "Код варианта: " + selectedRow["GameID"].ToString(); // Предполагаем GameID
                            SiteLbl.Text = "Код дебюта: " + selectedRow["Event"].ToString(); // Предполагаем Event
                            DateLbl.Text = "Название варианта: " + selectedRow["Site"].ToString(); // Предполагаем Site

                            RoundLbl.Visible = BlackLbl.Visible = ResultLbl.Visible =
                            WhiteEloLbl.Visible = BlackEloLbl.Visible = ECOLbl.Visible = false;
                            MainInfoPanel.Visible = false; // Или что-то другое, если это панель с подробностями игры
                            // Возможно, здесь MovesSAN не нужен или находится в другом столбце
                            txtGame.Text = selectedRow["MovesSAN"]?.ToString() ?? "";
                            if (string.IsNullOrEmpty(txtGame.Text))
                            {
                                MessageBox.Show("Не найдено ходов для данной записи.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show("Ошибка чтения данных из 4-колоночной таблицы: " + ex.Message); }
                    }
                    else // Если это типичная таблица из PGN импорта
                    {
                        try
                        {
                            // Используем GetValueOrDefault для безопасного извлечения данных
                            EventLbl.Text = "Мероприятие: " + GetValueOrDefault(selectedRow, "Event");
                            SiteLbl.Text = "Место: " + GetValueOrDefault(selectedRow, "Site");
                            DateLbl.Text = "Дата: " + GetValueOrDefault(selectedRow, "Date");
                            RoundLbl.Text = "Раунд: " + GetValueOrDefault(selectedRow, "Round");
                            WhiteLbl.Text = "Белый: " + GetValueOrDefault(selectedRow, "White");
                            BlackLbl.Text = "Черный: " + GetValueOrDefault(selectedRow, "Black");
                            ResultLbl.Text = "Результат: " + GetValueOrDefault(selectedRow, "Result");
                            WhiteEloLbl.Text = "Эло белых: " + GetValueOrDefault(selectedRow, "WhiteElo");
                            BlackEloLbl.Text = "Это черных: " + GetValueOrDefault(selectedRow, "BlackElo");
                            ECOLbl.Text = "Код ECO: " + GetValueOrDefault(selectedRow, "ECO");
                            txtGame.Text = GetValueOrDefault(selectedRow, "MovesSAN");
                        }
                        catch (Exception ex) { MessageBox.Show("Ошибка чтения данных из PGN таблицы: " + ex.Message); }
                    }
                    // Общая логика после получения movesSAN
                    try
                    {
                        _allMoves = ParseGame(txtGame.Text);
                        if (_allMoves.Count == 0)
                        {
                            MessageBox.Show("Не найдено ни одного хода в PGN тексте.", "Ошибка парсинга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Очистить доску и dgvMoves
                            if (_gameManager != null) _gameManager.GoToMove(0); // Сброс доски
                            dgvMoves.Rows.Clear();
                            return;
                        }
                        // Убедитесь, что 'chessboard' - это ваш визуальный компонент доски, 
                        // а не устаревший ChessboardControl, и ChessGameManager его корректно использует.
                        _gameManager = new ChessGameManager(chessboard, _allMoves);
                        DisplayMoves();
                        _gameManager.GoToMove(0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки PGN ходов или инициализации менеджера: {ex.Message}");
                    }
                };
                tableForm.Show();
            }
            iffirst++;
        }
        // Вспомогательный метод для безопасного получения значения столбца
        private string GetValueOrDefault(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
            {
                return row[columnName].ToString();
            }
            return "";
        }
        private void Converter_Load(object sender, EventArgs e) { }
        // ------------------- РЕСАЙЗ --------------------
        private void BoardControlsGroupBox_Resize(object sender, EventArgs e)
        {
            int padding = 20;
            int availableSize = Math.Min(this.BoardControlsGroupBox.Width - 2 * padding, this.BoardControlsGroupBox.Height - 2 * padding);
            // Если chessboard - это ваш UserControl, он должен иметь метод Resize или Size
            if (chessboard != null)
            {
                chessboard.Size = new Size(availableSize, availableSize);
            }
        }
        // ------------------   ОТЧЕТ   -------------
        private ChessReports _chessReports;
        private string _reportFilePath = string.Empty;
        private string GenerateMovesPreview(List<(string WhiteMove, string BlackMove)> allMoves, int startPair, int endPair, bool excludeFirstWhite, bool excludeLastBlack)
        {
            try
            {
                if (allMoves == null || allMoves.Count == 0 || startPair > endPair) return string.Empty;
                startPair = Math.Max(0, startPair);
                endPair = Math.Min(allMoves.Count - 1, endPair);
                StringBuilder preview = new StringBuilder();
                int moveNumber = startPair + 1;
                for (int i = startPair; i <= endPair; i++)
                {
                    bool isFirstPair = i == startPair;
                    if (!(isFirstPair && excludeFirstWhite))
                    {
                        preview.Append($"{moveNumber}. {allMoves[i].WhiteMove} ");
                    }
                    if (!string.IsNullOrEmpty(allMoves[i].BlackMove))
                    {
                        if (isFirstPair && excludeFirstWhite)
                        {
                            preview.Append($"{moveNumber}... {allMoves[i].BlackMove} ");
                        }
                        else if (!(i == endPair && excludeLastBlack))
                        {
                            preview.Append($"{allMoves[i].BlackMove} ");
                        }
                    }
                    moveNumber++;
                }
                return preview.ToString().Trim();
            }
            catch { return string.Empty; }
        }
        private void UpdateMovesPreview()
        {
            if (_allMoves == null || _allMoves.Count == 0) return;
            int startPair = (int)NudFromMove.Value - 1;
            int endPair = (int)NudToMove.Value - 1;
            string preview = GenerateMovesPreview(_allMoves, startPair, endPair, BlackMoveCheckBox.Checked, WhiteMoveCheckBox.Checked);
            txtMovesPreview.Text = preview;
        }
        // Убедитесь, что chessboard является контролом, поддерживающим DrawToBitmap
        // или замените GetChessBoardImage на метод, который получает изображение с вашей новой доски
        private Bitmap GetChessBoardImage()
        {
            try
            {
                // Если chessboard - это ваш кастомный UserControl с отрисовкой
                // Вам нужно добавить метод или свойство, которое возвращает текущее изображение доски
                // Например, public Bitmap GetBoardBitmap() { ... }
                // Или если это PictureBox, то PictureBox.Image
                if (chessboard is Control controlToDraw) // Проверяем, что это Control
                {
                    Bitmap bmp = new Bitmap(controlToDraw.Width, controlToDraw.Height);
                    controlToDraw.DrawToBitmap(bmp, controlToDraw.ClientRectangle);
                    return bmp;
                }
                MessageBox.Show("Контрол доски не поддерживает захват изображения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания изображения доски: {ex.Message}");
                return null;
            }
        }
        private void AddToReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_chessReports == null)
                {
                    using (SaveFileDialog saveDlg = new SaveFileDialog())
                    {
                        saveDlg.Filter = "RTF files|*.rtf|All files|*.*";
                        if (saveDlg.ShowDialog() == DialogResult.OK)
                        {
                            _reportFilePath = saveDlg.FileName;
                            _chessReports = new ChessReports();

                            var gameInfo = new List<string>
                            {
                                EventLbl.Text, SiteLbl.Text, DateLbl.Text, RoundLbl.Text,
                                WhiteLbl.Text, BlackLbl.Text, ResultLbl.Text,
                                WhiteEloLbl.Text, BlackEloLbl.Text, ECOLbl.Text
                            };
                            _chessReports.AddGameInfo(gameInfo);
                        }
                        else { return; }
                    }
                }
                var boardImage = GetChessBoardImage();
                if (boardImage != null)
                {
                    string lastMoveDesc = GetCurrentMoveDescription();
                    _chessReports.AddChessPosition(boardImage, lastMoveDesc);
                }
                if (!string.IsNullOrWhiteSpace(rtb.Text)) _chessReports.AddComment(rtb.Text);
                int startPair = (int)NudFromMove.Value - 1;
                int endPair = (int)NudToMove.Value - 1;
                _chessReports.AddMoves(_allMoves, startPair, endPair, BlackMoveCheckBox.Checked, WhiteMoveCheckBox.Checked);
                UpdatePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении в отчет: {ex.Message}");
            }
        }
        private string GetCurrentMoveDescription()
        {
            if (_currentMoveIndex <= 0) return "начальная позиция";
            int pairIndex = (_currentMoveIndex - 1) / 2;
            bool isBlackMove = (_currentMoveIndex - 1) % 2 == 1;
            if (pairIndex >= _allMoves.Count) return string.Empty;
            return isBlackMove && !string.IsNullOrEmpty(_allMoves[pairIndex].BlackMove)
                   ? $"...{_allMoves[pairIndex].BlackMove}"
                   : (!isBlackMove ? _allMoves[pairIndex].WhiteMove : string.Empty);
        }
        private void Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (_chessReports == null || string.IsNullOrEmpty(_reportFilePath))
                {
                    MessageBox.Show("Сначала добавьте данные в отчет!");
                    return;
                }
                if (_chessReports.SaveReport(_reportFilePath))
                {
                    MessageBox.Show($"Отчет сохранен:\n{_reportFilePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения отчета: {ex.Message}");
            }
        }
        private void UpdatePreview()
        {
            try
            {
                if (_chessReports != null) rtbPreview.Rtf = _chessReports.GetRtfContent();
            }
            catch { rtbPreview.Text = "Предпросмотр недоступен"; }
        }
        // ---------------- Скрыть элементы -------------------
        private bool gameinfois = true;
        private void GameInfoHideShow_Click(object sender, EventArgs e) { gameinfois = !gameinfois; tabControl1.Visible = gameinfois; ChessSplitter.Panel1Collapsed = !gameinfois; }
        private bool movespanel = true;
        private void скрытьХодыToolStripMenuItem_Click(object sender, EventArgs e) { movespanel = !movespanel; MovesGroupBox.Visible = movespanel; }
        private bool boardpanel = true;
        private void скрытьДоскуToolStripMenuItem1_Click(object sender, EventArgs e) { boardpanel = !boardpanel; BoardControlsGroupBox.Visible = boardpanel; }
        private void rtbPreview_KeyDown(object sender, KeyEventArgs e) { e.Handled = true; }
        private void rtbPreview_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }
        private void checkBoxIncludeImages_CheckedChanged(object sender, EventArgs e)
        {
            if (_chessReports != null)
            {
                _chessReports.IncludeImages = checkBoxIncludeImages.Checked;
                UpdatePreview();
            }
        }
        private void NudFromMove_ValueChanged(object sender, EventArgs e) { UpdateMovesPreview(); }
        private void NudToMove_ValueChanged(object sender, EventArgs e) { UpdateMovesPreview(); }
        private void BlackMoveCheckBox_CheckedChanged(object sender, EventArgs e) { UpdateMovesPreview(); }
        private void WhiteMoveCheckBox_CheckedChanged(object sender, EventArgs e) { UpdateMovesPreview(); }
        private void toolStripDropDownButton2_Click(object sender, EventArgs e) { }
    }
}