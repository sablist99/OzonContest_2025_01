namespace Task_2_260125
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
                string numberString = inputString[0];

                int result = GetPictureCount(numberString);
                Console.WriteLine(result);
            }
        }

        public static int GetPictureCount(string numberString)
        {
            // На каждый завершенный разряд - 10 карточек
            // Если число из digitCount - 1 разрядов, состоящее из первой цифры меньше либо равно правым разрядам исходного числа, то N, иначе N - 1

            int digitCount = numberString.Length;
            int number = int.Parse(numberString);

            if (digitCount == 1) 
            {
                return number + 1;
            }

            int firstDigit = int.Parse(numberString[0].ToString());

            int rightPartNumber = number - firstDigit * (int)Math.Pow(10, digitCount - 1);

            int borderNumber = 0;
            
            for (int i = 1; i < digitCount; i++)
            {
                borderNumber += firstDigit * (int)Math.Pow(10, i - 1);
            }

            return ((digitCount - 1) * 10) + (rightPartNumber >= borderNumber ? firstDigit : firstDigit - 1);
        }

        private static string[] GetLine(StreamReader input)
        {
            return (input.ReadLine()?.Split()) ?? throw new Exception();
        }
    }
}
