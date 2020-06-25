using System;

namespace StrayNmber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Stray(new[] { 1,1,1,1,1,1,2,1,1,1,1,1 }));
            Console.WriteLine(Stray(new[] { 2,1,1,1,1,1,1,1,1,1,1,1 }));
            Console.WriteLine(Stray(new[] { 1,1,1,1,1,1,1,1,1,1,1,2 }));
        }

        static int Stray(int[] numbers)
        {
            Array.Sort(numbers);
            return numbers[0] == numbers[1] ? numbers[numbers.Length - 1] : numbers[0];
        }
    }
}
