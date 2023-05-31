using FirstGitHubProject.Utilities;
using NUnit.Framework;
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
            Thread.Sleep(4000);
            IWebElement buttonCreateNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            buttonCreateNew.Click();
            Thread.Sleep(4000);

            //Find and Click on dropdown button                   
            IWebElement tMDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            tMDropDown.Click();
            //Thread.Sleep(2000);
            //Adding wait instead of thread
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 4);

            //Find and Click on Time option
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //Find textbox code and input code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("IC");

            //Find textbox Description and input description
            IWebElement descTextbox = driver.FindElement(By.Id("Description"));
            descTextbox.SendKeys("dfgffgb");

            //Find textbox Price per unit and input price per unit
            //overLapping tag
            IWebElement PriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            PriceTextbox.SendKeys("30");

            //Find button Save and click Save
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);
            //Adding wait instead of thread
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 6);

            //Find Last page button and click on it
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            Thread.Sleep(2000);

            //checked if record is present in the table
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            //1st method assertion
            /* 
             * if (code.Text == "IC")
             { 
                 Assert.Pass("Record Created !!"); 
             }
             else
             { 
                 Assert.Fail("Record Not Created !!"); 
             }
            */
            //2nd method assertion 
            Assert.That(newCode.Text == "IC", "Actual Code and expected code do not match.!!");//If pass no msg displays if fail written msg displays
            Assert.That(newTypeCode.Text == "T", "Actual TypeCode and expected TypeCode do not match.!!");
            Assert.That(newDescription.Text == "dfgffgb", "Actual description and expected descriptio do not match.!!");
            Assert.That(newPrice.Text == "$30.00", "Actual Price and expected Price do not match.!!");
        }
        public void EditRecord(IWebDriver driver)
        {
            //-------------------- editing time and material record-----------------------------
            //Find Last page button and click on it
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(2000);

            //Checking last record is the desired record
            IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (code.Text == "IC")
            {
                //if the desired record ,find and click on Edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else
            {
                //if not the desired record ,fail
                Assert.Fail("New record created has not been found");
            }



            //Adding wait instead of thread
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 4);

            //Find and Click on material option
            //Can if condition also here
            IWebElement tMDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            tMDropDown.Click();
            Thread.Sleep(2000);
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
            timeOption.Click();


            //Find textbox code and input code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("Edited");

            //Find textbox Description and input description
            IWebElement editDiscTextbox = driver.FindElement(By.Id("Description"));
            editDiscTextbox.Clear();
            editDiscTextbox.SendKeys("21/23");

            //Find textbox Price per unit and input price per unit
            //Overlapping tag
            IWebElement editPriceOverLap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            editPriceOverLap.Click();

            //Actual tag
            IWebElement editPrice = driver.FindElement(By.Id("Price"));
            editPrice.Clear();

            // Both are working
            /* editOverLap.Click();
            editPrice.SendKeys("10");   */

            editPriceOverLap.SendKeys("10");


            //Find button Save and click Save
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(3000);

            //find last page button and click on it
            IWebElement editlastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editlastpagebutton.Click();

            Thread.Sleep(3000);
            //checked if record is present in the table
            IWebElement editcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(editcode.Text == "Edited", "record not edited !!");

        }

        public void DeleteRecord(IWebDriver driver)
        {
            //------------Deleting the record----------
            //Find Last page button and click on it
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(2000);

            //Checking last record is the desired record
            IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table

            if (code.Text == "Edited")
            {
                //if the desired record ,find the delete button and click on it
                IWebElement deleteRecordButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteRecordButton.Click();
            }
            else
            {
                //if not the desired record ,fail
                Assert.Fail("Edited record has not been found");
            }

            //Access the alert and accept the alert
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);

            //Check the record is deleted 
            IWebElement deleteCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table
            Assert.That(deleteCode.Text != "Edited","Record Not deleted !!");
        }
    }
}
