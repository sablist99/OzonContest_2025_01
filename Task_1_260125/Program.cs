namespace Task_1_260125
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
                string[] inputString = GetLine(input);
                int a = int.Parse(inputString[0]);
                int b = int.Parse(inputString[1]);

                string[] result = GetLocation(a, b);
                int answerCount = int.Parse(result[0]);
                Console.WriteLine(answerCount);
                for (int i = 0; i < answerCount; i++) 
                {
                    Console.WriteLine(string.Join(" ", result[1 + 3 * i], result[2 + 3 * i], result[3 + 3 * i]));
                }
                Console.WriteLine();
            }
        }

        public static string[] GetLocation(int a, int b)
        {
            if (a == 1)
            {
                return new string[] { "1", "1", "1", "R" };
            }
            else if (b == 1)
            {
                return new string[] { "1", "1", "1", "D" };
            }
            else
            {
                return new string[] { "2", "1", "1", "D", "1", "2", "R" };
            }
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }
    }
}