using FirstGitHubProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGitHubProject.Pages
{
    public class LoginPage
    {
        public void Login(IWebDriver driver)
        {
            //----------------Launching and login in Turn Up portal-------------
            //Navigate to tunup portal 
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(3000);

            //Maximizing the window
            driver.Manage().Window.Maximize();

            //Adding wait 
            Wait.WaitToExist(driver, "Id", "UserName", 2);

            //identify the username textbox and fill username
            IWebElement textUserName = driver.FindElement(By.Id("UserName"));// Textbox , button,dropdown etc. all are webelemnets
            textUserName.SendKeys("Hari");

            //identify the password textbox and fill password
            IWebElement textPswd = driver.FindElement(By.Id("Password"));
            textPswd.SendKeys("123123");

            //identify the login button and click on it
            IWebElement buttonLogIn = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            buttonLogIn.Click();
            Thread.Sleep(2000);

            /*
            //If login sucessfull display Login sucsessful , if not the login unsucessful
            IWebElement drpdwnName = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            if (drpdwnName.Text == "Hello hari!")
            {
                Console.WriteLine("Login Successful");

            }
            else
            {
                Console.WriteLine("Login Fail");
            }
            */
        }

    }
}
