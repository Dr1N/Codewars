using System;
using System.Linq;

namespace Multiples35
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Solution(10));
            Console.WriteLine(Solution(25));
            Console.WriteLine(Solution(1000));
        }

        private static int Solution(int value)
        {
            return Enumerable.Range(0, value).Where(n => n % 5 == 0 || n % 3 == 0).Sum();
        }
    }
}
