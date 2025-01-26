using System.Text.RegularExpressions;

namespace Task_3_260125
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
                int productCount = int.Parse(GetLine(input)[0]);

                Dictionary<string, string> namePriceMap = new();
                HashSet<int> uniquePrices = new();

                // Чтение всех товаров
                while (productCount-- > 0)
                {
                    string[] strings = GetLine(input);
                    namePriceMap[strings[0]] = strings[1];
                    uniquePrices.Add(int.Parse(strings[1]));
                }

                string outputString = GetLine(input)[0];
                string result = CheckString(namePriceMap, uniquePrices, outputString);
                Console.WriteLine(result);
            }
        }

        public static string CheckString(Dictionary<string, string> namePriceMap, HashSet<int> uniquePrices, string outputString)
        {
            // Парсим строку
            (bool isValid, List<(string, string)> output) = ParseString(outputString);
            if (!isValid)
                return "NO";

            // Проверка на уникальность
            HashSet<string> hashSetItem1 = new HashSet<string>();
            HashSet<string> hashSetItem2 = new HashSet<string>();

            foreach (var item in output)
            {
                hashSetItem1.Add(item.Item1);
                hashSetItem2.Add(item.Item2);
            }

            // Если есть дубли в паре: имена или цены
            if (output.Count != hashSetItem1.Count || output.Count != hashSetItem2.Count)
                return "NO";

            // Проверяем соответствие и уникальность цен
            foreach (var item in output)
            {
                if (!namePriceMap.ContainsKey(item.Item1) || namePriceMap[item.Item1] != item.Item2)
                    return "NO";

                if (item.Item2[0] == '0') // Проверка на ведущий ноль
                    return "NO";

                // Удаляем цену из набора уникальных
                uniquePrices.Remove(int.Parse(item.Item2));
            }

            // Если не все цены были использованы, возвращаем NO
            if (uniquePrices.Count != 0)
                return "NO";

            return "YES";
        }

        public static (bool isValid, List<(string letters, string number)> pairs) ParseString(string input)
        {
            var pairs = new List<(string letters, string number)>();

            // Разделяем строку по запятой
            var items = input.Split(',');

            // Используем регулярное выражение для каждой пары
            var regex = new Regex(@"^([a-zA-Z]+):(\d+)$");
            foreach (var item in items)
            {
                var match = regex.Match(item);
                if (!match.Success)
                    return (false, pairs); // Если хотя бы одна пара не совпадает, возвращаем false

                string letters = match.Groups[1].Value;
                string number = match.Groups[2].Value;
                pairs.Add((letters, number));
            }

            return (true, pairs);
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }
    }
}
