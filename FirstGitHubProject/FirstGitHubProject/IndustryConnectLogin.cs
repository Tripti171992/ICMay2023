using FirstGitHubProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGitHubProject
{
    public class IndustryConnectLogin
    {
        public static void Main(string[] args)
        {
            //OPen chrome browser
            IWebDriver driver = new ChromeDriver();// For creating Browser instance

           LoginPage loginPageObj =new LoginPage();
            loginPageObj.Login(driver);

            HomePage homePageObj= new HomePage();
            homePageObj.GoToTMPage(driver);

            TMPage TMPageObj = new TMPage();
            TMPageObj.CreateTime(driver);
            TMPageObj.EditRecord(driver);
            TMPageObj.DeleteRecord(driver);

        }
    }
}
