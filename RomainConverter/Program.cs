using System;
using System.Text;

namespace RomainConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution(1));
            Console.WriteLine(Solution(2));
            Console.WriteLine(Solution(4));
            Console.WriteLine(Solution(500));
            Console.WriteLine(Solution(1000));
            Console.WriteLine(Solution(1954));
            Console.WriteLine(Solution(1990));
            Console.WriteLine(Solution(2008));
            Console.WriteLine(Solution(2014));
        }

        public static string Solution(int n)
        {
            if (n <= 0 || 3999 < n)
            {
                throw new ArgumentException();
            }
            var tausends = n / 1000;
            var hunderts = (n - tausends * 1000) / 100;
            var tens = (n - tausends * 1000 - hunderts * 100) / 10;
            var ones = n % 10;

            StringBuilder sb = new StringBuilder();
            if (tausends > 0)
            {
                sb.Append(new String('M', tausends));
            }
            sb.Append(CreateRomeSymbol(hunderts, 'C', 'D', 'M'));
            sb.Append(CreateRomeSymbol(tens, 'X', 'L', 'C'));
            sb.Append(CreateRomeSymbol(ones, 'I', 'V', 'X'));
            
            return sb.ToString();
        }

        public static string CreateRomeSymbol(int val, char rom, char midle, char next)
        {
            if (val == 0)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            if (val <= 3)
            {
                sb.Append(rom, val);
            }
            else if (val == 4)
            {
                sb.Append(rom);
                sb.Append(midle);
            }
            else if (val == 5)
            {
                sb.Append(midle);
            }
            else if (5 < val && val < 9)
            {
                sb.Append(midle);
                sb.Append(rom, val - 5);
            }
            else
            {
                sb.Append(rom);
                sb.Append(next);
            }

            return sb.ToString();
        }
    }
}
