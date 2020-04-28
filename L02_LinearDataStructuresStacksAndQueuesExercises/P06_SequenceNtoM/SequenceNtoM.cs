namespace P06_SequenceNtoM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceNtoM
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var start = input[0];
            var end = input[1];

            if (start > end)
            {
                return;
            }

            var queue = new Queue<Item>();
            queue.Enqueue(new Item(start));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var value = current.Value;

                if (value < end)
                {
                    queue.Enqueue(new Item(value + 1, current));
                    queue.Enqueue(new Item(value + 2, current));
                    queue.Enqueue(new Item(value * 2, current));
                    continue;
                }

                if (value == end)
                {
                    PrintSolution(current);
                    return;
                }
            }

        }

        private static void PrintSolution(Item current)
        {
            var list = new LinkedList<int>();
            while (current != null)
            {
                list.AddFirst(current.Value);
                current = current.PrevItem;
            }

            Console.WriteLine(string.Join(" -> ", list));
        }

        private class Item
        {
            public Item(int value, Item item = null)
            {
                this.Value = value;
                this.PrevItem = item;
            }

            public int Value { get; private set; }

            public Item PrevItem { get; private set; }
        }
    }
}
