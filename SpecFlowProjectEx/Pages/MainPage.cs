using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProjectEx.Pages
{
    class MainPage
    {
        private IWebDriver _driver;

        private By _patientClientLoc = By.XPath("//div[contains(text(),'Patient/')]");
        private By _patientLoc = By.XPath("//div[contains(text(),'Patients')]");


        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void ClickOnPatientClient()
        {
            _driver.FindElement(_patientClientLoc).Click();
        }
        
        public void WaitForPresencePatientLocator()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(x => x.FindElement(_patientLoc));



        }

        public void ClickPatient()
        {
            _driver.FindElement(_patientLoc).Click();

        }

        public string GetMainPageTitle()
        {
            return _driver.Title;
        }


    }
}
