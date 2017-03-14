using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SalaryCalculator.FunctionalTests
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IWebDriver driver;

        [Test]
        public void ShouldHaveElement_H1_WithValueSalaryCalculator()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/");
            IWebElement h1 = this.driver.FindElement(By.TagName("h1"));

            Assert.AreEqual("SALARY CALCULATOR", h1.Text);
            this.driver.Quit();
        }
    }
}
