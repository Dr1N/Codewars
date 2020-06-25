using System;
using System.Collections.Generic;
using System.Linq;

namespace SubarraySum
{
    internal static class Program
    {
        private static void Main()
        {
            var test = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Console.WriteLine($"{Calculate(test)}");
        }

        private static int Calculate(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            if (array.Length == 1)
            {
                return array[0];
            }

            var combinations = new List<List<int>>();
            for (int i = 0; i < array.Length; i++)
            {
                var tmp = new List<int>() { array[i] };
                for (int j = i + 1; j < array.Length; j++)
                {
                    tmp.Add(array[j]);
                    combinations.Add(tmp.ToList());
                }
            }

            return combinations.Max(c => c.Sum());
        }
    }
}
