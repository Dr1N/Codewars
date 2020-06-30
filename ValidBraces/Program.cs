using System;
using System.Collections.Generic;

namespace ValidBraces
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, bool>()
            {
                { "(){}[]", true },
                { "([{}])", true },
                { "(}", false },
                { "[(])", false },
                { "[({})](]", false },
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

        private static bool IsValid(string str)
        {
            var roundBrackets = new Stack<bool>();
            var squareBrackets = new Stack<bool>();
            var braces = new Stack<bool>();

            try
            {
                foreach (var ch in str)
                {
                    switch (ch)
                    {
                        case '(':
                        case ')':
                            Process(roundBrackets, ch);
                            break;
                        case '[':
                        case ']':
                            Process(squareBrackets, ch);
                            break;
                        case '{':
                        case '}':
                            Process(braces, ch);
                            break;
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static bool Process(Stack<bool> stack, char value)
        {
            var result = true;

            return result;
        }
    }
}
