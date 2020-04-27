namespace P03_ImplementArrayBasedStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;

        public ArrayStack(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count++] = element;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.elements[--this.Count];
            return element;
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                arr[i] = this.elements[this.Count - 1 - i];
            }

            return arr;
        }

        private void Grow()
        {
            var newArray = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newArray, this.Count);
            this.elements = newArray;
        }
    }
}
