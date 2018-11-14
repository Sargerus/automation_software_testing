using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class HotelPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "(//div[@class='star-label'])[2]")]
        private IWebElement twoandmoreStars;

        public HotelPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        public bool CheckTwoStarHotels()
        {
            bool success = true;
            twoandmoreStars.Click();

            int stars = Convert.ToInt16(driver.FindElement(By.XPath("//div[@class=' col col-stars']/div")).GetAttribute("data-count"));
            if (stars < 2)
                success = false;

            return success;
        }
    }
}
