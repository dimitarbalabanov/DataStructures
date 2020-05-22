namespace Trie
{
    using System;
    using System.Collections.Generic;

    public class Trie<T>
    {
        private Node root;

        public T GetValue(string key)
        {
            var node = GetNode(this.root, key, 0);
            if (node == null || !node.IsTerminal)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        public bool Contains(string key)
        {
            var node = GetNode(this.root, key, 0);
            return node != null && node.IsTerminal;
        }

        public void Insert(string key, T val)
        {
            this.root = Insert(this.root, key, val, 0);
        }

        public IEnumerable<string> GetByPrefix(string prefix)
        {
            var results = new Queue<string>();
            var node = GetNode(this.root, prefix, 0);

            this.Collect(node, prefix, results);

            return results;
        }

        private Node GetNode(Node x, string key, int d)
        {
            if (x == null)
            {
                return null;
            }

            if (d == key.Length)
            {
                return x;
            }

            Node node = null;
            char c = key[d];

            if (x.Next.ContainsKey(c))
            {
                node = x.Next[c];
            }

            return GetNode(node, key, d + 1);
        }

        private Node Insert(Node x, string key, T val, int d)
        {
            if (x == null)
            {
                x = new Node();
            }

            if (d == key.Length)
            {
                x.Value = val;
                x.IsTerminal = true;
                return x;
            }

            Node node = null;
            char c = key[d];

            if (x.Next.ContainsKey(c))
            {
                node = x.Next[c];
            }

            x.Next[c] = this.Insert(node, key, val, d + 1);
            return x;
        }

        private void Collect(Node node, string prefix, Queue<string> results)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value != null && node.IsTerminal)
            {
                results.Enqueue(prefix);
            }

            foreach (var c in node.Next.Keys)
            {
                Collect(node.Next[c], prefix + c, results);
            }
        }

        private class Node
        {
            public T Value;

            public bool IsTerminal;

            public Dictionary<char, Node> Next = new Dictionary<char, Node>();
        }
    }
}
