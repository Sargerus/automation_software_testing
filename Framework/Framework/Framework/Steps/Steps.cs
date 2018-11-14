using Framework.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Steps
{
    public class Steps
    {
        private IWebDriver driver;

        public void InitBrowser()
        {
            driver = WebDriver.WebDriver.GetInstance();
        }

        public void CloseBrowser()
        {
            CheckDriverExists();
            WebDriver.WebDriver.CloseBrowser();
        }

        private void CheckDriverExists()
        {
            if (driver == null)
                driver = WebDriver.WebDriver.GetInstance();
        }

        public string GetRegion()
        {
            CheckDriverExists();
            RegionPage regionPage = new RegionPage(driver);
            regionPage.goToPage();
            return regionPage.getRegion();
        }

        public bool CheckLanguage(string region)
        {
            CheckDriverExists();
            MainPage mainpage = new MainPage(driver);
            mainpage.goToPage();
            string URL = mainpage.getURLByContry(MainPage.Country.Germany);
            mainpage.goToPage(URL);
            if (mainpage.getPageRegion(region) == null)
                return false;
            return true;
        }

        public bool ApplyFilersAndCheckResult(string destination)
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.goToPage(destination);
            return searchPage.CheckFields(destination);
        }

        public bool CheckBeachRest()
        {
            CheckDriverExists();
            TripFinderPage tripFinderPage = new TripFinderPage(driver);
            tripFinderPage.selectRestTypeBeach();
            return tripFinderPage.CheckResultedList();
        }

        public bool CheckResulredList()
        {
            TripFinderPage tripFinderPage = new TripFinderPage(driver);
            return tripFinderPage.checkFirstfromResultedList();
        }

        public bool OpenHotelPageFromSearch()
        {
            bool success = true;
            SearchPage sp = new SearchPage(driver);

            string cityto = driver.FindElement(By.XPath("(//input)[6]")).GetAttribute("value");
            cityto = cityto.Substring(0,cityto.IndexOf(' '));
            IWebElement hotels = driver.FindElement(By.XPath("//li[@class='col js-vertical-hotels _bd _v _CZ _mK']"));
            hotels.Click();

            success = driver.FindElement(By.XPath("//input[1]")).GetAttribute("value").StartsWith(cityto);

            var butontohotelspage = driver.FindElement(By.XPath("(//button)[8]"));
            butontohotelspage.Click();

            return success;
        }

        public bool TestTwoStarHotels()
        {
            HotelPage hotelpage = new HotelPage(driver);

            return hotelpage.CheckTwoStarHotels();
        }

        public bool goToOZONOrderPage()
        {
            bool success = true;
            SearchPage sp = new SearchPage(driver);

            sp.TryToOrderOnOZON();
            

            return success;

        }
    }
}
