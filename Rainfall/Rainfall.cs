using System;
using System.Globalization;
using System.Linq;

namespace Rainfall
{
    internal static class Rainfall 
    {
        private static double Mean(string town, string stats)
        {
            if (!stats.Contains($"{town}:"))
            {
                return -1.0;
            }
            
            var mean = stats.Split("\n")
                .First(e => e.StartsWith($"{town}:"))
                .Split(":")
                .Skip(1)
                .First()
                .Split(",")
                .Select(e => double.Parse(e.Split(" ")[1], CultureInfo.InvariantCulture))
                .Average();
            
            return mean;
        }

        public static double Variance(string town, string stats)
        {
            var mean = Mean(town, stats);
            if (Math.Abs(mean - (-1.0)) < 1e-2)
            {
                return -1.0;
            }
            
            var variance = stats.Split("\n")
                .First(e => e.StartsWith(town))
                .Split(":")
                .Skip(1)
                .First()
                .Split(",")
                .Select(e => double.Parse(e.Split(" ")[1], CultureInfo.InvariantCulture))
                .Select(e => Math.Pow(e - mean, 2))
                .Average();
            
            return variance;
        }
    }
}