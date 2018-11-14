using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class TripFinderPage
    {
        private IWebDriver driver;
        private const string PAGE_URL = "https://www.momondo.by/trip-finder/";

        [FindsBy(How = How.XPath, Using = "//div[@data-option-id='2']")]
        private IWebElement beach;

        private List<IWebElement> searchresult;

        public TripFinderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
        }

        public void selectRestTypeBeach()
        {
            goToPage();
            beach.Click();
        }

        public bool CheckResultedList()
        {
            bool success = true;
            //TODO change minsk to list
            Thread.Sleep(2000);
            var searchresult = driver.FindElements(By.XPath("//span[@class='city']"));
            var city = searchresult.Where(g => g.Text.Equals("Минск")).Select(g => g).First();

            if (city != null)
                success = false;

            return success;
        }

        public bool checkFirstfromResultedList()
        {
            bool success = true;

            IWebElement url = driver.FindElement(By.XPath("//div[@id='resultlist']/div/div/div/a"));
            string cityto = driver.FindElement(By.XPath("//span[@class='city']")).Text;
            driver.Navigate().GoToUrl(url.GetAttribute("href"));

            string newcityto = driver.FindElement(By.XPath("//div[@id='ExplorerEditorial']/div/div/h2/em")).Text;
            if (!newcityto.StartsWith(cityto))
                success = false;

            return success;
        }
    }
}
