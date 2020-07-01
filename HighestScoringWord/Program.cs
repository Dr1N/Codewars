using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace HighestScoringWord
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var texts = new List<string>()
            {
                "xjvgonoxxbzrkybij sqvcuvjkwwavjjys",
            };

            foreach (var text in texts)
            {
                Console.WriteLine(High(text));
            }
        }

        private static string High(string text)
        {
            var dict = new Dictionary<int, string>();
            foreach (var word in text.Split(" ").Select(w => w.Trim()).ToList())
            {
                var scores = CalcWordScores(word);
                if (!dict.ContainsKey(scores))
                {
                    dict[CalcWordScores(word)] = word;
                }
            }

            return dict[dict.Max(x => x.Key)];
        }

        private static int CalcWordScores(string word)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            var scores = 0;
            foreach (var ch in word)
            {
                scores += alphabet.IndexOf(ch) + 1;
            }

            return scores;
        }
    }
}
