using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PageObject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
     class Program
    {
        private static IWebDriver driver = new FirefoxDriver();
        private static TestingPage testingpage = new TestingPage(driver);

        public static bool checkpageregion(IWebDriver driver, TestingPage testingpage)
        {
            RegionPage regionpage = new RegionPage(driver);
            regionpage.goToPage();
            string region = regionpage.getRegion();
            testingpage.goToPage();
            string URL = testingpage.getURLByContry(TestingPage.Country.Germany);
            testingpage.goToPage(URL);
            if (testingpage.getPageRegion(region) == null)
                return false;
            return true;
        }

        static void Main(string[] args)
        {
            checkpageregion(driver, testingpage);
        }

       
    }
}
