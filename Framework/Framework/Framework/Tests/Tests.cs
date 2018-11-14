using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tests
{
    [TestFixture]
    public class Tests
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

        //[Test] //Test #1
        //public void CheckLanguage()
        //{
        //    string region = steps.GetRegion();
        //    bool success = steps.CheckLanguage(region);

        //    Assert.AreEqual(success, true);
        //}

        //[Test] //Test #2
        //public void CheckBeachRest()
        //{
        //   bool success = steps.CheckBeachRest();

        //   Assert.AreEqual(success, true);
        //} 

        //[Test] //Test #3
        //public void CheckFilters()
        //{
        //   bool success = steps.ApplyFilersAndCheckResult("Москва");
        //    Assert.AreEqual(success, true);
        //}

        //[Test] //Test #4
        //public void TestOrderSite()
        //{
        //    bool success = steps.CheckBeachRest();
        //    success = steps.CheckResulredList();
        //}

        //[Test] //Test #5
        //public void TestHotels()
        //{
        //    bool success = steps.ApplyFilersAndCheckResult("Москва");
        //    success = steps.OpenHotelPageFromSearch();
        //    success = steps.TestTwoStarHotels();
        //    Assert.AreEqual(success, true);
        //}

        [Test] //Test #6
        public void TestSimulteniousOrdering()
        {

            bool success = this.steps.ApplyFilersAndCheckResult("Москва (MOW)");
            success = this.steps.goToOZONOrderPage();

        }
    }
}
