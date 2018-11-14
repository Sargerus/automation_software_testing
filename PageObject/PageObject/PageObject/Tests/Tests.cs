using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PageObject.Tests
{
    [TestFixture]
    class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void SetUp()
        {
            steps.InitBrowser();     
        }

        [TearDown]
        public void CleanUp()
        {
            steps.CloseBrowser();
        }

        [Test] //Test #1
        public void CheckLanguage()
        {
            string region = steps.GetRegion();
            bool success = steps.CheckLanguage(region);

            Assert.AreEqual(success, true);
        }
    }
}
