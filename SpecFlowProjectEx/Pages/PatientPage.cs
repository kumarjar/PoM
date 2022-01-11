using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProjectEx.Pages
{
    class PatientPage
    {
        private IWebDriver _driver;
        private By _patientclientLoc = By.XPath("//div[contains(text(),'Patient/')]");
        private By _pateintLoc = By.XPath("//div[contains(text(),'Patients')]");
        private By _frameDynamicLoc = By.XPath("//iframe[contains(@src,'dynamic_finder')]");
        private By _createPatientLoc = By.Id("create_patient_btn1");
        private By _framePatLoc = By.XPath("//iframe[contains(@name,'pat')]");
        private By _selectTitleLoc = By.Id("form_title");
        private By _firstNameLoc = By.Id("form_fname");
        private By _middlenameLoc = By.Id("form_mname");
        private By _lastnameLoc = By.Id("form_lname");
        private By _pubidLoc = By.Id("form_pubpid");
        private By _dobLoc = By.Id("form_DOB");
        private By _sexLoc = By.Id("form_sex");
        private By _socialSecurity = By.Id("form_ss");

        public PatientPage(IWebDriver driver)
        {
            this._driver = driver;

        }

        public void ClickOnNewPatient()
        {
            _driver.SwitchTo().Frame(_driver.FindElement(_frameDynamicLoc));
            _driver.FindElement(_createPatientLoc).Click();
            _driver.SwitchTo().DefaultContent();
        }

        public void FillForm(Table table)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(_framePatLoc));
            SelectElement nameselect = new SelectElement(_driver.FindElement(_selectTitleLoc));
            nameselect.SelectByIndex(1);
            _driver.FindElement(_firstNameLoc).SendKeys(table.Rows[0][0]);
            _driver.FindElement(_middlenameLoc).SendKeys(table.Rows[0][1]);
            _driver.FindElement(_lastnameLoc).SendKeys(table.Rows[0][2]);
            _driver.FindElement(_pubidLoc).SendKeys("12311");
            _driver.FindElement(_dobLoc).SendKeys(table.Rows[0][3]);
            SelectElement sex = new SelectElement(_driver.FindElement(_sexLoc));
            sex.SelectByIndex(2);
            _driver.FindElement(_socialSecurity).SendKeys("AMKPS2455AO1");
            _driver.FindElement(By.Id("form_drivers_license")).SendKeys("AMKsssPS4515A1O");
            SelectElement Marriage = new SelectElement(_driver.FindElement(By.Id("form_status")));

            Marriage.SelectByIndex(1);
            _driver.FindElement(By.Id("form_genericname1")).SendKeys("RKJ");
            _driver.FindElement(By.Id("form_genericval1")).SendKeys("Jain1");
            _driver.FindElement(By.Id("form_genericval2")).SendKeys("a");
            _driver.FindElement(By.Id("form_genericname2")).SendKeys("a");
            _driver.FindElement(By.Id("form_billing_note")).SendKeys("sample");
            _driver.FindElement(By.Id("create")).Click();


            _driver.SwitchTo().DefaultContent();
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe[contains(@src,'new_search_popup')]")));

        }
    }
}
