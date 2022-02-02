using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
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

        private readonly ScenarioContext _scenarioContext;
       // private IWebDriver _driver;

        public AutomationHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        public void LaunchBrowser(string browser="Chrome" )
        {
            if (browser == "Chrome")
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
            }

            else if(browser == "Firefox")
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();               
                driver.Manage().Window.Maximize();
                driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";

            }
        }

        [AfterScenario]
        public void EndScenario()
        {
            if (driver != null)
                driver.Quit();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _scenarioContext.TryGetValue("Variant", out var browser);
            
            switch (browser)
            {
                case "Chrome":
                    driver = SetupChromeDriver();
                    break;
                case "Firefox":
                    driver = SetupFirefoxDriver();
                    break;
                case "IE":
                    driver = SetupIEDriver();
                    break;
                default:
                    driver = SetupChromeDriver();
                    break;
            }
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(driver);
        }

        private IWebDriver SetupIEDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), new EdgeOptions());
            driver.Manage().Window.Maximize();
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
            return driver;
        }

        private IWebDriver SetupFirefoxDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());

            FirefoxOptions opt = new FirefoxOptions();
            opt.AcceptInsecureCertificates = true;

            driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), opt);
            driver.Manage().Window.Maximize();
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
            return driver;
        }

        private IWebDriver SetupChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), new ChromeOptions());
            driver.Manage().Window.Maximize();
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
            return driver;
        }

       
    }
}
