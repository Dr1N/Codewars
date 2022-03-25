using System.Collections.Generic;

namespace ConnectFour
{
    public static class ConnectFour
    {
        public static string WhoIsWinner(List<string> piecesPositionList)
        {
            var board = GenerateGameBoard(piecesPositionList);
            var lines = GetAvailableLinesFromBoard(board);
            var result = GetResultFromLines(lines);

            return result;
        }

        private static string[,] GenerateGameBoard(List<string> piecesPositionList)
        {
            var result = new string[6,7];
            
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
    }
}