using FirstTask;

namespace UnitTest
{
    public class FirstTask
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
        public void Test1(string input, string expected)
        {
            // Act
            string result = Program.CalculateSalary(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}