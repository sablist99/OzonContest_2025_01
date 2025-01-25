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
            if (inputString.Length == 1)
            {
                return "0";
            }

            // По умолчанию удаляем последнюю цифру
            // Если индекс не был найден, значит цифры все время уменьшались или были равны
            int targetIndex = inputString.Length - 1;

            for (int i = 1; i < inputString.Length; i++)
            {
                // Ищем первый минимальный экстремум
                // Запоминаем индекс первой цифры, после которой идет бОльшая цифра
                if (inputString[i - 1] < inputString[i])
                {
                    targetIndex = i - 1;
                    break;
                }
            }

            // Формируем итоговую зарплату
            string result = string.Concat(inputString.Where((_, i) => i != targetIndex));

            return result;
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }
    }
}
