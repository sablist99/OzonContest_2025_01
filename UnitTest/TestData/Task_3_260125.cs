using static FourthTask.Program;

namespace UnitTest.TestData
{
    public static partial class TestData
    {
        public static IEnumerable<object[]> Get_Task_3_260125_TestData()
        {
            yield return new object[]
            {
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "3" },
                "a:1,c:3,b:2",
                "YES"
            };

            yield return new object[]
{
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "3" },
                "a:1c:3,b:2",
                "NO"
};

            yield return new object[]
{
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "1", "1" },
                ":a:1",
                "NO"
};

            yield return new object[]
            {
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "2" },
                "c:2,a:1",
                "YES"
            };

            yield return new object[]
            {
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "2" },
                "b:2,c:2",
                "NO"
            };

            yield return new object[]
{
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "2" },
                "a:1,a:1,a:1,a:1",
                "NO"
};

            yield return new object[]
{
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "2" },
                "b:1",
                "NO"
};

            yield return new object[]
{
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "2" },
                "d:4,a:1,c:2",
                "NO"
};

            yield return new object[]
{
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "2" },
                "abcdef",
                "NO"
};

            yield return new object[]
{
                new List<string> {"a", "b", "c" },
                new List<string> {"1", "2", "2" },
                "a:12345678901234567890,c:2",
                "NO"
};

            yield return new object[]
{
                new List<string> {"a" },
                new List<string> {"123" },
                "abc:0123",
                "NO"
};

            yield return new object[]
{
                new List<string> {"m", "ktpbozzp", "mal", "gyqeph", "ifanklld", "lhpakyteoq"  },
                new List<string> {"142656574", "245928639", "681772084", "245928639", "245928639", "142656574" },
                "mal:681772084,lhpakyteoq:142656574,lhpakyteoq:142656574,ktpbozzp:245928639",
                "NO"
};

            

        }
    }
}
