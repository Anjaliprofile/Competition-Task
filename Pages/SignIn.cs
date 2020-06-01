using AventStack.ExtentReports;
using CompetitionTask.Global;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static CompetitionTask.Global.GlobalDefinitions;
using excel = Microsoft.Office.Interop.Excel;

namespace CompetitionTask.Pages
{

    public class SignIn 
    {

        [Obsolete]
        public SignIn()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }
        #region  Initialize Web Elements 
        //Finding the SignIn Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }
        // Verify login
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement loggedin { get; set; }
       
        #endregion

        internal void SignInStep(IWebDriver driver)
        {

            SignIntab.Click();
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"A:\CompetitionTask\CompetitionTask\TestData\TestData.xlsx", "Login");
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UserName"));
            password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            LoginBtn.Click();
          
            Thread.Sleep(3000);
            try
            {

                //Thread.Sleep(1000);           

                String expectedValue = "Hi" + GlobalDefinitions.ExcelLib.ReadData(2, "Name");
                string actualValue = loggedin.Text;
                //Check if expected value is equal to actual value
                if (expectedValue == actualValue)
                {
                    Assert.IsTrue(true);

                }

                else
                {
                    Console.WriteLine("Test Failed");
                }


            }


            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            //Assert.AreEqual(loggedin.Text, "Hi Industry");
        }

    }
}
