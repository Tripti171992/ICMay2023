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
           // IWebElement buttonCreateNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            IWebElement buttonCreateNew = driver.FindElement(By.XPath("//a[text()='Create New']"));
            buttonCreateNew.Click();
            Thread.Sleep(4000);

            //Find and Click on dropdown button                   
            //IWebElement tMDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            IWebElement tMDropDown = driver.FindElement(By.XPath("//span[text()='select']"));
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

            //Find Last page button and click on it
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            Thread.Sleep(2000);
        }
        public string GetCode(IWebDriver driver)
        {
            //function to return code of created/last row
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));//last() will get the last row of the table
            return newCode.Text;
        }
        public string GetTypeCode(IWebDriver driver)
        {
            //function to return TypeCode of created/ last row
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            return newTypeCode.Text;
        }
        public string GetDescription(IWebDriver driver)
        {
            //function to return Description of created/ last row
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }
        public string GetPrice(IWebDriver driver)
        {
            //function to return Price of created/ last row
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }
        public void EditRecord(IWebDriver driver, string description, string code, string price)
        {
            //-------------------- editing time and material record-----------------------------
            //Find Last page button and click on it
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(2000);

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Adding wait instead of thread
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 4);



            //Checking last record is the desired record
            //IWebElement lastCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            //if (lastCode.Text == "IC")
            //{
            //    //if the desired record ,find and click on Edit button
            //    IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            //    editButton.Click();

            //    //Adding wait instead of thread
            //    Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 4);

            //}
            //else
            //{
            //    //if not the desired record ,fail
            //    Assert.Fail("New record created has not been found");
            //}

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
            codeTextbox.SendKeys(code);

            //Find textbox Description and input description
            IWebElement editDiscTextbox = driver.FindElement(By.Id("Description"));
            editDiscTextbox.Clear();
            editDiscTextbox.SendKeys(description); // dynamic value of description is assigned

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

            editPriceOverLap.SendKeys(price);


            //Find button Save and click Save
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(3000);

            //find last page button and click on it
            IWebElement editlastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editlastpagebutton.Click();

            Thread.Sleep(3000);

        }
        public string GetEditedCode(IWebDriver driver)
        {
            //function to return edited code
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }
        public string GetEditedDescription(IWebDriver driver)
        {
            //function to return edited description
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }
        public string GetEditedPrice(IWebDriver driver)
        {
            //function to return edited price
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return editedPrice.Text;
        }
        public void DeleteRecord(IWebDriver driver)
        {
            //------------Deleting the record----------
            //Find Last page button and click on it
            Thread.Sleep(2000);
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
            Assert.That(deleteCode.Text != "Edited", "Record Not deleted !!");
        }
    }
}
