using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SpecFlowProjectEx.Hooks;
using SpecFlowProjectEx.Pages;
using System.Threading;
//[assembly: Parallelizable(ParallelScope.Self)]

namespace SpecFlowProjectEx.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly AutomationHooks _hooks;
        private LoginPage _login;
        private MainPage _mainPage;

        public LoginSteps(AutomationHooks hooks)
        {
            this._hooks = hooks;

            
        }

        public void InitializePage()
        {
            _login = new LoginPage(_hooks.driver);
            _mainPage = new MainPage(_hooks.driver);
        }

        
        [Given(@"I have browser with OpenMr Page")]
        public void GivenIHaveBrowserWithOpenMrPage()
        {
           // _hooks.LaunchBrowser();
            InitializePage();
            Thread.Sleep(800);
        }
        
        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            _login.EnterUserName(username);
           // _hooks.driver.FindElement(By.Id("authUser")).SendKeys(username);
        }
        
        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            _login.EnterPassword(password);
           // _hooks.driver.FindElement(By.Id("clearPass")).SendKeys(password);
        }
        
        [When(@"I select language as '(.*)'")]
        public void WhenISelectLanguageAs(string language)
        {
            _login.SelectLanguage(language);
            //SelectElement sel = new SelectElement(_hooks.driver.FindElement(By.Name("languageChoice")));
            //sel.SelectByText(language, true);
        }
        
        [When(@"I click on Login")]
        public void WhenIClickOnLogin()
        {
            // driver.FindElement(By.XPath("//button[@type='submit']")).Click();
           // _hooks.driver.FindElement(By.CssSelector("[type='submit']")).Click();

            _login.Login();
        }
        
        [Then(@"I should get access to portal with title as '(.*)'")]
        public void ThenIShouldGetAccessToPortalWithTitleAs(string expectedTitle)
        {
            //WebDriverWait wait = new WebDriverWait(_hooks.driver, TimeSpan.FromSeconds(20));
            //wait.Until(x => x.FindElement(By.XPath("//*[text()='Patients']")));
            Assert.AreEqual(expectedTitle, _login.GetLoginPageTitle());
            _mainPage.ClickOnPatientClient();   
            _mainPage.WaitForPresencePatientLocator();
            _mainPage.ClickPatient();
        }

        [Then(@"I should get error message as '(.*)'")]
        public void ThenIShouldGetErrorMessageAs(string expectedMessage)
        {
           // string innertext = _hooks.driver.FindElement(By.XPath ("//div[contains(text(),'Invalid')]")).Text.Trim();
            Assert.IsTrue(_login.GetErrorMessage().Contains(expectedMessage));
           // _login.GetErrorMessage();
        }

    }
}
