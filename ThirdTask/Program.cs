namespace ThirdTask
{
    public class Program
    {
        public static void Main()
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());

            int testCount = int.Parse(GetLine(input)[0]);
            while (testCount-- > 0)
            {
                int numbersCount = int.Parse(GetLine(input)[0]);

                string[] unsortArray = GetLine(input);

                string[] sortArray = GetLine(input);

                string result = CheckSorting(numbersCount, unsortArray, sortArray);
                Console.Write(result);

                Console.WriteLine();
            }
        }

        public static string CheckSorting(int numbersCount, string[] unsortArray, string[] sortArray)
        {
            // Упреждающие проверки
            // Соответствие введенных чисел и выведенных
            if (numbersCount != sortArray.Length)
                return "NO";

            for (int i = 0; i < sortArray.Length; i++)
            {
                // Проверяем, что работаем с числами
                if (!int.TryParse(sortArray[i], out int currentNumber))
                    return "NO";

                // Проверяем корректность сортировки
                if (i > 0 && int.Parse(sortArray[i - 1]) > currentNumber)
                    return "NO";
            }

            // Проверяем, что массивы содержат одни и те же элементы
            var unsortedCounts = unsortArray.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var sortedCounts = sortArray.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            if (!unsortedCounts.OrderBy(kv => kv.Key).SequenceEqual(sortedCounts.OrderBy(kv => kv.Key)))
            {
                return "NO";
            }

            return "YES";
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }
    }
}