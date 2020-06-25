using System;
using System.Collections.Generic;
using System.Linq;

namespace FindOddInt
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var seq = new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 };
            Console.WriteLine(find_it(seq));
        }

        private static int find_it(IReadOnlyList<int> seq)
        {
            var result = -1;
            if (seq.Count == 1)
            {
                result = seq[0];
            }
            else
            {
                var counterDictionary = Calculate(seq);
                foreach (var (key, value) in counterDictionary)
                {
                    if (value % 2 == 0) continue;
                    result = key;
                    break;
                }
            }

            return result;
        }

        private static IDictionary<int,int> Calculate(IEnumerable<int> seq)
        {
            var result = new Dictionary<int, int>();
            foreach (var t in seq)
            {
                if (result.Keys.Contains(t))
                {
                    result[t] = result[t] + 1;
                }
                else
                {
                    result[t] = 1;
                }
            }

            return result;
        }
    }
}