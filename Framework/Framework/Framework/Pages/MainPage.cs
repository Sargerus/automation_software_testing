﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class MainPage
    {
        private const string PAGE_URL = "https://www.momondo.by/";
        private IWebDriver driver;

        private CountriesSuffixes countriessuffixes;

        [FindsBy(How = How.ClassName, Using = "locale-link")]
        private IList<IWebElement> pagecountires;

        [FindsBy(How = How.TagName, Using = "input")]
        private IList<IWebElement> pageinputboxes;

        [FindsBy(How = How.TagName, Using = "button")]
        private IList<IWebElement> buttons;

        private DateTime selectedDate;

        public enum Country
        {
            Germany = 1
        }

        private struct CountriesSuffixes
        {
            private string Germany;

            public void Initialize()
            {
                Germany = ".dk/";
            }

            public string getSuffix(Country c)
            {
                string value = "";

                switch (c)
                {
                    case Country.Germany: value = Germany; break;
                    default: break;
                }

                return value;
            }

        }

        public MainPage(IWebDriver driver)
        {
            countriessuffixes.Initialize();
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

        }

        public string getURLByContry(Country c)
        {
            string suffix = countriessuffixes.getSuffix(c);
            return pagecountires.Where(g => g.GetAttribute("href").EndsWith(suffix)).Select(g => g.GetAttribute("href")).Single();
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
        }

        public void goToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public string getPageRegion(string region)
        {
            return pageinputboxes.First(g => g.GetAttribute("value").StartsWith(region)).Text;
        }

        public void fillFilters(string destination)
        {
            var destinationbox = pageinputboxes.Where(g => g.GetAttribute("id").EndsWith("-destination") ).Select(g=>g).First();
            destinationbox.SendKeys(destination);
            Thread.Sleep(500);
            destinationbox.SendKeys(Keys.Enter);

        }

        public void applyFilters(SearchPage sp)
        {
            IWebElement departdate = driver.FindElement(By.XPath("//div[@aria-label='Дата вылета']"));

            departdate.Click();

            sp.departdate = departdate.Text;//driver.FindElement(By.XPath("//div[@class='col-day highlighted selected endDate']")).Text;

            var submitbutton = buttons.Where(g => g.GetAttribute("id").EndsWith("-submit")).First();
            submitbutton.Click();
        }
    }
}
