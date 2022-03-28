using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Friday13ths
{
    static class Program
    {
        private static void Main()
        {
            Console.WriteLine(Kata.FridayTheThirteenths(1999, 2000));
            Console.WriteLine(Kata.FridayTheThirteenths(2014, 2015));
            Console.WriteLine(Kata.FridayTheThirteenths(2000));
        }
    }
    
    public static class Kata
    {
        public static string FridayTheThirteenths(int start, int end = int.MinValue)
        {
            var range = new DateRange(start: start, end: end);
            var result = range.GetDays()
                .Where(d => d.DayOfWeek == DayOfWeek.Friday && d.Day == 13)
                .Select(d => d.ToString("M/dd/yyyy", CultureInfo.InvariantCulture))
                .ToList();

            return string.Join(" ", result);
        }
    }

    public class DateRange
    {
        private readonly int start;

        private readonly int end;

        public DateRange(int start, int end)
        {
            this.start = start;
            this.end = end == int.MinValue ? start : end;
        }

        public IEnumerable<DateTime> GetDays()
        {
            for (var dt = new DateTime(start, 1, 13);
                 dt.Year <= end;
                 dt = dt.AddMonths(1))
            {
                yield return dt;
            }
        }
    }
}