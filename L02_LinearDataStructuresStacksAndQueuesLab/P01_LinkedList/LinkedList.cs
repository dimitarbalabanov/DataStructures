namespace P01_LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newHead = new Node(item);

            if (this.Count == 0)
            {
                this.Head = this.Tail = newHead;
            }
            else
            {
                var oldHead = this.Head;
                this.Head = newHead;
                this.Head.Next = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newTail = new Node(item);

            if (this.Count == 0)
            {
                this.Head = this.Tail = newTail;
            }
            else
            {
                var oldTail = this.Tail;
                this.Tail = newTail;
                oldTail.Next = this.Tail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.Head.Value;
            if (this.Count == 1)
            {
                this.Head = this.Tail = null;
            }
            else
            {
                this.Head = this.Head.Next;
            }

            this.Count--;
            return element;

        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.Tail.Value;
            if (this.Count == 1)
            {
                this.Head = this.Tail = null;
            }
            else
            {
                var newTail = this.GetSecondToLast();
                newTail.Next = null;
                this.Tail = newTail;
            }

            this.Count--;
            return element;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node Next { get; set; }
        }

        private Node GetSecondToLast()
        {
            var current = this.Head;
            while (current.Next != this.Tail)
            {
                current = current.Next;
            }

            return current;
        }
    }
}
