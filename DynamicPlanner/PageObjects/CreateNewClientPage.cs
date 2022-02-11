using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPlanner.PageObjects
{
    public class CreateNewClientPage : BasePage
    {
        private readonly IWebDriver _driver;
        public CreateNewClientPage(IWebDriver driver): base(driver)
        {
            _driver = driver;
        }

        public IWebElement ForeName => _driver.FindElement(By.Id("Forename"));
        public IWebElement surName => _driver.FindElement(By.Id("Surname"));
        public IWebElement Dob => _driver.FindElement(By.Id("DateOfBirth"));
        public IWebElement CreateBtn => _driver.FindElement(By.CssSelector("input.btn"));

        public void CreateNewClient(string fName, string sName, string dob)
        {
            ForeName.SendKeys(fName);
            surName.SendKeys(sName);
            Dob.SendKeys(dob);
            CreateBtn.Click();
        }

    }
}
