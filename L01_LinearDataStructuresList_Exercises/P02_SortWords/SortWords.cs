namespace P02_SortWords
{
    using System;
    using System.Linq;

    public class SortWords
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToList();
            var sortedInput = input.OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(" ", sortedInput));
        }
    }
}
