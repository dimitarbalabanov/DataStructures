namespace P06_ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 2;

        private T[] items;

        public ReversedList(int capacity = InitialCapacity)
        {
            this.Capacity = capacity;
            this.items = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public T this[int index]
        {
            get
            {
                this.CheckIndex(index);
                return this.items[this.Count - 1 - index];
            }

            set
            {
                this.CheckIndex(index);
                this.items[this.Count - 1 - index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count >= this.Capacity)
            {
                this.Grow();
            }

            this.items[this.Count++] = item;
        }

        public T RemoveAt(int index)
        {
            T element = this.items[index];
            for (int i = this.Count - index - 1; i < this.Count - 1; i++)
            {
                this.items[i] = items[i + 1];
            }

            this.Count--;
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Grow()
        {
            T[] newArray = new T[this.Capacity * 2];
            Array.Copy(this.items, newArray, this.Count);
            this.items = newArray;
            this.Capacity *= 2;
        }
    }
}