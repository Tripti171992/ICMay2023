using FirstGitHubProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirstGitHubProject.Pages
{
    public class TMPage
    {
        public void CreateTime(IWebDriver driver)
        {
            //find and click on Create new button
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
            Thread.Sleep(2000);

            //Find and Click on dropdown button                   
             driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span")).Click();
            //Thread.Sleep(2000);
            //Adding wait instead of thread
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 2);

            //Find and Click on Time option
            driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")).Click(); 

            //Find textbox code and input code
           driver.FindElement(By.Id("Code")).SendKeys("IC");

            //Find textbox Description and input description
            driver.FindElement(By.Id("Description")).SendKeys("dfgffgb");

            //Find textbox Price per unit and input price per unit
            //overLapping tag
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys("30");

            //Find button Save and click Save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(2000);
            //Adding wait instead of thread
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 6);

            //Find Last page button and click on it
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();

            /*
            //checked if record is present in the table
            IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table

            if (code.Text == "IC")
            { Console.WriteLine("Record Created !!"); }
            else
            { Console.WriteLine("Record Not Created !!"); }
            */

        }
        public void EditRecord(IWebDriver driver)
        {
            //-------------------- editing time and material record-----------------------------

            //find and click on Edit button
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();
            //Thread.Sleep(4000);
            //Adding wait instead of thread
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 4);

            //Find and Click on material option
            //Can if condition also here
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]")).Click();


            //Find textbox code and input code
            driver.FindElement(By.Id("Code")).Clear();
            driver.FindElement(By.Id("Code")).SendKeys("Edited");

            //Find textbox Description and input description
            driver.FindElement(By.Id("Description")).Clear();
            driver.FindElement(By.Id("Description")).SendKeys("21/23");

            //Find textbox Price per unit and input price per unit
            //Overlapping tag
            IWebElement editOverLap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            editOverLap.Click();

            //Actual tag
            IWebElement editPrice = driver.FindElement(By.Id("Price"));
            editPrice.Clear();

            // Both are working
            /* editOverLap.Click();
            editPrice.SendKeys("10");   */

            editOverLap.SendKeys("10");


            //Find button Save and click Save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(2000);

            //Find Last page button and click on it
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();

            /*
            //checked if record is present in the table
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table

            if (editedCode.Text == "Edited")
            { Console.WriteLine("Record Edited !!"); }
            else
            { Console.WriteLine("Record Not Edited !!"); }
            */
        }

        public void DeleteRecord(IWebDriver driver)
        {
            //------------Deleting the record----------
            //Find the delete button and click on it
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]")).Click();

            //Access the alert and accept the alert
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);

            //Check the record is deleted
            IWebElement lastRowCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table

            /*
            if (lastRowCode.Text != "Edited")
            { Console.WriteLine("Record  Deleted !!"); }
            else
            { Console.WriteLine("Record Not Deleted !!"); }
            */
        }
    }
}
