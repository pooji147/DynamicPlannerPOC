using DynamicPlanner.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace DynamicPlanner.Steps
{
    [Binding]
    public sealed class ManageClientsStepDefinition
    {

        private readonly ManageClientsHomePage homePage; 
        private readonly CreateNewClientPage createClientPage; 
        private readonly DeleteClientPage deleteClientPage; 

        public ManageClientsStepDefinition(IWebDriver driver)
        {
            homePage = new ManageClientsHomePage(driver);
            createClientPage = new CreateNewClientPage(driver);
            deleteClientPage = new DeleteClientPage(driver);
        }

        [Given(@"the open manage clients")]
        public void GivenTheOpenManageClients()
        {
            homePage.Navigate(PageUrls.ManagementClientsHomePage);
        }

        [When(@"the add new client by entering '(.*)', '(.*)', and '(.*)'")]
        public void WhenTheAddNewClientByEnteringAnd(string fName, string sName, string dob)
        {
            homePage.ClickOnCreateNew();
            createClientPage.CreateNewClient(fName,sName,dob);
        }

        [Then(@"the user is able to create a client '(.*)' record sucessfully")]
        public void ThenTheUserIsAbleToCreateAClientRecordSucessfully(string fName)
        {
            Assert.True(homePage.ClientExists(fName));
        }

        [Then(@"delete client '(.*)'")]
        public void ThenDeleteClient(string fName)
        {
            homePage.DeleteClient(fName);
            deleteClientPage.ClickDeleteBtn();
        }

        [Then(@"user able to delete Successfully")]
        public void ThenUserAbleToDeleteSuccessfully()
        {
            Assert.False(homePage.ClientExists("Poojitha"));
        }




    }
}
