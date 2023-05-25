using FirstGitHubProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGitHubProject.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            //----------------- Navigating to time and material page-----------

            //find and clicking on Administration dropdown
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //find and click on Time and Material from dropdown
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
             Thread.Sleep(2000);
            
        }
    }
}
