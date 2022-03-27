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
        private const string Game = "Game";
        private const string Separator = "_";
        
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
            var board = new string[Height, Width];
            foreach (var piece in piecesPositionList)
            {
                var result = Game;
                AddPieceToBoard(board, piece);
                var lines = GetFilledLinesFromAvailableLinesFromBoard(board);
                if (lines.Count > 0)
                {
                    result = GetResultFromLines(lines);
                }
                if (result != Game)
                {
                    return result;
                }
            }

            return Draw;
        }

        private static void AddPieceToBoard(string[,] board, string piece)
        {
            var parts = piece.Split(Separator);
            var colName = parts[0];
            var color = parts[1];
            var colIndex = ColumnIndexes[colName];
            var rowIndex = GetFreeCellInColumn(board, colIndex);
            board[rowIndex, colIndex] = color;
        }

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

        private static List<List<string>> GetFilledLinesFromAvailableLinesFromBoard(string[,] board)
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
                    if (horizontalLine.Count > 0 && horizontalLine.All(e => e != null))
                    {
                        result.Add(horizontalLine);
                    }

                    if (verticalLine.Count > 0 && verticalLine.All(e => e != null))
                    {
                        result.Add(verticalLine);
                    }

                    if (mainDiagonal.Count > 0 && mainDiagonal.All(e => e != null))
                    {
                        result.Add(mainDiagonal);
                    }

                    if (secondDiagonal.Count > 0 && secondDiagonal.All(e => e != null))
                    {
                        result.Add(secondDiagonal);
                    }
                }
            }
            
            return result;
        }
        
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
        
        private static string GetResultFromLines(IReadOnlyCollection<List<string>> lines)
        {
            var isRed = lines.Any(e =>
                e.All(x => x == Red));

            if (isRed)
            {
                return Red;
            }
            
            var isYellow = lines.Any(e =>
                e.All(x => x == Yellow));

            if (isYellow)
            {
                return Yellow;
            }
            
            return Game;
        }
    }
}