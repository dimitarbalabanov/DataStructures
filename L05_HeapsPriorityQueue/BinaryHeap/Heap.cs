namespace BinaryHeap
{
    using System;

    public static class Heap<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2; i >= 0; i--)
            {
                HeapifyDown(arr, i, arr.Length);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                HeapifyDown(arr, 0, i);
            }
        }

        private static void HeapifyDown(T[] arr, int current, int border)
        {
            while (current < border / 2)
            {
                int child = (current * 2) + 1;
                if (child + 1 < border && IsGreater(arr, child, child + 1))
                {
                    child += 1;
                }

                if (IsGreater(arr, current, child))
                {
                    Swap(arr, child, current);
                }

                current = child;
            }
        }
        private static void Swap(T[] arr, int a, int b)
        {
            T temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        private static bool IsGreater(T[] arr, int a, int b)
        {
            return arr[a].CompareTo(arr[b]) < 0;
        }
    }
}
