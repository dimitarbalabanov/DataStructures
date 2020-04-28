namespace P04_LinkedStack
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            Console.WriteLine(string.Join(" ", stack.ToArray()));
        }
    }
}
