using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPlanner.PageObjects
{
    public class DeleteClientPage : BasePage
    {
        private readonly IWebDriver _driver;
        public DeleteClientPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement DeleteBtn => _driver.FindElement(By.CssSelector("input.btn"));

        public void ClickDeleteBtn()
        {
            DeleteBtn.Click();
        }


    }
}
