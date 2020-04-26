namespace P05_CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountOfOccurrences
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var numsAndCount = new Dictionary<int, int>();

            foreach (var num in numbers)
            {
                if (!numsAndCount.ContainsKey(num))
                {
                    numsAndCount[num] = 0;
                }

                numsAndCount[num]++;
            }

            foreach (var kvp in numsAndCount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
            }
        }
    }
}
