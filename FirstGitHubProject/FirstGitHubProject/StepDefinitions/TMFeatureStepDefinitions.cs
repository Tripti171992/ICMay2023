using FirstGitHubProject.Pages;
using FirstGitHubProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace FirstGitHubProject.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I logged into the TurnUp portal successfully")]
        public void GivenILoggedIntoTheTurnUpPortalSuccessfully()
        {
            //OPen chrome browser
            driver = new ChromeDriver();// For creating Browser instance

            //initializing login page
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.Login(driver);
        }

        [When(@"I navigate to the time and material page")]
        public void WhenINavigateToTheTimeAndMaterialPage()
        {
            //initializing home page
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create new time and material record")]
        public void WhenICreateNewTimeAndMaterialRecord()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTime(driver);
        }

        [Then(@"Then the record should be created successfully")]
        public void ThenThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tMPageObj = new TMPage();

            string newCode = tMPageObj.GetCode(driver);
            string newTypeCode = tMPageObj.GetTypeCode(driver);
            string newDescription = tMPageObj.GetDescription(driver);
            string newPrice = tMPageObj.GetPrice(driver);

            Assert.AreEqual("IC",newCode, "IC", "Actual Code and expected code do not match.!!");//If pass no msg displays if fail written msg displays
            Assert.AreEqual("T",newTypeCode, "Actual TypeCode and expected TypeCode do not match.!!");
            Assert.AreEqual("dfgffgb",newDescription, "Actual description and expected descriptio do not match.!!");
            Assert.AreEqual("$30.00",newPrice, "Actual Price and expected Price do not match.!!");
        }      

        [Then(@"The '([^']*)' should be editted successfully in the record")]     

        [When(@"I edited '([^']*)','([^']*)' and '([^']*)'on an existing time and material record")]
        public void WhenIEditedAndOnAnExistingTimeAndMaterialRecord(string description, string code, string price)
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditRecord(driver, description, code, price);
        }

        [Then(@"The record should be editted successfully'([^']*)','([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldBeEdittedSuccessfullyAnd(string description, string code, string price)
        {
            TMPage tMPageObj = new TMPage();
            string editedCode = tMPageObj.GetEditedCode(driver);
            string editedDescription = tMPageObj.GetEditedDescription(driver);
            string editedPrice = tMPageObj.GetEditedPrice(driver);

            Assert.AreEqual(code, editedCode, "Actual and expected code do not match after editting !!");
            Assert.AreEqual(description, editedDescription, "Actual and expected description do not match after editting !!");
            Assert.AreEqual(price, editedPrice, "Actual and expected price do not match after editting !!");
        }



    }
}
