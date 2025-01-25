namespace SecondTask
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

                Console.Write(CheckSystem(secondString[0]));

                Console.WriteLine();
            }
        }

        public static string CheckSystem(string inputString)
        {
            // Упреждающая проверка
            if (inputString[0].CompareTo('M') != 0 || inputString[^1].CompareTo('D') != 0)
            {
                return "NO";
            }

            // Рассматриваем каждый символ и проверяем его соответсвие стейтмашине
            // Первый символ игнориеруем, так как он уже прошел валидацию
            for (int i = 1; i < inputString.Length; i++)
            {
                // Ищем первый минимальный экстремум
                // Запоминаем индекс первой цифры, после которой идет бОльшая цифра
                if (!CheckViaStateMachine(inputString[i - 1], inputString[i]))
                {
                    return "NO";
                }
            }

            return "YES";
        }

        private static bool CheckViaStateMachine(char first, char second)
        {
            return first switch 
            {
                'M' => second switch
                {
                    'R' => true,
                    'C' => true,
                    'D' => true,
                    _ => false
                },
                'R' => second switch
                {
                    'C' => true,
                    _ => false
                },
                'C' => second switch
                {
                    'M' => true,
                    _ => false
                },
                'D' => second switch
                {
                    'M' => true,
                    _ => false
                },
                _ => false
            };
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }
    }
}
