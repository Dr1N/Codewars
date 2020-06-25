using System;
using System.Linq;

namespace VowelCount
{
    internal static class Program
    {
        private static int GetVowelCount(string str)
        {
            var vowelCount = 0;
            var vowel = new[] { 'a', 'e', 'i', 'o', 'u' };
            if (!string.IsNullOrEmpty(str))
            {
                vowelCount = str.ToLower().Trim().Count(c => vowel.Contains(c));
            }

            return vowelCount;
        }

        private static void Main()
        {
            Console.WriteLine(GetVowelCount("abracadabra"));
            Console.WriteLine(GetVowelCount("fffffffffff"));
            Console.WriteLine(GetVowelCount("aaaaaaaaaaa"));
        }
    }
}