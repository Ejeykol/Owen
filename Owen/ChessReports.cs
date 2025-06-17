using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class ChessReports
{
    private int _imageCounter = 1;
    private readonly StringBuilder _rtfContent = new StringBuilder();
    private const int ImageWidthCm = 10;
    public bool IncludeImages { get; set; } = true;

    public ChessReports()
    {
        InitializeRtfDocument();
    }

    private void InitializeRtfDocument()
    {
        _rtfContent.AppendLine(@"{\rtf1\ansi\ansicpg1251");
        _rtfContent.AppendLine(@"{\fonttbl{\f0\fnil Times New Roman;}}");
        _rtfContent.AppendLine(@"\viewkind4\uc1\pard\f0\fs28");
        _rtfContent.AppendLine(@"\sl360\slmult1\fi709\li0\ri0\qj");
    }

    public void AddGameInfo(List<string> gameInfo)
    {
        try
        {
            _rtfContent.AppendLine(@"{\pard\qc\b " + EscapeRtf("Информация о партии") + @"\b0\par}");
            _rtfContent.AppendLine(@"{\pard\fi709\li0\ri0\qj");

            foreach (var item in gameInfo)
            {
                if (!string.IsNullOrEmpty(item))
                    _rtfContent.AppendLine(EscapeRtf(item) + @"\par");
            }

            _rtfContent.AppendLine(@"\par}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при добавлении информации: {ex.Message}");
        }
    }

    public void AddChessPosition(Image boardImage, string lastMoveDescription)
    {
        try
        {
            if (boardImage == null || !IncludeImages) return;

            int widthTwips = ImageWidthCm * 567;
            int heightTwips = (int)(widthTwips * ((double)boardImage.Height / boardImage.Width));

            _rtfContent.AppendLine(@"{\pard\qc");
            _rtfContent.AppendLine(GetImageRtfCode(boardImage, widthTwips, heightTwips));
            _rtfContent.AppendLine(@"\par}");

            // Формируем подпись к изображению
            string caption = $"Рис {_imageCounter} Позиция после {lastMoveDescription}";
            _rtfContent.AppendLine(@"{\pard\qc " + EscapeRtf(caption) + @"\par}");

            _imageCounter++;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при добавлении изображения: {ex.Message}");
        }
    }

    public void AddComment(string text)
    {
        try
        {
            if (string.IsNullOrEmpty(text)) return;

            _rtfContent.AppendLine(@"{\pard\fi709\li0\ri0\qj");
            _rtfContent.Append(EscapeRtf(text));
            _rtfContent.AppendLine(@"\par}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при добавлении текста: {ex.Message}");
        }
    }
    public void AddMoves(
        List<(string WhiteMove, string BlackMove)> allMoves,
        int startPair,
        int endPair,
        bool excludeFirstWhite,
        bool excludeLastBlack)
    {
        try
        {
            if (allMoves == null || allMoves.Count == 0) return;

            startPair = Math.Max(0, startPair);
            endPair = Math.Min(allMoves.Count - 1, endPair);

            if (startPair > endPair) return;

            StringBuilder movesText = new StringBuilder("Ходы партии: ");

            for (int i = startPair; i <= endPair; i++)
            {
                bool isFirstPair = i == startPair;
                bool isLastPair = i == endPair;

                // Ход белых
                if (!(isFirstPair && excludeFirstWhite))
                {
                    movesText.Append($"{i + 1}.{allMoves[i].WhiteMove} ");
                }

                // Ход черных
                if (!string.IsNullOrEmpty(allMoves[i].BlackMove))
                {
                    if (isFirstPair && excludeFirstWhite)
                    {
                        movesText.Append($"{i + 1}...{allMoves[i].BlackMove} ");
                    }
                    else if (!(isLastPair && excludeLastBlack))
                    {
                        movesText.Append($"{allMoves[i].BlackMove} ");
                    }
                }
            }

            _rtfContent.AppendLine(@"{\pard\fi709\li0\ri0\qj " + EscapeRtf(movesText.ToString()) + @"\par}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при добавлении ходов: {ex.Message}");
        }
    }
    private string GetImageRtfCode(Image image, int widthTwips, int heightTwips)
    {
        try
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                string hexString = BitConverter.ToString(imageBytes).Replace("-", "");

                return $@"{{\pict\pngblip\picw{image.Width}\pich{image.Height}\picwgoal{widthTwips}\pichgoal{heightTwips} {hexString}}}";
            }
        }
        catch
        {
            return string.Empty;
        }
    }

    public string GetRtfContent()
    {
        return _rtfContent.ToString() + "}";
    }

    public bool SaveReport(string filePath)
    {
        try
        {
            File.WriteAllText(filePath, GetRtfContent());
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении отчета: {ex.Message}");
            return false;
        }
    }

    private string EscapeRtf(string text)
    {
        if (string.IsNullOrEmpty(text)) return string.Empty;

        StringBuilder sb = new StringBuilder();
        foreach (char c in text)
        {
            if (c > 127)
            {
                sb.Append(@"\u" + (int)c + "?");
            }
            else
            {
                switch (c)
                {
                    case '\\': sb.Append(@"\\"); break;
                    case '{': sb.Append(@"\{"); break;
                    case '}': sb.Append(@"\}"); break;
                    case '\r': break;
                    case '\n': sb.Append(@"\line "); break;
                    default: sb.Append(c); break;
                }
            }
        }
        return sb.ToString();
    }
}