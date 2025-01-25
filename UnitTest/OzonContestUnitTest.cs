namespace UnitTest
{
    public class OzonContestUnitTest
    {
        [Theory]
        [InlineData("20000", "2000")]
        [InlineData("9", "0")]
        [InlineData("0", "0")]
        [InlineData("9123", "923")]
        [InlineData("12345", "2345")]
        [InlineData("54321", "5432")]
        [InlineData("51234", "5234")]
        [InlineData("999999999999999999999999999999999999999999999999999999999999999999999999999999999", "99999999999999999999999999999999999999999999999999999999999999999999999999999999")]
        public void FirstTaskUnitTest(string input, string expected)
        {
            // Act
            string result = FirstTask.Program.CalculateSalary(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("MD", "YES")]
        [InlineData("M", "NO")]
        [InlineData("D", "NO")]
        [InlineData("MMDD", "NO")]
        [InlineData("MRCMD", "YES")]
        [InlineData("MDD", "NO")]
        [InlineData("MDMRCMD", "YES")]
        public void SecondTaskUnitTest(string input, string expected)
        {
            // Act
            string result = SecondTask.Program.CheckSystem(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, new string[] { "1", "2" }, new string[] { "1", "2" }, "YES")]
        [InlineData(1, new string[] { "1", "2" }, new string[] { "1", "2" }, "NO")] // Несоответствие количества чисел
        [InlineData(1, new string[] { "hello" }, new string[] { "hello" }, "NO")] // Не числа в массиве
        [InlineData(1, new string[] { "1" }, new string[] { "1" }, "YES")]
        [InlineData(3, new string[] { "1", "2" }, new string[] { "1", "2" }, "NO")] // Несоответствие количества чисел
        [InlineData(2, new string[] { "2", "1" }, new string[] { "2", "1" }, "NO")] // Обратная сортировка
        [InlineData(2, new string[] { "-2", "-1" }, new string[] { "-2", "-1" }, "YES")] 
        [InlineData(5, new string[] { "1", "2", "2", "2", "2" }, new string[] { "1", "2", "2", "2", "2" }, "YES")]
        [InlineData(5, new string[] { "1", "2", "2", "3", "4" }, new string[] { "1", "2", "2", "3", "4" }, "YES")]
        [InlineData(5, new string[] { "1", "2", "2", "2", "4" }, new string[] { "1", "2", "2", "3", "4" }, "NO")] // Массивы не совпадают
        [InlineData(5, new string[] { "1", "2", "a", "3", "4" }, new string[] { "1", "2", "a", "3", "4" }, "NO")] // Не числа в массиве
        [InlineData(5, new string[] { "1", "2", "2", "3", "1" }, new string[] { "1", "2", "2", "3", "1" }, "NO")] // Неверная сортировка
        [InlineData(7, new string[] { "-778346189", "-275502133", "-536411402", "-692157805", "83832175", "-733374394", "768051678" }, new string[] { "-778346189", "-733374394", "-692157805", "-536411402", "-275502133", "83832175", "768051678"
 }, "YES")] // Неверная сортировка
        public void ThirdTaskUnitTest(int numberCount, string[] unsortArray, string[] sortArray, string expected)
        {
            // Act
            string result = ThirdTask.Program.CheckSorting(numberCount, unsortArray, sortArray);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestData.GetFourthTaskTestData), MemberType = typeof(TestData))]
        public void FourthTaskUnitTest(FourthTask.Program.Folder folder, string expected)
        {
            // Act
            string result = FourthTask.Program.FindInfectedFiles(folder).ToString();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}