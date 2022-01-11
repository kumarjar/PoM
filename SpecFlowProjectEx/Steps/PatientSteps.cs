using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProjectEx.Hooks;
using SpecFlowProjectEx.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectEx.Steps
{
    [Binding]
    public class PatientSteps
    {
        private readonly AutomationHooks _hooks;
        public ScenarioContext _scenariocontext;


        private MainPage _mainPage;
        private PatientPage _patientPage;

        public PatientSteps(AutomationHooks hooks, ScenarioContext scenariocontext )
        {
            this._hooks = hooks;
            Initialize();
            _scenariocontext = scenariocontext;
        }
        public void Initialize()
        {
            _mainPage = new MainPage(_hooks.driver);
            _patientPage = new PatientPage(_hooks.driver);
        }

        [When(@"I click on Patient/client")]
        public void WhenIClickOnPatientClient()
        {
            
            _mainPage.ClickOnPatientClient();
        }
        
        [When(@"I click on Patient")]
        public void WhenIClickOnPatient()
        {
            _mainPage.ClickPatient();   
        }
        
        [When(@"I click on add new patient")]
        public void WhenIClickOnAddNewPatient()
        {
            _patientPage.ClickOnNewPatient();
        }
        
        [When(@"I fill the form")]
        public void WhenIFillTheForm(Table table)
        {
            _patientPage.FillForm(table);
        }
        
        [When(@"I click on create new patient")]
        public void WhenIClickOnCreateNewPatient()
        {
            _hooks.driver.FindElement(By.XPath("//input[contains(@value,'Confirm')]"));
        }
        
        [When(@"I click on confirm create new patient")]
        public void WhenIClickOnConfirmCreateNewPatient()
        {
            _hooks.driver.FindElement(By.XPath("//input[contains(@value,'Confirm')]")).Click();
        }
        
        [When(@"I store alert text and handle it")]
        public void WhenIStoreAlertTextAndHandleIt()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_hooks.driver);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            string alertText = wait.Until(x => x.SwitchTo().Alert()).Text;
            _scenariocontext.Add("alerttext", alertText);
        }

        [When(@"I handle happy birthday pop up if any")]
        public void WhenIHandleHappyBirthdayPopUpIfAny()
        {

            _hooks.driver.SwitchTo().Alert().Accept();
        }
        
        [Then(@"I should verify the stored alert text as '(.*)'")]
        public void ThenIShouldVerifyTheStoredAlertTextAs(string expectedText)
        {
            _scenariocontext.TryGetValue("alerttext", out string expected);
            Assert.IsTrue( expectedText.Contains(expected));

        }
        
        [Then(@"I should verify the patient details as '(.*)'")]
        public void ThenIShouldVerifyThePatientDetailsAs(string p0)
        {
            
        }
    }
}
