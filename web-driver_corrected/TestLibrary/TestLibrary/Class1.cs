using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver
{
    [TestFixture]
    public class WebDriver
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

        [Test]
        public void CheckLanguage()
        {
            driver.Navigate().GoToUrl("https://www.iplocation.net/");

            string MyRegion = driver.FindElement(By.XPath("//table[1]//tbody/tr[1]/td[4]")).Text;

            driver.Navigate().GoToUrl("https://www.momondo.by/");

            // Find the text input element by its name
            IList<IWebElement> countries = driver.FindElements(By.ClassName("locale-link"));

            foreach (var country in countries)
            {
                string linkGermany = country.GetAttribute("href");
                if (linkGermany.EndsWith(".dk/", StringComparison.OrdinalIgnoreCase))
                {
                    driver.Navigate().GoToUrl(linkGermany);
                    break;
                }

            }

            IList<IWebElement> inputboxes = driver.FindElements(By.TagName("input"));

            IWebElement capitalfrom = inputboxes.First(g => g.GetAttribute("value").StartsWith(MyRegion));
            if (capitalfrom == null)
                Assert.Fail("Capital is null");

            Assert.AreEqual(true, true);
        }
    }

}
