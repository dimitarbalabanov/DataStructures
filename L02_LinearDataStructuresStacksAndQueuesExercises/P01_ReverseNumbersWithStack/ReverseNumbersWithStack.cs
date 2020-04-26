namespace P01_ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbersWithStack
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();
            foreach (var num in numbers)
            {
                stack.Push(num);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = stack.Pop();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
