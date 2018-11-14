using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.WebDriver;
using PageObject.Pages;

namespace PageObject.Steps
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
            if(driver == null)
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
    }
}
