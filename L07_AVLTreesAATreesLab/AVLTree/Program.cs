﻿namespace AVLTree
{
    public class Program
    {
        public static void Main()
        {
            AVL<int> tree = new AVL<int>();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
        }
    }
}
