using System;

namespace P04_LinkedStack
{
    public class LinkedStack<T>
    {
        private Node firstNode;

        public int Count { get; private set; }

        public void Push(T element) 
        {
            this.firstNode = new Node(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.firstNode.value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return element;
        }

        public T[] ToArray() 
        {
            var arr = new T[this.Count];
            var current = this.firstNode;
            var index = 0;

            while (current != null)
            {
                arr[index++] = current.value;
                current = current.NextNode;
            }

            return arr;
        }

        private class Node
        {
            public T value;

            public Node(T value, Node nextNode = null)
            {
                this.value = value;
                this.NextNode = nextNode;
            }

            public Node NextNode { get; set; }
        }
    }
}
