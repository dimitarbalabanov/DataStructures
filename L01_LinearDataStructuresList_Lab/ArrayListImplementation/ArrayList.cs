namespace ArrayListImplementation
{
    using System;

    public class ArrayList<T>
    {
        private const int InitialCapacity = 2;

        private T[] items;

        public ArrayList()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                this.CheckIndex(index);
                return this.items[index];
            }

            set
            {
                this.CheckIndex(index);
                this.items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count == items.Length)
            {
                this.Resize();
            }

            this.items[this.Count++] = item;
        }

        public T RemoveAt(int index)
        {
            this.CheckIndex(index);
            T element = this.items[index];

            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = items[i + 1];
            }

            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return element;
        }

        private void CheckIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void Resize()
        {
            T[] newArray = new T[2 * this.items.Length];
            Array.Copy(this.items, newArray, this.items.Length);
            this.items = newArray;
        }

        private void Shrink()
        {
            T[] newArray = new T[this.items.Length / 2];
            Array.Copy(this.items, newArray, this.Count);
            this.items = newArray;
        }
    }
}
