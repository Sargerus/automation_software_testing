using OpenQA.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace PageObject.PageObjects
{
    public class RegionPage
    {
        private IWebDriver driver;

        public RegionPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//table[1]//tbody/tr[1]/td[4]")]
        private IWebElement regionElement;

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.iplocation.net/");
        }

        public string getRegion()
        {
            return regionElement.Text;
        }
    }
}
