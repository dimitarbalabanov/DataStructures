namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            this.Copy(node);
        }

        private void Copy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.Copy(node.Left);
            this.Copy(node.Right);
        }

        public void Insert(T value)
        {
            this.root = this.Insert(this.root, value);
            // iterative
            //if (this.root == null)
            //{
            //    this.root = new Node(value);
            //    return;
            //}

            //Node parent = null;
            //Node current = this.root;
            //while (current != null)
            //{
            //    int compare = current.Value.CompareTo(value);

            //    if (compare > 0)
            //    {
            //        parent = current;
            //        current = current.Left;
            //    }
            //    else if (compare < 0)
            //    {
            //        parent = current;
            //        current = current.Right;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            //Node newNode = new Node(value);
            //int compare2 = value.CompareTo(parent.Value);

            //if (compare2 < 0)
            //{
            //    parent.Left = newNode;
            //}
            //else
            //{
            //    parent.Right = newNode;
            //}
        }

        private Node Insert(Node node, T value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            int compare = node.Value.CompareTo(value);
            if (compare > 0)
            {
                node.Left = this.Insert(node.Left, value);
            }
            else if (compare < 0)
            {
                node.Right = this.Insert(node.Right, value);
            }

            return node;
        }

        public bool Contains(T value)
        {
            var current = this.root;
            while (current != null)
            {
                int compare = value.CompareTo(current.Value);

                if (compare < 0)
                {
                    current = current.Left;
                }
                else if (compare > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                return;
            }

            if (this.root.Left == null && this.root.Right == null)
            {
                this.root = null;
                return;
            }

            Node parent = null;
            Node current = this.root;

            while (current.Left != null)
            {
                parent = current;
                current = current.Left;
            }

            if (current.Right != null)
            {
                parent.Left = current.Right;
            }
            else
            {
                parent.Left = null;
            }
        }

        public BinarySearchTree<T> Search(T item)
        {
            Node current = this.root;

            while (current != null)
            {
                int compare = current.Value.CompareTo(item);
                if (compare > 0)
                {
                    current = current.Left;
                }
                else if (compare < 0)
                {
                    current = current.Right;
                }
                else if (compare == 0)
                {
                    return new BinarySearchTree<T>(current);
                }
            }

            return null;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            throw new NotImplementedException();
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(node.Left, action);

            action(node.Value);

            EachInOrder(node.Right, action);
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
