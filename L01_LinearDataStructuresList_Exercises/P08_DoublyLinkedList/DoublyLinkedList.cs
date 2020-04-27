namespace P08_DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var newHead = new ListNode(element);
            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PrevNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            var newTail = new ListNode(element);
            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                this.tail.NextNode = newTail;
                newTail.PrevNode = this.tail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
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

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.tail.Value;
            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.PrevNode;
                this.tail.NextNode = null;
            }

            this.Count--;
            return element;
        }

        public void ForEach(Action<T> action)
        {
            var current = this.head;
            while (current != null)
            {
                action(current.Value);
                current = current.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            var index = 0;
            foreach (var item in this)
            {
                array[index++] = item;
            }

            return array;
        }

        private class ListNode
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PrevNode { get; set; }
        }
    }
}
