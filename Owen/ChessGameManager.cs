using ChessboardControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Owen
{
    public class ChessGameManager
    {
        private readonly Chessboard _board;
        private readonly List<(string WhiteMove, string BlackMove)> _moves;
        private readonly List<string> _cachedFENs = new List<string>();
        private string _pythonPath;
        private int _currentPosition;

        public ChessGameManager(Chessboard board, List<(string WhiteMove, string BlackMove)> moves)
        {
            if (!Directory.Exists("chess") || !File.Exists(Path.Combine("chess", "__init__.py")))
            {
                MessageBox.Show("Не найдены Python модули. Убедитесь, что папка chess существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _board = board;
            _moves = moves;
            _pythonPath = FindPythonPath();
            PrecachePositions();
        }

        private void PrecachePositions()
        {
            _cachedFENs.Clear();
            _board.SetupInitialPosition();
            string currentFen = _board.GetFEN();
            _cachedFENs.Add(currentFen);

            var allMoves = new List<string>();
            foreach (var (whiteMove, blackMove) in _moves)
            {
                if (!string.IsNullOrEmpty(whiteMove)) allMoves.Add(whiteMove);
                if (!string.IsNullOrEmpty(blackMove)) allMoves.Add(blackMove);
            }

            if (allMoves.Count == 0)
            {
                _currentPosition = 0;
                _board.LoadFEN(_cachedFENs[_currentPosition]);
                return;
            }

            var uciMoves = ConvertSanToUciBatch_Optimized(currentFen, allMoves);

            if (uciMoves == null || uciMoves.Count != allMoves.Count)
            {
                MessageBox.Show("Ошибка конвертации ходов. Проверьте корректность записи партии. Возможно, не все ходы были преобразованы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _currentPosition = 0;
                if (_cachedFENs.Any()) _board.LoadFEN(_cachedFENs[_currentPosition]);
                return;
            }

            foreach (var uciMove in uciMoves)
            {
                var move = ParseUciMove(uciMove);

                if (move == null)
                {
                    MessageBox.Show($"Не удалось разобрать или применить ход: '{uciMove}'. Проверьте файл логов.", "Ошибка хода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _currentPosition = _cachedFENs.Count - 1;
                    _board.LoadFEN(_cachedFENs[_currentPosition]);
                    return;
                }

                _board.MovePiece(move);

                _cachedFENs.Add(_board.GetFEN());
            }
            _currentPosition = 0;
            _board.LoadFEN(_cachedFENs[_currentPosition]);
        }

        private List<string> ConvertSanToUciBatch_Optimized(string initialFen, List<string> sanMoves)
        {
            string tempInputFile = Path.GetTempFileName();
            string tempOutputFile = Path.GetTempFileName();

            try
            {
                // Убедимся, что FEN и каждый SAN-ход записаны на отдельной строке без лишних пробелов/пустых строк
                var inputLines = new List<string> { initialFen.Trim() };
                inputLines.AddRange(sanMoves.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim()));
                File.WriteAllText(tempInputFile, string.Join("\n", inputLines), new UTF8Encoding(false));

                var pythonCode = $@"
import sys
import os
sys.path.insert(0, r'{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chess").Replace(@"\", @"\\")}')
import chess

input_file = r'{tempInputFile.Replace(@"\", @"\\")}'
output_file = r'{tempOutputFile.Replace(@"\", @"\\")}'

try:
    with open(input_file, 'r', encoding='utf-8') as f:
        # Убедимся, что f.readline() и f читаются корректно и strip() всегда применяется
        fen = f.readline().strip() 
        moves = [line.strip() for line in f if line.strip()] # Читаем ходы, убирая пустые строки и пробелы

    board = chess.Board(fen)
    uci_moves = []

    for san_move in moves:
        try:
            move = board.parse_san(san_move)
            # Изменение: Всегда берем только 4 символа UCI, отбрасывая символ превращения
            uci_moves.append(move.uci()[:4]) 
            board.push(move) 
        except Exception as e:
            with open(output_file, 'w', encoding='utf-8') as f_out:
                f_out.write(f'ERROR_SAN_CONVERSION: Failed to parse SAN ""{{san_move}}"": {{str(e)}}\n')
            sys.exit(1)

    with open(output_file, 'w', encoding='utf-8') as f_out:
        f_out.write('\n'.join(uci_moves)) # Записываем каждый UCI ход на новой строке

except Exception as e:
    with open(output_file, 'w', encoding='utf-8') as f_out:
        f_out.write(f'ERROR_PYTHON_SCRIPT: {{str(e)}}\n')
    sys.exit(1)
";
                using (var process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo // Исправлено на ProcessStartInfo
                    {
                        FileName = _pythonPath,
                        Arguments = $"-c \"{pythonCode.Replace("\"", "\\\"")}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        StandardOutputEncoding = Encoding.UTF8,
                        StandardErrorEncoding = Encoding.UTF8
                    };

                    process.Start();
                    string pythonStdOutput = process.StandardOutput.ReadToEnd();
                    string pythonStdError = process.StandardError.ReadToEnd();
                    process.WaitForExit(30000);

                    if (!process.HasExited)
                    {
                        process.Kill();
                        Debug.WriteLine("Python process timed out and was killed.");
                        return null;
                    }

                    if (process.ExitCode != 0)
                    {
                        Debug.WriteLine($"Python process exited with error code {process.ExitCode}.");
                        Debug.WriteLine($"Python StdOut: {pythonStdOutput}");
                        Debug.WriteLine($"Python StdErr: {pythonStdError}");

                        if (File.Exists(tempOutputFile))
                        {
                            string fileOutput = File.ReadAllText(tempOutputFile, Encoding.UTF8);
                            if (fileOutput.StartsWith("ERROR_SAN_CONVERSION:"))
                            {
                                Debug.WriteLine($"Python reported SAN conversion error: {fileOutput}");
                            }
                            else if (fileOutput.StartsWith("ERROR_PYTHON_SCRIPT:"))
                            {
                                Debug.WriteLine($"Python reported script error: {fileOutput}");
                            }
                        }
                        return null;
                    }

                    if (!File.Exists(tempOutputFile))
                    {
                        Debug.WriteLine("Python process finished, but output file was not created.");
                        return null;
                    }

                    var output = File.ReadAllText(tempOutputFile, Encoding.UTF8);
                    if (output.StartsWith("ERROR_SAN_CONVERSION:") || output.StartsWith("ERROR_PYTHON_SCRIPT:"))
                    {
                        Debug.WriteLine($"Python script reported an error: {output}");
                        return null;
                    }

                    // ИЗМЕНЕНИЕ ЗДЕСЬ: Добавляем .Trim() к каждой строке после Split
                    return output.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(s => s.Trim()) // Убираем любые оставшиеся пробелы
                                 .ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"General error during SAN to UCI conversion (using temp files): {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                return null;
            }
            finally
            {
                try { if (File.Exists(tempInputFile)) File.Delete(tempInputFile); } catch (Exception ex) { Debug.WriteLine($"Error deleting temp input file: {ex.Message}"); }
                try { if (File.Exists(tempOutputFile)) File.Delete(tempOutputFile); } catch (Exception ex) { Debug.WriteLine($"Error deleting temp output file: {ex.Message}"); }
            }
        }


        private ChessMove ParseUciMove(string uciOrSanMove)
        {
            // Убедимся, что строка чистая
            string cleanedMove = uciOrSanMove.Trim();

            // Обработка рокировок (UCI: e1g1, e1c1, e8g8, e8c8 ИЛИ SAN: O-O, O-O-O)
            if (cleanedMove == "e1g1") return CreateCastlingMove(true, true);
            if (cleanedMove == "e1c1") return CreateCastlingMove(true, false);
            if (cleanedMove == "e8g8") return CreateCastlingMove(false, true);
            if (cleanedMove == "e8c8") return CreateCastlingMove(false, false);

            // Если это SAN-нотация рокировки, которая не была переведена в UCI (например, из старого источника)
            if (TryConvertSanCastling(cleanedMove, out var castlingMove))
            {
                return castlingMove;
            }


            // Теперь ожидаем только 4-символьный UCI
            if (cleanedMove.Length != 4)
            {
                Debug.WriteLine($"Invalid UCI move format: '{cleanedMove}'. Expected 4 characters after trimming.");
                return null;
            }

            try
            {
                if (cleanedMove[0] < 'a' || cleanedMove[0] > 'h' ||
                    cleanedMove[1] < '1' || cleanedMove[1] > '8' ||
                    cleanedMove[2] < 'a' || cleanedMove[2] > 'h' ||
                    cleanedMove[3] < '1' || cleanedMove[3] > '8')
                {
                    Debug.WriteLine($"Invalid characters in UCI string: '{cleanedMove}'.");
                    return null;
                }

                var from = new ChessSquare(
                    (ChessFile)(cleanedMove[0] - 'a'),
                    (ChessRank)(cleanedMove[1] - '1'));
                var to = new ChessSquare(
                    (ChessFile)(cleanedMove[2] - 'a'),
                    (ChessRank)(cleanedMove[3] - '1'));

                var move = _board.CheckMoveValidity(from, to);

                return move;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception during UCI parsing for '{cleanedMove}': {ex.Message}");
                return null;
            }
        }

        private bool TryConvertSanCastling(string sanMove, out ChessMove move)
        {
            move = null;
            if (string.IsNullOrEmpty(sanMove)) return false;

            if (sanMove == "O-O" || sanMove == "0-0" || sanMove == "O-O-O" || sanMove == "0-0-0")
            {
                string currentFen = _cachedFENs[_cachedFENs.Count - 1];
                bool isWhite = currentFen.Split(' ')[1] == "w";

                bool isKingside = (sanMove == "O-O" || sanMove == "0-0");

                ChessFile kingFromFile = ChessFile.e;
                ChessFile kingToFile = isKingside ? ChessFile.g : ChessFile.c;
                ChessRank rank = isWhite ? ChessRank._1 : ChessRank._8;

                var kingFrom = new ChessSquare(kingFromFile, rank);
                var kingTo = new ChessSquare(kingToFile, rank);

                move = _board.CheckMoveValidity(kingFrom, kingTo);
                return move != null;
            }
            return false;
        }


        private ChessMove CreateCastlingMove(bool isWhite, bool isKingside)
        {
            ChessFile kingFromFile = ChessFile.e;
            ChessFile kingToFile = isKingside ? ChessFile.g : ChessFile.c;
            ChessRank rank = isWhite ? ChessRank._1 : ChessRank._8;

            var kingFrom = new ChessSquare(kingFromFile, rank);
            var kingTo = new ChessSquare(kingToFile, rank);

            var move = _board.CheckMoveValidity(kingFrom, kingTo);
            return move;
        }

        public void GoToMove(int movePairIndex)
        {
            if (movePairIndex < 0 || movePairIndex >= _cachedFENs.Count) return;
            _currentPosition = movePairIndex;
            _board.LoadFEN(_cachedFENs[movePairIndex]);
        }

        public void GoToNextMove()
        {
            if (_currentPosition + 1 < _cachedFENs.Count)
            {
                _board.LoadFEN(_cachedFENs[++_currentPosition]);
            }
        }

        public void GoToPrevMove()
        {
            if (_currentPosition > 0)
            {
                _board.LoadFEN(_cachedFENs[--_currentPosition]);
            }
        }

        private string FindPythonPath()
        {
            try
            {
                var savedPath = Properties.Settings.Default.PythonPath;
                if (!string.IsNullOrEmpty(savedPath) && File.Exists(savedPath))
                {
                    return savedPath;
                }
            }
            catch { /* Ignore */ }

            var pathsToCheck = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            var pathEnv = Environment.GetEnvironmentVariable("PATH") ?? "";
            foreach (var path in pathEnv.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var fullPath = Path.Combine(path, "python.exe");
                if (File.Exists(fullPath))
                {
                    pathsToCheck.Add(fullPath);
                }
            }

            var versions = new[] { "39", "310", "311", "312", "313", "314" };
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            foreach (var ver in versions)
            {
                pathsToCheck.Add(Path.Combine(appData, "Programs", "Python", $"Python{ver}", "python.exe"));
                pathsToCheck.Add(Path.Combine(programFiles, $"Python{ver}", "python.exe"));
                pathsToCheck.Add(Path.Combine(appData, "Microsoft", "WindowsApps", $"python{ver}.exe"));
                pathsToCheck.Add(Path.Combine(appData, "Microsoft", "WindowsApps", "python.exe"));
            }

            foreach (var path in pathsToCheck.Distinct())
            {
                if (File.Exists(path))
                {
                    Properties.Settings.Default.PythonPath = path;
                    Properties.Settings.Default.Save();
                    return path;
                }
            }

            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Python Executable|python.exe|All Files|*.*";
                dialog.Title = "Укажите путь к python.exe";
                dialog.CheckFileExists = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.PythonPath = dialog.FileName;
                    Properties.Settings.Default.Save();
                    return dialog.FileName;
                }
            }

            throw new FileNotFoundException("Python не найден. Установите Python или укажите путь вручную.");
        }
    }
}