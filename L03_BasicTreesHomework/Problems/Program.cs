namespace Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            ReadTree();

            var root = GetRootNode();

            PrintTree(root);

            FindLeafNodesInIncreasingOrder();

        }

        // P03_LeafNodes
        public static void FindLeafNodesInIncreasingOrder()
        {
            var nodes = nodeByValue
                .Values
                .Where(x => x.Children.Count == 0)
                .Select(x => x.Value)
                .OrderBy(x => x);

            Console.WriteLine($"Leaf nodes: {string.Join(" ", nodes)}");
        }

        // P02_PrintTree
        public static void PrintTree(Tree<int> node, int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}{node.Value}");
            foreach (var child in node.Children)
            {
                PrintTree(child, indent + 2);
            }
        }

        // P01_RootNode
        public static Tree<int> GetRootNode()
        {
            var root = nodeByValue
                .FirstOrDefault(x => x.Value.Parent == null)
                .Value;

            return root;
        }

        public static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        public static void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = GetTreeNodeByValue(parent);
            Tree<int> childNode = GetTreeNodeByValue(child);
            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        public static void ReadTree()
        {
            int nodeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodeCount - 1; i++)
            {
                string[] edge = Console.ReadLine().Split();
                AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
            }
        }
    }
}
