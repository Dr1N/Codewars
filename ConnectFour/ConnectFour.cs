using System;
using System.Collections.Generic;

namespace ConnectFour
{
    public static class ConnectFour
    {
        private const int Width = 7;
        private const int Height = 6;
        private const int LineLength = 4;
        private static readonly Dictionary<string, int> ColumnIndexes = new()
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
            var result = GetResultFromLines(lines);

            return result;
        }

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

        private static List<List<string>> GetAvailableLinesFromBoard(string[,] board)
        {
            var result = new List<List<string>>();
            for (var row = 0; row < Height; row++)
            {
                for (var col = 0; col < Width; col++)
                {
                    var horizontalLine = GetHorizontalLine(board, row, col);
                    if (horizontalLine.Count > 0)
                    {
                        result.Add(horizontalLine);
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
        
        private static string GetResultFromLines(List<List<string>> lines)
        {
            return string.Empty;
        }
    }
}