namespace P04_RemoveOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveOddOccurrences
    {
        static void Main()
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
                if (kvp.Value % 2 == 1)
                {
                    numbers.RemoveAll(x => x == kvp.Key);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
