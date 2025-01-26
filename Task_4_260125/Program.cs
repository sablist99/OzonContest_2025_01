namespace Task_4_260125
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

                // Словари для хранения четных и нечетных индексов
                Dictionary<int, List<int>> even = new();
                Dictionary<int, List<int>> odd = new();
                HashSet<(int, int)> pairs = new();

                int wordCount = int.Parse(GetLine(input)[0]);
                string[] words = new string[wordCount];
                for (int i = 0; i < words.Length; i++)
                {
                    string currentWord = GetLine(input)[0];

                    var evenChars = new List<char>(currentWord.Length / 2 + 1);
                    var oddChars = new List<char>(currentWord.Length / 2 + 1);

                    for (int index = 0; index < currentWord.Length; index++)
                    {
                        if (index % 2 == 0)
                            evenChars.Add(currentWord[index]);
                        else
                            oddChars.Add(currentWord[index]);
                    }

                    // Сортировка и создание ключей
                    int evenKeyHash = GetHash(evenChars);
                    int oddKeyHash = GetHash(oddChars);

                    // Обновляем словари для подсчета вхождений
                    if (evenKeyHash != 0)
                    {
                        if (!even.TryGetValue(evenKeyHash, out var list))
                        {
                            list = new List<int>();
                            even[evenKeyHash] = list;
                        }
                        foreach (var l in list)
                        {
                            pairs.Add((l, i));
                            pairs.Add((i, l));
                        }
                        list.Add(i);
                    }

                    if (oddKeyHash != 0)
                    {
                        if (!odd.TryGetValue(oddKeyHash, out var list))
                        {
                            list = new List<int>();
                            odd[oddKeyHash] = list;
                        }
                        foreach (var l in list)
                        {
                            pairs.Add((l, i));
                            pairs.Add((i, l));
                        }
                        list.Add(i);
                    }
                }

                Console.WriteLine(pairs.Count / 2);
            }
        }

        private static int GetHash(List<char> chars)
        {
            // Сортировка символов, чтобы игнорировать порядок
            var sortedChars = chars.OrderBy(c => c).ToList();

            int hash = 0;
            foreach (var c in sortedChars)
            {
                hash = (hash * 31) ^ c.GetHashCode();  // Простой алгоритм хеширования
            }
            return hash;
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }
    }
}
