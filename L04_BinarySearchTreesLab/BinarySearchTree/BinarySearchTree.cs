namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> 
        where T : IComparable<T>
    {
        private Node root;

        public void Insert(T value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public BinarySearchTree<T> Search(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            throw new NotImplementedException();
        }

        public void EachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        private class Node
        {
            public Node(T value, Node left = null, Node right = null)
            {
                this.Value = value;
                this.Left = left;
                this.Right = right;
            }

            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }
    }
}
