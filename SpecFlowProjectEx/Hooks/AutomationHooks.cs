using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProjectEx.Hooks
{
    [Binding]
   public class AutomationHooks
    {
        public IWebDriver driver;

        public void LaunchBrowser(string browser="ch" )
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
        }

        [AfterScenario]
        public void EndScenario()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
