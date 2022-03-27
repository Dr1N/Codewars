using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFour
{
    public static class ConnectFour
    {
        private const int Width = 7;
        private const int Height = 6;
        private const int LineLength = 4;
        private const string Red = "Red";
        private const string Yellow = "Yellow";
        private const string Draw = "Draw";
        
        private static readonly Dictionary<string, int> ColumnIndexes = new Dictionary<string, int>()
        {
            {"A", 0 },
            {"B", 1 },
            {"C", 2 },
            {"D", 3 },
            {"E", 4 },
            {"F", 5 },
            {"G", 6 },
        };

        public static string WhoIsWinner(List<string> piecesPositionList)
        {
            var board = GenerateGameBoard(piecesPositionList);
            var lines = GetAvailableLinesFromBoard(board);
            var firstPlayerColor = GetFirstPlayerColor(piecesPositionList);
            var result = GetResultFromLines(lines, firstPlayerColor);

            return result;
        }

        /// <summary>
        /// Generate game board by pieces history
        /// </summary>
        /// <param name="piecesPositionList">Pieces history. Format ColumnName_Color (for example A_Red, G_Yellow)</param>
        /// <returns>Matrix with current game state</returns>
        private static string[,] GenerateGameBoard(List<string> piecesPositionList)
        {
            var result = new string[Height, Width];
            foreach (var element in piecesPositionList)
            {
                var parts = element.Split("_");
                var colName = parts[0];
                var color = parts[1];
                var colIndex = ColumnIndexes[colName];
                var rowIndex = GetFreeCellInColumn(result, colIndex);
                result[rowIndex, colIndex] = color;
            }
            
            return result;
        }

        /// <summary>
        /// Get first free cell in column
        /// </summary>
        /// <param name="board">Game board <see cref="GenerateGameBoard"/></param>
        /// <param name="col">Current column</param>
        /// <returns>Index of free cell in col</returns>
        /// <exception cref="ArgumentException">If no free cell in column</exception>
        private static int GetFreeCellInColumn(string[,] board, int col)
        {
            for (var row = Height - 1; row >= 0; row--)
            {
                var cell = board[row, col];
                if (string.IsNullOrEmpty(cell))
                {
                    return row;
                }
            }

            throw new ArgumentException("Invalid column index");
        }

        /// <summary>
        /// Generate all possible lines from board
        /// </summary>
        /// <param name="board">Game board</param>
        /// <returns>List of lines</returns>
        private static List<List<string>> GetAvailableLinesFromBoard(string[,] board)
        {
            var result = new List<List<string>>();
            for (var row = 0; row < Height; row++)
            {
                for (var col = 0; col < Width; col++)
                {
                    var horizontalLine = GetHorizontalLine(board, row, col);
                    var verticalLine = GetVerticalLine(board, row, col);
                    var mainDiagonal = GetMainDiagonalLine(board, row, col);
                    var secondDiagonal = GetSecondDiagonalLine(board, row, col);
                    if (horizontalLine.Count > 0)
                    {
                        result.Add(horizontalLine);
                    }

                    if (verticalLine.Count > 0)
                    {
                        result.Add(verticalLine);
                    }

                    if (mainDiagonal.Count > 0)
                    {
                        result.Add(mainDiagonal);
                    }

                    if (secondDiagonal.Count > 0)
                    {
                        result.Add(secondDiagonal);
                    }
                }
            }
            
            return result;
        }
        
        /// <summary>
        /// Get horizontal line for cell
        /// </summary>
        /// <param name="board">Game board</param>
        /// <param name="targetRow">Cell row index</param>
        /// <param name="targetCol">Cell column index</param>
        /// <returns>List of horizontal line values or empty list</returns>
        private static List<string> GetHorizontalLine(string[,] board, int targetRow, int targetCol)
        {
            var result = new List<string>(4);
            if (targetCol + LineLength > Width)
            {
                return result;
            }

            for (var step = 0; step < LineLength; step++)
            {
                result.Add(board[targetRow, targetCol + step]);
            }
            
            return result;
        }

        /// <summary>
        /// Get vertical line for cell
        /// </summary>
        /// <param name="board">Game board</param>
        /// <param name="targetRow">Cell row index</param>
        /// <param name="targetCol">Cell column index</param>
        /// <returns>List of vertical line values or empty list</returns>
        private static List<string> GetVerticalLine(string[,] board, int targetRow, int targetCol)
        {
            var result = new List<string>(4);
            if (targetRow + LineLength > Height)
            {
                return result;
            }

            for (var step = 0; step < LineLength; step++)
            {
                result.Add(board[targetRow + step, targetCol]);
            }
            
            return result;
        }

        /// <summary>
        /// Get main diagonal line for cell
        /// </summary>
        /// <param name="board">Game board</param>
        /// <param name="targetRow">Cell row index</param>
        /// <param name="targetCol">Cell column index</param>
        /// <returns>List of main diagonal line values or empty list</returns>
        private static List<string> GetMainDiagonalLine(string[,] board, int targetRow, int targetCol)
        {
            var result = new List<string>(4);
            if (targetCol + LineLength > Width || targetRow + LineLength > Height)
            {
                return result;
            }

            for (var step = 0; step < LineLength; step++)
            {
                result.Add(board[targetRow + step, targetCol + step]);
            }
            
            return result;
        }
        
        /// <summary>
        /// Get second diagonal line for cell
        /// </summary>
        /// <param name="board">Game board</param>
        /// <param name="targetRow">Cell row index</param>
        /// <param name="targetCol">Cell column index</param>
        /// <returns>List of second diagonal line values or empty list</returns>
        private static List<string> GetSecondDiagonalLine(string[,] board, int targetRow, int targetCol)
        {
            var result = new List<string>(4);
            if (targetCol + 1 - LineLength < 0 || targetRow + LineLength > Height)
            {
                return result;
            }

            for (var step = 0; step < LineLength; step++)
            {
                result.Add(board[targetRow + step, targetCol - step]);
            }
            
            return result;
        }
        
        /// <summary>
        /// Get first player color
        /// </summary>
        /// <param name="piecesPositionList">History of pieces</param>
        /// <returns>Color</returns>
        private static string GetFirstPlayerColor(List<string> piecesPositionList)
        {
            var firstPices = piecesPositionList.First();
            var parts = firstPices.Split("_");

            return parts[1];
        }

        /// <summary>
        /// Get game result
        /// </summary>
        /// <param name="lines">All lines for analyze</param>
        /// <param name="firstColor">First player color</param>
        /// <returns>Winner color or "Draw"</returns>
        private static string GetResultFromLines(IReadOnlyCollection<List<string>> lines, string firstColor)
        {
            var isRed = lines.Any(e =>
                e.All(x => x == Red));

            var isYellow = lines.Any(e =>
                e.All(x => x == Yellow));

            if (isRed && isYellow)
            {
                return firstColor;
            }

            if (isRed)
            {
                return Red;
            }

            if (isYellow)
            {
                return Yellow;
            }
            
            return Draw;
        }
    }
}