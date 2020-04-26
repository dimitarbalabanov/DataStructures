namespace P07_DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class DistanceInLabyrinth
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            string[,] matrix = ReadMatrix(size);

            bool[,] visitedMatrix = new bool[size, size];

            int row = 0;
            int col = 0;

            bool isFound = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == "*")
                    {
                        row = i;
                        col = j;
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(new Cell(row, col, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visitedMatrix[current.Row, current.Col] = true;

                row = current.Row;
                col = current.Col;
                if (matrix[row, col] != "*")
                {
                    matrix[row, col] = current.Moves.ToString();
                }

                if (row - 1 >= 0 && matrix[row - 1, col] != "x" && !visitedMatrix[row - 1, col])
                {
                    queue.Enqueue(new Cell(row - 1, col, current.Moves + 1));
                }

                if (row + 1 < size && matrix[row + 1, col] != "x" && !visitedMatrix[row + 1, col])
                {
                    queue.Enqueue(new Cell(row + 1, col, current.Moves + 1));
                }

                if (col - 1 >= 0 && matrix[row, col - 1] != "x" && !visitedMatrix[row, col - 1])
                {
                    queue.Enqueue(new Cell(row, col - 1, current.Moves + 1));
                }

                if (col + 1 < size && matrix[row, col + 1] != "x" && !visitedMatrix[row, col + 1])
                {
                    queue.Enqueue(new Cell(row, col + 1, current.Moves + 1));
                }
            }

            PrintMatrix(matrix);
        }

        private static string[,] ReadMatrix(int size)
        {
            string[,] matrix = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = line[j].ToString();
                }
            }

            return matrix;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "*")
                    {
                        Console.Write("*");
                    }
                    else if (matrix[i, j] == "0")
                    {
                        Console.Write("u");
                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
