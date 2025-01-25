using static FifthTask.Program;

namespace UnitTest.TestData
{
    public static partial class TestData
    {
        public static IEnumerable<object[]> GetFifthTaskTestData()
        {
            yield return new object[]
            {
               new TestCase
               {
                   OrdersCount = 5,
                   ArrivalTimes = [1, 9, 2, 6, 4],
                   TrucksCount = 3,
                   Trucks = new()
                   {
                       new Truck
                       {
                           Start = 1,
                           End = 8,
                           Capacity = 3
                       },
                       new Truck
                       {
                           Start = 3,
                           End = 10,
                           Capacity = 1
                       },
                       new Truck
                       {
                           Start = 4,
                           End = 7,
                           Capacity = 4
                       },
                   }
               },
                "1 -1 1 2 1"
            };

            yield return new object[]
            {
                new TestCase
                {
                    OrdersCount = 5,
                    ArrivalTimes = [1, 9, 2, 6, 4],
                    TrucksCount = 3,
                    Trucks = new()
                    {
                        new Truck
                        {
                            Start = 1,
                            End = 8,
                            Capacity = 3
                        },
                        new Truck
                        {
                            Start = 3,
                            End = 10,
                            Capacity = 2
                        },
                        new Truck
                        {
                            Start = 4,
                            End = 7,
                            Capacity = 4
                        },
                    }
                },
                "1 2 1 2 1"
            };

            yield return new object[]
            {
                new TestCase
                {
                    OrdersCount = 8,
                    ArrivalTimes = [100, 37, 19, 2, 46, 4, 15, 88],
                    TrucksCount = 4,
                    Trucks = new()
                    {
                        new Truck
                        {
                            Start = 27,
                            End = 80,
                            Capacity = 1
                        },
                        new Truck
                        {
                            Start = 1,
                            End = 46,
                            Capacity = 2
                        },
                        new Truck
                        {
                            Start = 41,
                            End = 83,
                            Capacity = 1
                        },
                        new Truck
                        {
                            Start = 1,
                            End = 75,
                            Capacity = 2
                        },
                    }
                },
                "-1 1 4 2 3 2 4 -1"
            };

            yield return new object[]
            {
                new TestCase
                {
                    OrdersCount = 10,
                    ArrivalTimes = [266594666, 721322441, 195602247, 677420334, 997903220, 631009883, 423214076, 82520165, 61799209, 451144600],
                    TrucksCount = 10,
                    Trucks = new()
                    {
                        new Truck
                        {
                            Start = 194222395,
                            End = 625535954,
                            Capacity = 7
                        },
                        new Truck
                        {
                            Start = 40913171,
                            End = 999410944,
                            Capacity = 1
                        },
                        new Truck
                        {
                            Start = 183392231,
                            End = 625535954,
                            Capacity = 1
                        },
                        new Truck
                        {
                            Start = 625535954,
                            End = 861493475,
                            Capacity = 1
                        },
                        new Truck
                        {
                            Start = 513888498,
                            End = 585631347,
                            Capacity = 2
                        },
                        new Truck
                        {
                            Start = 321876349,
                            End = 625535954,
                            Capacity = 1
                        },
                        new Truck
                        {
                            Start = 585631347,
                            End = 724393571,
                            Capacity = 1
                        },
                        new Truck
                        {
                            Start = 209613940,
                            End = 585631347,
                            Capacity = 10
                        },
                        new Truck
                        {
                            Start = 40913171,
                            End = 310064749,
                            Capacity = 1
                        },
                        new Truck
                        {
                            Start = 357634819,
                            End = 625535954,
                            Capacity = 1
                        },
                    }
                },
                "1 -1 3 4 -1 7 1 9 2 1"
            };
        }
    }
}
