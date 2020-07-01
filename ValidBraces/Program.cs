using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidBraces
{
    internal static class Program
    {
        private static void Main()
        {
            var dict = new Dictionary<string, bool>()
            {
                { "(((({{", false },
                { "(){}[]", true },
                { "([{}])", true },
                { "[(])", false },
                { "[({})](]", false },
                { ")", false},
                { "(", false},
                { ")(", false},
                { "{}{}{}({}){[]}", true},
                { string.Empty, false},
                { "((((({{{{}}})})))", false},
                { ")()(", false},
            };

            foreach (var item in dict)
            {
                if (IsValid(item.Key) == item.Value)
                {
                    Console.WriteLine($"{item.Key} : Correct");
                }
                else
                {
                    Console.WriteLine($"{item.Key} : Error");
                }
            }
        }

        private static bool IsValid(string braces)
        {
            if (string.IsNullOrEmpty(braces) || braces.Length % 2 != 0)
            {
                return false;
            }

            var stack = new Stack<char>();

            var pairs = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' },
            };

            foreach (var ch in braces)
            {
                if (pairs.Values.Contains(ch))
                {
                    stack.Push(ch);
                }
                else if (pairs.Keys.Contains(ch))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var br = stack.Pop();
                    if (ch != pairs.First(i => i.Value == br).Key)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
