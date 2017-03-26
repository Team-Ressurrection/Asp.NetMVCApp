using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.FunctionalTests
{
    [TestFixture]
    public class LoginPageTests
    {
        private IWebDriver driver;

        [Test]
        public void ShouldFillAllFieldsAndClickLoginButton()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/account/login");

            IWebElement userNameInput = this.driver.FindElement(By.Id("Email"));
            userNameInput.SendKeys("Alexander");

            IWebElement passwordInput = this.driver.FindElement(By.Id("Password"));
            passwordInput.SendKeys("123456");

            IWebElement loginButton = this.driver.FindElement(By.ClassName("btn-primary"));
            loginButton.Click();

            this.driver.Quit();
        }
    }
}
