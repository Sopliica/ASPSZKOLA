using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace SeleniumRentalTest;

public class Tests
{
    public IWebDriver Driver { get; set; }
    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
    }
    [Test]
    public void CheckIfAfterClickingButtonYouLandingOnCorrectURL_001()
    {
        Driver.Navigate().GoToUrl("https://localhost:7214/Rental");
        //Driver.FindElement(By.ClassName("btn btn-outline-info")).Click();
        Driver.FindElement(By.XPath("/html/body/div/main/p/a")).Click();

        var expectedURL = "https://localhost:7214/Rental/Create";
        var currentURL = Driver.Url;

        currentURL.Should().Be(expectedURL);
    }
    [Test]
    public void CheckIfAddingRentalAddsRentalPointWithCorrectName_002()
    {
        string insertedRentalPointName = "Rynek Rental Point";
        Driver.Navigate().GoToUrl("https://localhost:7214/Rental/Create");
        Driver.FindElement(By.XPath("//*[@id=\"Name\"]")).SendKeys(insertedRentalPointName);
        Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[2]/input")).Click();

        Driver.Navigate().GoToUrl("https://localhost:7214/Rental");
        string addedRentalPointName = Driver.FindElement(By.XPath("html/body/div/main/table/tbody/tr/td[1]")).Text;

        addedRentalPointName.Should().Be(insertedRentalPointName);
    }
}