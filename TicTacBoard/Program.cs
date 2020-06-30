using System;

namespace TicTacBoard
{
    internal static class Program
    {
        static void Main()
        {
            var board = new int[,] { { 1, 2, 1 }, { 1, 1, 2 }, { 2, 1, 2 } };
            Console.WriteLine(Result(board));
        }

        private static int Result(int[,] board)
        {
            // Rows
            for (int i = 0; i < 3; i++)
            {
                var line = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    line[j] = board[i, j];
                }
                var rw = CheckLine(line);
                if (rw != -1)
                {
                    return rw;
                }
            }

            // Cols

            for (int i = 0; i < 3; i++)
            {
                var line = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    line[j] = board[j, i];
                }
                var cl = CheckLine(line);
                if (cl != -1)
                {
                    return cl;
                }
            }

            // Cross

            var diag1 = new[] { board[0, 0], board[1, 1], board[2, 2] };
            var dg1 = CheckLine(diag1);
            if (dg1 != -1)
            {
                return dg1;
            }

            var diag2 = new[] { board[2, 0], board[1, 1], board[0, 2] };
            var dg2 = CheckLine(diag2);
            if (dg2 != -1)
            {
                return dg2;
            }

            // Draw

            var cnt = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i,j] == 0)
                    {
                        cnt++;
                    }
                }
            }

            if (cnt == 0)
            {
                return 0;
            }

            return -1;
        }

        private static int CheckLine(int[] line)
        {
            if (line[0] == line[1] && line[0] == line[2] && line[0] != 0)
            {
                return line[0] == 1 ? 1 : 2;
            }

            return -1;
        }
    }
}
