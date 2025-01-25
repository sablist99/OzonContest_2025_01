namespace FirstTask
{
    public class Program
    {
        public static void Main()
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());
            string[] firstString = GetLine(input);

            int testCount = int.Parse(firstString[0]);
            while (testCount-- > 0)
            {
                string[] secondString = GetLine(input);

                Console.Write(CalculateSalary(secondString[0]));

                Console.WriteLine();
            }
        }

        public static string CalculateSalary(string inputString)
        {
            string[] salaryString = inputString.Select(c => c.ToString()).ToArray();

            int leftDigit = int.Parse(salaryString[0].ToString());

            int? targetIndex = null;
            for (int i = 1; i < salaryString.Length; i++)
            {
                int rightDigit = int.Parse(salaryString[i].ToString());

                // Ищем первый минимальный экстремум
                // Запоминаем индекс первой цифры, после которой идет бОльшая цифра
                if (leftDigit < rightDigit)
                {
                    targetIndex = i - 1;
                    break;
                }
                leftDigit = rightDigit;
            }

            // Если индекс не был найден, значит цифры все время уменьшались или были равны. Можно удалять последнюю
            targetIndex ??= salaryString.Length - 1;

            // Формируем итоговую зарплату
            string result = salaryString.Length == 1
                ? "0"
                : string.Concat(salaryString.Where((_, i) => i != targetIndex));

            return result;
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }
    }
}
