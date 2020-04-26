namespace P03_LongestSubsequence
{
    using System;
    using System.Linq;

    public class LongestSubsequence
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxNum = 0;
            int maxCount = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentCount = 1;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxNum = numbers[i];
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxNum + " ");
            }
        }
    }
}
