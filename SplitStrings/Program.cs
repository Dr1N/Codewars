using System.Collections.Generic;

namespace SplitStrings
{
    internal static class Program
    {
        static void Main()
        {
            Split("abc");
            Split("abcdef");
        }

        private static string[] Split(string str)
        {
            var list = new List<string>();

            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length % 2 != 0)
                {
                    str += "_";
                }

                for (int i = 0; i < str.Length - 1; i += 2)
                {
                    list.Add($"{str[i]}{str[i + 1]}");
                }
            }

            return list.ToArray();
        }
    }
}
