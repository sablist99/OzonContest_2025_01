using static FourthTask.Program;

namespace UnitTest.TestData
{
    public static partial class TestData
    {
        public static IEnumerable<object[]> GetFourthTaskTestData()
        {
            yield return new object[]
            {
                new Folder
                {
                    Dir = "root",
                    Files = ["file1.txt", "virus.hack", "file2.doc"],
                    Folders =
                    [
                        new Folder
                        {
                            Dir = "sub1",
                            Files = ["safe.txt", "virus2.hack"],
                            Folders = []
                        },
                        new Folder
                        {
                            Dir = "sub2",
                            Files = ["document.pdf"],
                            Folders =
                            [
                                new Folder
                                {
                                    Dir = "subsub1",
                                    Files = ["important.hack"],
                                    Folders = []
                                }
                            ]
                        }
                    ]
                },
                "7"
            };

            yield return new object[]
            {
                new Folder
                {
                    Dir = "root",
                    Files = [".zshrc"],
                    Folders =
                    [
                        new Folder
                        {
                            Dir = "desktop",
                            Files = ["config.yaml"],
                            Folders = []
                        },
                        new Folder
                        {
                            Dir = "downloads",
                            Files = ["cat.png.hack"],
                            Folders =
                            [
                                new Folder
                                {
                                    Dir = "kta",
                                    Files = ["kta.exe", "kta.hack"],
                                    Folders = []
                                }
                            ]
                        }
                    ]
                },
                "3"
            };

            yield return new object[]
            {
                new Folder
                {
                    Dir = "root",
                    Files = [],
                    Folders = []
                },
                "0"
            };
        }
    }
}
