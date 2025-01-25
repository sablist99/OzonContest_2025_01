using System.Text.Json;

namespace FourthTask
{
    public class Program
    {
        public class Folder
        {
            public string Dir { get; set; } = string.Empty;
            public List<string> Files { get; set; } = new List<string>();
            public List<Folder> Folders { get; set; } = new List<Folder>();
        }

        public static void Main()
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());

            int testCount = int.Parse(GetLine(input)[0]);
            while (testCount-- > 0)
            {
                int lineCount = int.Parse(GetLine(input)[0]);

                // Считываем описание JSON
                string json = string.Join("\n", ReadLines(input, lineCount));

                // Парсим JSON
                Folder root = JsonSerializer.Deserialize<Folder>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    MaxDepth = 1000
                }) ?? throw new InvalidOperationException("JSON deserialization failed.");

                string result = FindInfectedFiles(root).ToString();
                Console.Write(result);

                Console.WriteLine();
            }
        }

        public static int FindInfectedFiles(Folder root)
        {
            int count = 0;

            bool isInfectedDirectory = false;
            foreach (var file in root.Files)
            {
                // Если хотя бы один файл заражен, то количество зараженных файлов - количество файлов текущей директории и количество файлов в поддиректориях
                if (IsInfectedFile(file))
                {
                    isInfectedDirectory = true;
                    break;
                }
            }

            if (isInfectedDirectory)
            {
                count += GetFilesCount(root);
            }
            else
            {
                foreach (var folder in root.Folders)
                {
                    count += FindInfectedFiles(folder);
                }
            }

            return count;
        }

        private static int GetFilesCount(Folder root)
        {
            int count = root.Files.Count;
            foreach (var folder in root.Folders)
            {
                count += GetFilesCount(folder);
            }
            return count;
        }

        private static bool IsInfectedFile(string fileName)
        {
            return fileName.EndsWith(".hack", StringComparison.OrdinalIgnoreCase);
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }

        private static IEnumerable<string> ReadLines(StreamReader input, int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return input.ReadLine() ?? throw new Exception("Input line cannot be null.");
            }
        }
    }
}