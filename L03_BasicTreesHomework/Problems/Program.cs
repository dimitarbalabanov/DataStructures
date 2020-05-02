namespace Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            ReadTree();

            var root = GetRootNode();

            //Console.WriteLine($"Root: {root}");

            //PrintTree(root);

            //FindLeafNodesInIncreasingOrder();

            //FindMiddleNodesInIncreasingOrder();

            //FindDeepestNode();

            //FindLongestPath();

            //P07_AllPathsWithGivenSum
            //int sum = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Paths of sum {sum}:");
            //DFS(root, sum);

            //P08_AllSubtreesWithGivenSum
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine($"Subtrees of sum {sum}:");
            SubtreeDFS(root, sum);
        }

        // P08_AllSubtreesWithGivenSum
        private static int SubtreeDFS(Tree<int> node, int sum)
        {
            int currentSum = node.Value;
            foreach (var child in node.Children)
            {
                currentSum += SubtreeDFS(child, sum);
            }

            if (sum == currentSum)
            {
                List<int> subtree = new List<int>();
                GetSubtree(node, subtree);
                Console.WriteLine(string.Join(" ", subtree));
            }

            return currentSum;
        }

        private static void GetSubtree(Tree<int> node, List<int> result)
        {
            result.Add(node.Value);
            foreach (var child in node.Children)
            {
                GetSubtree(child, result);
            }
        }

        // P07_AllPathsWithGivenSum
        private static void DFS(Tree<int> node, int targetSum, int sum = 0)
        {
            sum += node.Value;
            if (sum == targetSum)
            {
                PrintPath(node);
            }

            foreach (var child in node.Children)
            {
                DFS(child, targetSum, sum);
            }
        }

        private static void PrintPath(Tree<int> node)
        {
            Tree<int> start = node;
            var path = new Stack<int>();
            path.Push(start.Value);

            while (start.Parent != null)
            {
                start = start.Parent;
                path.Push(start.Value);
            }

            Console.WriteLine(string.Join(" ", path));
        }

        // P06_LongestPath
        private static void FindLongestPath()
        {
            var leafNodes = nodeByValue
                .Values
                .Where(x => x.Children.Count == 0)
                .Select(x => x.Value)
                .ToList();

            int maxDepth = 0;
            int nodeValue = GetRootNode().Value;

            foreach (var leaf in leafNodes)
            {
                var currentNode = GetTreeNodeByValue(leaf);
                int currentDepth = 1;

                while (currentNode.Parent != null)
                {
                    currentDepth++;
                    currentNode = currentNode.Parent;
                }

                if (currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                    nodeValue = leaf;
                }
            }

            var current = GetTreeNodeByValue(nodeValue);
            var path = new Stack<int>();

            while (current != null)
            {
                path.Push(current.Value);
                current = current.Parent;
            }

            Console.WriteLine($"Longest path: {string.Join(" ", path)}");
        }

        // P05_DeepestNode
        private static void FindDeepestNode()
        {
            var leafNodes = nodeByValue
                .Values
                .Where(x => x.Children.Count == 0)
                .Select(x => x.Value)
                .OrderBy(x => x);

            int maxDepth = 0;
            int nodeValue = GetRootNode().Value;

            foreach (var leaf in leafNodes)
            {
                var currentNode = GetTreeNodeByValue(leaf);
                int currentDepth = 1;

                while (currentNode.Parent != null)
                {
                    currentDepth++;
                    currentNode = currentNode.Parent;
                }

                if (currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                    nodeValue = leaf;
                }
            }

            Console.WriteLine($"Deepest node: {nodeValue}");
        }

        // P04_MiddleNodes
        private static void FindMiddleNodesInIncreasingOrder()
        {
            var nodes = nodeByValue
                .Values
                .Where(x => x.Children.Count != 0 && x.Parent != null)
                .Select(x => x.Value)
                .OrderBy(x => x);

            Console.WriteLine($"Middle nodes: {string.Join(" ", nodes)}");
        }


        // P03_LeafNodes
        private static void FindLeafNodesInIncreasingOrder()
        {
            var nodes = nodeByValue
                .Values
                .Where(x => x.Children.Count == 0)
                .Select(x => x.Value)
                .OrderBy(x => x);

            Console.WriteLine($"Leaf nodes: {string.Join(" ", nodes)}");
        }

        // P02_PrintTree
        private static void PrintTree(Tree<int> node, int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}{node.Value}");
            foreach (var child in node.Children)
            {
                PrintTree(child, indent + 2);
            }
        }

        // P01_RootNode
        private static Tree<int> GetRootNode()
        {
            var root = nodeByValue
                .FirstOrDefault(x => x.Value.Parent == null)
                .Value;

            return root;
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        private static void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = GetTreeNodeByValue(parent);
            Tree<int> childNode = GetTreeNodeByValue(child);
            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        private static void ReadTree()
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
