namespace P05_LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode head;

        private QueueNode tail;

        public int Count { get; private set; }

        public void Enqueue(T element) 
        {
            var node = new QueueNode(element);
            if (this.Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                this.tail.NextNode = node;
                node.PrevNode = this.tail;
                this.tail = node;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.head.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
                this.head.PrevNode = null;
            }

            this.Count--;
            return element;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            var index = 0;

            var current = this.head;
            while (current != null)
            {
                var element = current.Value;
                current = current.NextNode;
                array[index++] = element;
            }

            return array;
        }

        private class QueueNode
        {
            public QueueNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public QueueNode NextNode { get; set; }

            public QueueNode PrevNode { get; set; }
        }
    }
}
