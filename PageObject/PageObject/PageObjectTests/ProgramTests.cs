
using PageObject.PageObjects;

namespace PageObject.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void checkpageregionTest()
        {
            if (Program.checkpageregion() == false)
                Assert.Fail("lox");
        }
    }
}