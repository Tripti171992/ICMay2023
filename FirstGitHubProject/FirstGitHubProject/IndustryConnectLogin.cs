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

            //----------------Launching and login in Turn Up portal-------------

            //OPen chrome browser
            IWebDriver driver = new ChromeDriver();// For creating Browser instance

            //Navigate to tunup portal 
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(2000);

            //Maximizing the window
            driver.Manage().Window.Maximize();

            //identify the username textbox and fill username
            IWebElement txtUserName = driver.FindElement(By.Id("UserName"));// Textbox , button,dropdown etc. all are webelemnets
            txtUserName.SendKeys("Hari");

            //identify the password textbox and fill password
            IWebElement txtPswd = driver.FindElement(By.Id("Password"));
            txtPswd.SendKeys("123123");

            //identify the login button and click on it
            IWebElement btnLogIn = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            btnLogIn.Click();
            Thread.Sleep(2000);

            //If login sucessfull display Login sucsessful , if not the login unsucessful
            IWebElement drpdwnName = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            if(drpdwnName.Text == "Hello hari!")
            {
                Console.WriteLine("Login Successful");
            
            }
            else
            {
                Console.WriteLine("Login Fail");
            }

            //----------------- CReating and Verifying a record in time and material-----------

            //find and clicking on Administration dropdown
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //find and click on Time and Material from dropdown
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            Thread.Sleep(2000);

            //find and click on Create new button
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
            Thread.Sleep(2000);

            //Find and Click on Time option
            //not able to select Time
            //driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")).Click(); 
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]")).Click();

            //Find textbox code and input code
            driver.FindElement(By.Id("Code")).SendKeys("IC");

            //Find textbox Description and input description
            driver.FindElement(By.Id("Description")).SendKeys("dfgffgb");

            //Find textbox Price per unit and input price per unit
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys("30");

            //Find button Save and click Save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(2000);

            //Find Last page button and click on it
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();

            //checked if record is present in the table
            IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table

           if(code.Text=="IC")
            { Console.WriteLine("Record Created !!"); }
           else
            { Console.WriteLine("Record Not Created !!"); }

            //-------------------- editing time and material record-----------------------------
            
            //find and click on Edit button
              driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();
              Thread.Sleep(4000);

            //Find and Click on Time option
            //Not able to select time option
            //  driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")).Click();



            //Find textbox code and input code
            driver.FindElement(By.Id("Code")).Clear();
            driver.FindElement(By.Id("Code")).SendKeys("Edited");

            //Find textbox Description and input description
            driver.FindElement(By.Id("Description")).Clear();
            driver.FindElement(By.Id("Description")).SendKeys("21/23");

            //Find textbox Price per unit and input price per unit
            //Not able to clear and edit
            //  driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Clear();
            // driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys("10");

            //Find button Save and click Save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(2000);

             //Find Last page button and click on it
             driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();

             //checked if record is present in the table
             IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table

             if (editedCode.Text == "Edited")
             { Console.WriteLine("Record Edited !!"); }
             else
             { Console.WriteLine("Record Not Edited !!"); }

             
           
            //------------Deleting the record----------
            //Find the delete button and click on it
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[6]/td[5]/a[2]")).Click();

            //Access the alert and accept the alert
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);

            //Check the record is deleted
            IWebElement lastRowCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table
            Console.WriteLine(lastRowCode.Text);
            if (lastRowCode.Text != "Edited")
            { Console.WriteLine("Record  Deleted !!"); }
            else
            { Console.WriteLine("Record Not Deleted !!"); }
           
        }
    }
}
