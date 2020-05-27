namespace P02_KdTree
{
    using System;

    public class KdTree
    {
        private Node root;

        public Node Root
        {
            get => this.root;
        }

        public bool Contains(Point2D point)
        {
            var current = this.root;
            int depth = 0;
            while (current != null)
            {
                int cmp = this.Compare(point, current.Point, depth);
                if (cmp < 0)
                {
                    current = current.Left;
                }
                else if (cmp > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return true;
                }

                depth++;
            }

            return false;
        }

        public void Insert(Point2D point)
        {
            this.root = this.Insert(this.root, point, 0);
        }

        public void EachInOrder(Action<Point2D> action)
        {
            this.EachInOrder(this.root, action);
        }

        private Node Insert(Node node, Point2D point, int depth)
        {
            if (node == null)
            {
                return new Node(point);
            }

            int cmp = this.Compare(point, node.Point, depth);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }

            return node;
        }

        private int Compare(Point2D a, Point2D b, int depth)
        {
            int cmp;
            if (depth % 2 == 0)
            {
                cmp = a.X.CompareTo(b.X);
                if (cmp == 0)
                {
                    cmp = a.Y.CompareTo(b.Y);
                }

                return cmp;
            }
            else
            {
                cmp = a.Y.CompareTo(b.Y);
                if (cmp == 0)
                {
                    cmp = a.X.CompareTo(b.X);
                }
            }

            return cmp;
        }

        private void EachInOrder(Node node, Action<Point2D> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Point);
            this.EachInOrder(node.Right, action);
        }

        public class Node
        {
            public Point2D Point { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public Node(Point2D point)
            {
                this.Point = point;
            }
        }
    }
}
