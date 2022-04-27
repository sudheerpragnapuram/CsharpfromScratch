using NUnit.Framework;

namespace NunitFramework
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine(" This is pre request");

        }

        [Test]
        public void Test1()
        {

            TestContext.Progress.WriteLine("This is functional 1");

        }

        [Test]
        public void Test2()
        { 
        TestContext.Progress.WriteLine("This is funtional Test2");
        }

        [TearDown]

        public void Closebrowser()
        {
            TestContext.Progress.WriteLine("This is Post request");
        }

       


    }
}