using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//TODO why wait.until is not working
//Test case #1
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                try { 
                //get capital of country
                driver.Navigate().GoToUrl("https://www.iplocation.net/");
                Thread.Sleep(3000);

                string MyRegion = driver.FindElement(By.XPath("//table[1]//tbody/tr[1]/td[4]")).Text;

                driver.Navigate().GoToUrl("https://www.momondo.by/");
                Thread.Sleep(3000);

                // Find the text input element by its name
                IList<IWebElement> countries = driver.FindElements(By.ClassName("locale-link"));

                foreach(var country in countries)
                {
                    string linkGermany = country.GetAttribute("href");
                    if (linkGermany.EndsWith(".dk/", StringComparison.OrdinalIgnoreCase))
                    {
                        driver.Navigate().GoToUrl(linkGermany);
                        Thread.Sleep(3000);
                        break;
                    }
                        
                }

                IList<IWebElement> inputboxes = driver.FindElements(By.TagName("input"));

                    IWebElement capitalfrom = inputboxes.First(g => g.GetAttribute("value").StartsWith(MyRegion));
                    if (capitalfrom == null)
                        throw new Exception("No input with your capital");
                    else
                        Console.WriteLine("Succes");
                }
                catch(Exception e)
                {
                    driver.Close();
                    Console.WriteLine(e.Message);
                }

                driver.Close();
            };
        }
    }
}
