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
    public class RegistrationPageTests
    {
        private IWebDriver driver;

        [Test]
        public void ShouldEnterAllFieldsAndClickRegisterButton()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/account/register");

            IWebElement userNameInput = this.driver.FindElement(By.Id("Email"));
            userNameInput.SendKeys("Alexander");

            IWebElement companyNameInput = this.driver.FindElement(By.Id("CompanyName"));
            companyNameInput.SendKeys("Payroll Ltd.");

            IWebElement companyAddressInput = this.driver.FindElement(By.Id("CompanyAddress"));
            companyAddressInput.SendKeys("bul. Bulgaria 90");

            IWebElement passwordInput = this.driver.FindElement(By.Id("Password"));
            passwordInput.SendKeys("123456");

            IWebElement confirmPasswordInput = this.driver.FindElement(By.Id("ConfirmPassword"));
            confirmPasswordInput.SendKeys("123456");

            IWebElement registerButton = this.driver.FindElement(By.ClassName("btn-default"));
            registerButton.Click();

            this.driver.Quit();
        }
    }
}
