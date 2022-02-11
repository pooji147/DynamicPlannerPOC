using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPlanner.PageObjects
{
    public class ManageClientsHomePage : BasePage
    {
        private readonly IWebDriver _driver;
        public ManageClientsHomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement CreateNewLink => _driver.FindElement(By.LinkText("Create New"));
        public IReadOnlyCollection<IWebElement> clientsList => _driver.FindElements(By.CssSelector("table.table tbody tr"));

        
        public void ClickOnCreateNew()
        {
            CreateNewLink.Click();
        }

        public void EditClient(string foreName)
        {
            foreach (var client in clientsList)
            {
                if (client.FindElement(By.TagName("td")).Text.Equals(foreName))
                {
                    client.FindElement(By.LinkText("Edit")).Click();
                }
            }
        }

        public void DeleteClient(string foreName)
        {
            foreach (var client in clientsList)
            {
                if (client.FindElement(By.TagName("td")).Text.Equals(foreName))
                {
                    client.FindElement(By.LinkText("Delete")).Click();
                }
            }
        }

        public bool ClientExists(string foreName)
        {
            foreach (var client in clientsList)
            {
                if (client.FindElement(By.TagName("td")).Text.Equals(foreName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
