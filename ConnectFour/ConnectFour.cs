using System;
using System.Collections.Generic;

namespace ConnectFour
{
    public static class ConnectFour
    {
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
            var result = new string[7, 6];
            foreach (var element in piecesPositionList)
            {
                var parts = element.Split("_");
                var row = parts[0];
                var color = parts[1];
                var rowIndex = ColumnIndexes[row];
                var colIndex = GetFreeCellInColumn(result, rowIndex);
                result[rowIndex, colIndex] = color;
            }
            
            return result;
        }

        private static List<List<string>> GetAvailableLinesFromBoard(string[,] board)
        {
            var result = new List<List<string>>();

            return result;
        }

        private static string GetResultFromLines(List<List<string>> lines)
        {
            return string.Empty;
        }

        private static int GetFreeCellInColumn(string[,] board, int row)
        {
            for (var y = 5; y >= 0; y--)
            {
                var cell = board[row, y];
                if (string.IsNullOrEmpty(cell))
                {
                    return y;
                }
            }

            throw new ArgumentException("Invalid column index");
        } 
    }
}