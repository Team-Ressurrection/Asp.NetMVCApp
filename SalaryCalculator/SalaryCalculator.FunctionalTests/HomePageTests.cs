using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace SalaryCalculator.FunctionalTests
{
    [TestFixture]
    public class HomePageTests
    {
        //private IWebDriver driver;

        //[Test]
        //public void ShouldHaveElement_H1_WithValueSalaryCalculator()
        //{
        //    this.driver = new ChromeDriver();
        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/");
        //    IWebElement h1 = this.driver.FindElement(By.TagName("h1"));

        //    Assert.AreEqual("SALARY CALCULATOR", h1.Text);
        //    this.driver.Quit();
        //}

        //[Test]
        //public void ShouldHaveElement_AnchorWithClassGlyphiconHome_WithValueHome()
        //{
        //    this.driver = new ChromeDriver();
        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/");
        //    IWebElement anchor = this.driver.FindElement(By.ClassName("glyphicon-home"));

        //    Assert.AreEqual("Home", anchor.Text);
        //    this.driver.Quit();
        //}

        //[Test]
        //public void ShouldHaveElement_AnchorWithClassGlyphiconBook_WithValueEmployees()
        //{
        //    this.driver = new ChromeDriver();
        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/account/login");

        //    IWebElement userNameInput = this.driver.FindElement(By.Id("Email"));
        //    userNameInput.SendKeys("demouser@gmail.com");

        //    IWebElement passwordInput = this.driver.FindElement(By.Id("Password"));
        //    passwordInput.SendKeys("123456");

        //    IWebElement loginButton = this.driver.FindElement(By.ClassName("btn-primary"));
        //    loginButton.Click();

        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/");
        //    IWebElement anchor = this.driver.FindElement(By.ClassName("glyphicon-book"));

        //    Assert.AreEqual("Employees", anchor.Text);
        //    this.driver.Quit();
        //}

        //[Test]
        //public void ShouldHaveElement_AnchorWithClassGlyphiconUser_WithValueEmployees()
        //{
        //    this.driver = new ChromeDriver();
        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/account/login");

        //    IWebElement userNameInput = this.driver.FindElement(By.Id("Email"));
        //    userNameInput.SendKeys("demouser@gmail.com");

        //    IWebElement passwordInput = this.driver.FindElement(By.Id("Password"));
        //    passwordInput.SendKeys("123456");

        //    IWebElement loginButton = this.driver.FindElement(By.ClassName("btn-primary"));
        //    loginButton.Click();

        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/");
        //    IWebElement anchor = this.driver.FindElement(By.ClassName("glyphicon-user"));

        //    Assert.AreEqual("Add Employee", anchor.Text);
        //    this.driver.Quit();
        //}

        //[Test]
        //public void ShouldHaveSixElements_AnchorWithClassGlyphicon()
        //{
        //    this.driver = new ChromeDriver();
        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/");
        //    ReadOnlyCollection<IWebElement> anchor = this.driver.FindElements(By.ClassName("glyphicon"));

        //    Assert.AreEqual(6, anchor.Count);
        //    this.driver.Quit();
        //}
    }
}
