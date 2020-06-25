using System;

namespace MiddleSymbol
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetMiddle("test"));
            Console.WriteLine(GetMiddle("testing"));
            Console.WriteLine(GetMiddle("middle"));
            Console.WriteLine(GetMiddle("A"));
            Console.WriteLine(GetMiddle("AbC"));
        }

        static string GetMiddle(string s)
        {
            var len = s.Length;
            if (len != 1)
            {
                var isOdd = len % 2 != 0;
                return isOdd ? s.Substring(len / 2, 1) : s.Substring(len / 2 - 1 , 2);
            }

            return s;
        }
    }
}
