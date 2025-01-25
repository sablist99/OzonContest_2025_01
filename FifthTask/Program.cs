namespace FifthTask
{
    public class Program
    {
        public class Truck
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int Capacity { get; set; }
        }

        public class TestCase
        {
            public int OrdersCount { get; set; }
            public List<int> ArrivalTimes { get; set; } = new();
            public int TrucksCount { get; set; }
            public List<Truck> Trucks { get; set; } = new();
        }

        public static void Main()
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());

            int testCount = GetNumber(input);
            while (testCount-- > 0)
            {
                TestCase testCase = new()
                {
                    OrdersCount = GetNumber(input),

                    ArrivalTimes = GetLine(input).Select(int.Parse).ToList(),

                    TrucksCount = GetNumber(input)
                };

                for (int truckIndex = 0; truckIndex < testCase.TrucksCount; truckIndex++)
                {
                    int[] truck = GetLine(input).Select(int.Parse).ToArray();
                    testCase.Trucks.Add(new Truck
                    {
                        Start = truck[0],
                        End = truck[1],
                        Capacity = truck[2]
                    });
                }


                string result = string.Join(" ", FillTrucks(testCase));
                Console.Write(result);

                Console.WriteLine();
            }
        }

        public static int[] FillTrucks(TestCase testCase)
        {
            int[] result = new int[testCase.OrdersCount];

            var sortedArrivalTimes = testCase.ArrivalTimes
                .Select((value, index) => new { Value = value, OriginalIndex = index })
                .OrderBy(item => item.Value)
                .ToList();

            var indexedTrucks = testCase.Trucks
                .Select((truck, index) => new { Truck = truck, OriginalIndex = index })
                .ToList();

            // Перебираем все отсортированные заказы
            foreach (var order in sortedArrivalTimes)
            {
                // Для каждого определяем машины, которые находятся в пункте со свободным местом
                // Если таких несколько - выбираем с минимальным индексом
                var trucksInPoint = indexedTrucks
                    .Where(t => t.Truck.Start <= order.Value && t.Truck.End >= order.Value && t.Truck.Capacity != 0)
                    .OrderBy(item => item.Truck.Start)
                    .ThenBy(item => item.OriginalIndex)
                    .ToList();

                if (trucksInPoint.Count != 0)
                {
                    result[order.OriginalIndex] = trucksInPoint[0].OriginalIndex + 1;

                    indexedTrucks.Where(t => t.OriginalIndex == trucksInPoint[0].OriginalIndex).First().Truck.Capacity--;
                }
                else
                {
                    result[order.OriginalIndex] = -1;
                }
            }

            return result;
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }

        private static int GetNumber(StreamReader input) =>
            int.Parse(GetLine(input)[0]);
    }
}