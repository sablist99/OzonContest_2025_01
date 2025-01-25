using SecondTask;

namespace UnitTest
{
    public class SecondTask
    {
        [Theory]
        [InlineData("MD", "YES")]
        [InlineData("M", "NO")]
        [InlineData("D", "NO")]
        [InlineData("MMDD", "NO")]
        [InlineData("MRCMD", "YES")]
        [InlineData("MDD", "NO")]
        [InlineData("MDMRCMD", "YES")]
        public void Test1(string input, string expected)
        {
            // Act
            string result = Program.CheckSystem(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}