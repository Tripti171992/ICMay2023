using FirstGitHubProject.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGitHubProject.Utilities;
using NUnit.Framework;

namespace FirstGitHubProject.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests:CommonDriver
    {
        [SetUp]
        public void SetUpActions()
        {
            //OPen chrome browser
            driver = new ChromeDriver();// For creating Browser instance

            //initializing login page
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.Login(driver);

            //initializing home page
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

        }
        [Test, Order(1)]
        public void CreateTM_Test()
        {
            TMPage TMPageObj = new TMPage();
            TMPageObj.CreateTime(driver);

        }
        [Test, Order(2)]
       public void EditTM_Test()
        {
           
            TMPage tMPageObj = new TMPage();
           // tMPageObj.EditRecord(driver); // commenting coz,edited for specflow data driven testing
        }
        [Test, Order(3)]
        public void DeleteTM_Test()
        {

            TMPage TMPageObj = new TMPage();
            TMPageObj.DeleteRecord(driver);
        }
        [TearDown]
        public void CloseTestRun()
        {
            // driver.Quit();
        }
    }
}
