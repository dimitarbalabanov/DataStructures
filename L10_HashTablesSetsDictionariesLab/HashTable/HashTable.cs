namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int InitialCapacity = 16;

        private const float LoadFactor = 0.75f;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public int Count { get; private set; }

        public int Capacity
        {
            get => this.slots.Length;
        }

        public HashTable(int capacity = InitialCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            GrowIfNeeded();

            int slotNumber = this.FindSlotNumber(key);
            if (this.slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            if (this.slots[slotNumber].Any(x => x.Key.Equals(key)))
            {
                throw new ArgumentException("Key already exists: " + key);
            }

            var element = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotNumber].AddLast(element);
            this.Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            GrowIfNeeded();

            int slotNumber = this.FindSlotNumber(key);
            if (this.slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var elem in this.slots[slotNumber])
            {
                if (elem.Key.Equals(key))
                {
                    elem.Value = value;
                    return false;
                }
            }

            var element = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotNumber].AddLast(element);
            this.Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            var element = this.Find(key);
            if (element == null)
            {
                throw new KeyNotFoundException();
            }

            return element.Value;
        }

        public TValue this[TKey key]
        {
            get => this.Get(key);
            set => this.AddOrReplace(key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);
            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default;
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];

            if (elements != null)
            {
                foreach (var elem in elements)
                {
                    if (elem.Key.Equals(key))
                    {
                        return elem;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            var element = this.Find(key);
            return element != null;
        }

        public bool Remove(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];

            if (elements != null)
            {
                var current = elements.First;
                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        elements.Remove(current);
                        this.Count--;
                        return true;
                    }
                    current = current.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys
        {
            get => this.Select(x => x.Key);
        }

        public IEnumerable<TValue> Values
        {
            get => this.Select(x => x.Value);
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var slot in this.slots)
            {
                if (slot != null)
                {
                    foreach (var element in slot)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void GrowIfNeeded()
        {
            var currentLoadFactor = (float)(this.Count + 1) / this.Capacity;
            if (currentLoadFactor > LoadFactor)
            {
                Grow();
            }
        }

        private void Grow()
        {
            var newTable = new HashTable<TKey, TValue>(this.Capacity * 2);
            foreach (var elem in this)
            {
                newTable.Add(elem.Key, elem.Value);
            }

            this.slots = newTable.slots;
            this.Count = newTable.Count;
        }

        private int FindSlotNumber(TKey key)
        {
            var slotNumber = Math.Abs(key.GetHashCode()) % this.slots.Length;
            return slotNumber;
        }
    }
}
