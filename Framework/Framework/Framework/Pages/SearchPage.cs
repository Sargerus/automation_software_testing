using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;
        
        public string departdate;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage(string destination)
        {
            MainPage main = new MainPage(driver);
            main.goToPage();
            main.fillFilters(destination);
            main.applyFilters(this);
        }

        public bool CheckFields(string destination)
        {
            bool success = true;
            
            var inputboxes = driver.FindElements(By.TagName("input"));
            var city = inputboxes.Where(g => g.GetAttribute("value").StartsWith(destination));
            if (city == null)
                success = false;

            string countstring = driver.FindElement(By.ClassName("count")).Text;
            countstring = new String(countstring.Where(Char.IsDigit).ToArray());
            if (countstring != String.Empty)
            {
                int count = Convert.ToInt16(countstring);

                if (count < 0)
                    success = false;
            }
            //var divs = driver.FindElements(By.TagName("div"));
            IWebElement newdepartdate = driver.FindElement(By.XPath("//div[@aria-label='Дата вылета']"));
            newdepartdate.Click();

            if (!departdate.Equals(newdepartdate.Text))
                success = false;

            IWebElement moreButton = driver.FindElement(By.XPath("//a[@class='moreButton']"));
            if (moreButton == null)
                success = false;

            return success;
        }

        public void TryToOrderOnOZON()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@data-more='ещё']")));

            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//a[@data-more='ещё']")).Click();

            Actions action = new Actions(driver);
            action.SendKeys(Keys.PageDown);
            action.Perform();

            var ordersystems = driver.FindElements(By.XPath("//button"));
            var hiddenbutton = ordersystems.Where(g => g.GetAttribute("id").EndsWith("-OZON-only")).Select(g => g).First();

            action = new Actions(driver);
            action.MoveToElement(hiddenbutton);
            action.Perform();

            hiddenbutton.Click();

            string url = driver.FindElement(By.XPath("//div[@class='col col-best slim-ticket']/div/div/a")).GetAttribute("href");

            driver.Navigate().GoToUrl(url);
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='submit']/button")));

            action.SendKeys(Keys.Control + "t");
            action.Perform();
            driver.Navigate().GoToUrl(url);

        }
    }
}
