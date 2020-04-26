namespace P02_CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(input);

            var result = new int[50];
            for (int i = 0; i < 50; i++)
            {
                var current = queue.Dequeue();
                result[i] = current;
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
