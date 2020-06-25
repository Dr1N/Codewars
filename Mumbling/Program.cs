using System;
using System.Collections.Generic;

namespace Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Accum("abcd"));
            Console.WriteLine(Accum("RqaEzty"));
            Console.WriteLine(Accum("cwAt"));
        }

        static String Accum(string s)
        {
            var buffer = new List<string>();

            for (int i = 0; i < s.Length; i++)
            {
                var firstSymbol = char.ToUpper(s[i]);
                var tail = new string(char.ToLower(s[i]), i);
                buffer.Add(firstSymbol + tail);
            }

            return string.Join("-", buffer);
        }
    }
}
