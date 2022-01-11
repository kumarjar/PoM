using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProjectEx.Pages
{
    class LoginPage
    {
        private IWebDriver _driver;

        private By _usernameLoc = By.Id("authUser");
        private By _passwordLoc = By.CssSelector("#clearPass");
        private By _langLoc = By.Name("languageChoice");
        private By _subLoc = By.CssSelector("[type='submit']");
        private By _errLoc = By.XPath("//div[contains(text(),'Invalid')]");

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }
        public void EnterUserName(string username)
        {
            _driver.FindElement(_usernameLoc).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(_passwordLoc).SendKeys(password);
        }

        public void SelectLanguage(string language)
        {
            SelectElement sel = new SelectElement(_driver.FindElement(_langLoc));
            sel.SelectByText(language, true);
        }

        public void Login()
        {
            _driver.FindElement(_subLoc).Click();
        }

        public string GetLoginPageTitle()
        {
            return _driver.Title;
        }

        public string GetErrorMessage()
        {
            return _driver.FindElement(_errLoc).Text.Trim();

        }
    }
}
