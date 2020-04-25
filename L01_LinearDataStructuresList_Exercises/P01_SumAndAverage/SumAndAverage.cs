namespace P01_SumAndAverage
{
    using System;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            Func<double,double,string> getResult = (first, second) => $"Sum={first}; Average={second:f2}";
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(getResult(0,0));
            }

            var numbers = input
                .Split()
                .Select(int.Parse)
                .ToList();

            double sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }

            double avg = sum / numbers.Count;
            Console.WriteLine(getResult(sum, avg));
        }
    }
}
