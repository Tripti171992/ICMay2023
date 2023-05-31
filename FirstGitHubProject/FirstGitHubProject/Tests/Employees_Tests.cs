using FirstGitHubProject.Pages;
using FirstGitHubProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGitHubProject.Tests
{
    [TestFixture]
    //[Parallelizable]
    public class Employees_Tests : CommonDriver
    {
        [SetUp]
        public void SetActions()
        {
            driver = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.Login(driver);

            HomePage homePageObj=new HomePage();
            homePageObj.GoToEmployeesPage(driver);
                }
        [Test, Order(1)]
        public void CreateEmployee_Test()
        {
            EmployeesPage employeesPageObj = new EmployeesPage();
            employeesPageObj.CreateEmployee(driver);
        }
        [TearDown]
        public void CloseTestRun()
        {
            // driver.Quit();
        }
    }
}
