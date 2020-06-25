using System;
using System.Collections.Generic;

namespace Difference_2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var t0 = new[] { 1, 2, 3, 4 };
            var t1 = new[] { 1, 3, 4, 6};
            var t2 = new[] { 1, 2, 3, 4 };
            var t3 = new[] { 1 , 23, 3, 4, 7 };
            var t4 = new[] { 4, 3, 1, 5, 6 };

            var r1 = Calculation(t0);
            var r2 = Calculation(t1);
            var r3 = Calculation(t2);
            var r4 = Calculation(t3);
            var r5 = Calculation(t4);
        }

        private static (int, int)[] Calculation(int[] array)
        {
            if (array == null || array.Length == 1)
            {
                return new (int, int)[1];
            }

            Array.Sort(array);
            var result = new List<(int, int)>();

            if (array.Length == 2)
            {
                if (Math.Abs(array[0] - array[1]) == 2)
                {
                    result.Add((array[0], array[1]));
                }
            }
            else
            {
                for (var i = 0; i < array.Length - 1; i++)
                {
                    for (var j = 1; j <= 2; j++)
                    {
                        if (i + j >= array.Length)
                        {
                            continue;
                        }
                        if (Math.Abs(array[i] - array[i + j]) == 2)
                        {
                            result.Add((array[i], array[i + j]));
                        }
                    }
                }
            }

            return result.ToArray();
        }
    }
}