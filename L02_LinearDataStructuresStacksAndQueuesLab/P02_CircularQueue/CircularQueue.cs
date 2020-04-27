namespace P02_CircularQueue
{
    using System;

    public class CircularQueue<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;

        private int startIndex = 0;

        private int endIndex = 0;

        public CircularQueue(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.elements[startIndex];
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;
            return element;
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            this.CopyAllElements(arr);
            return arr;
        }

        private void Grow()
        {
            var newArray = new T[this.elements.Length * 2];
            this.CopyAllElements(newArray);
            this.elements = newArray;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void CopyAllElements(T[] newArray)
        {
            int sourceIndex = this.startIndex;
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.elements.Length;
            }
        }
    }
}
