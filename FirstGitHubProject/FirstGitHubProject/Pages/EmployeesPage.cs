using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGitHubProject.Pages
{
    public class EmployeesPage
    {
        public void CreateEmployee(IWebDriver driver)
        {
            //find and click on Create new button
            Thread.Sleep(2000);
            IWebElement buttonCreateNewEmp = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            buttonCreateNewEmp.Click();
            Thread.Sleep(2000);

            //Finding element and entering name
            //finding element and entering username
            //finding element and entering contact
        }
        public void EditEmployee()
        {

        }
        public void DeleteEmployee()
        { 
        }
    }
}
