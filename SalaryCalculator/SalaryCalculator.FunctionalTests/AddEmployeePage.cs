using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.FunctionalTests
{
    [TestFixture]
    public class AddEmployeePage
    {
        //private IWebDriver driver;

        //[Test]
        //public void ShouldCreateNewEmployee_WhenAllFieldsAreFilledCorrectly()
        //{
        //    this.driver = new ChromeDriver();

        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/account/login");

        //    IWebElement userNameInput = this.driver.FindElement(By.Id("Email"));
        //    userNameInput.SendKeys("demo@mail.bg");

        //    IWebElement passwordInput = this.driver.FindElement(By.Id("Password"));
        //    passwordInput.SendKeys("123456");

        //    IWebElement loginButton = this.driver.FindElement(By.ClassName("btn-primary"));
        //    loginButton.Click();

        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/employees/create");

        //    IWebElement firstNameInput = this.driver.FindElement(By.Id("FirstName"));
        //    firstNameInput.SendKeys("Alexander");

        //    IWebElement middleNameInput = this.driver.FindElement(By.Id("MiddleName"));
        //    middleNameInput.SendKeys("Georgiev");

        //    IWebElement lastNameInput = this.driver.FindElement(By.Id("LastName"));
        //    lastNameInput.SendKeys("Nestorov");

        //    IWebElement personalIdInput = this.driver.FindElement(By.Id("PersonalId"));
        //    personalIdInput.SendKeys("7711116666");

        //    IWebElement createButton = this.driver.FindElement(By.ClassName("btn-success"));
        //    createButton.Click();

        //    // Get Screenshot after test
        //    Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
        //    string screenshotName = Guid.NewGuid().ToString() + ".png";
        //    string screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), screenshotName);
        //    image.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        //    this.driver.Quit();
        //}

        //[Test]
        //public void ShouldReturnTOEmployeesList_WhenBackToListButtonIsClicked()
        //{
        //    this.driver = new ChromeDriver();

        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/account/login");

        //    IWebElement userNameInput = this.driver.FindElement(By.Id("Email"));
        //    userNameInput.SendKeys("demo@mail.bg");

        //    IWebElement passwordInput = this.driver.FindElement(By.Id("Password"));
        //    passwordInput.SendKeys("123456");

        //    IWebElement loginButton = this.driver.FindElement(By.ClassName("btn-primary"));
        //    loginButton.Click();

        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/employees/create");

        //    IWebElement firstNameInput = this.driver.FindElement(By.Id("FirstName"));
        //    firstNameInput.SendKeys("Alexander");

        //    IWebElement middleNameInput = this.driver.FindElement(By.Id("MiddleName"));
        //    middleNameInput.SendKeys("Georgiev");

        //    IWebElement lastNameInput = this.driver.FindElement(By.Id("LastName"));
        //    lastNameInput.SendKeys("Nestorov");

        //    IWebElement personalIdInput = this.driver.FindElement(By.Id("PersonalId"));
        //    personalIdInput.SendKeys("7711116666");

        //    IWebElement backToListButton = this.driver.FindElement(By.ClassName("btn-primary"));
        //    backToListButton.Click();

        //    // Get Screenshot after test
        //    Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
        //    string screenshotName = Guid.NewGuid().ToString() + ".png";
        //    string screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), screenshotName);
        //    image.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        //    this.driver.Quit();
        //}

        //[TestCase("script('alert')", "Georgiev", "Nestorov", "8010103040")]
        //[TestCase("Vasil", "script('alert')", "Nestorov", "8010103040")]
        //[TestCase("Nikolay", "Georgiev", "script('alert')", "8010103040")]
        //[TestCase("Petar", "Georgiev", "Nestorov", "script('alert')")]
        //[TestCase("script('alert')", "G", "N", "8010103040")]
        //[TestCase("El5", "script('alert')", "Nestorov", "8010103040")]
        //[TestCase("Stoyan", "Georgiev", "script('alert')", "801010304")]
        //[TestCase("Valeri", "Georgiev", "Nestorov", "891211653")]
        //[TestCase("", "", "", "")]
        //public void ShouldNotCreateNewEmployees_WhenInvalidFieldIsPassed(string firstName, string middleName, string lastName, string personalId)
        //{
        //    this.driver = new ChromeDriver();

        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/account/login");

        //    IWebElement userNameInput = this.driver.FindElement(By.Id("Email"));
        //    userNameInput.SendKeys("demo@mail.bg");

        //    IWebElement passwordInput = this.driver.FindElement(By.Id("Password"));
        //    passwordInput.SendKeys("123456");

        //    IWebElement loginButton = this.driver.FindElement(By.ClassName("btn-primary"));
        //    loginButton.Click();

        //    this.driver.Navigate().GoToUrl("http://www.salarycalculatormvc.com/employees/create");

        //    IWebElement firstNameInput = this.driver.FindElement(By.Id("FirstName"));
        //    firstNameInput.SendKeys(firstName);

        //    IWebElement middleNameInput = this.driver.FindElement(By.Id("MiddleName"));
        //    middleNameInput.SendKeys(middleName);

        //    IWebElement lastNameInput = this.driver.FindElement(By.Id("LastName"));
        //    lastNameInput.SendKeys(lastName);

        //    IWebElement personalIdInput = this.driver.FindElement(By.Id("PersonalId"));
        //    personalIdInput.SendKeys(personalId);

        //    IWebElement saveButton = this.driver.FindElement(By.ClassName("btn-success"));
        //    saveButton.Click();

        //    // Get Screenshot after test
        //    Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
        //    string screenshotName = Guid.NewGuid().ToString() + ".png";
        //    string screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), screenshotName);
        //    image.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        //    this.driver.Quit();
        //}
    }
}
