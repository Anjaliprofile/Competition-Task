using CompetitionTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompetitionTask.Pages
{
    class SignUp
    {
        [Obsolete]
        public SignUp()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Join 
        [FindsBy(How = How.XPath, Using = "//*[@id='home']//button[text()='Join']")]
        private IWebElement Join { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
        private IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        private IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='terms']")]
        private IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        private IWebElement JoinBtn { get; set; }
        #endregion

        internal void register()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"A:\CompetitionTask\CompetitionTask\CompetitionTask\TestData\TestData.xlsx", "SignUp");
            //Click on Join button
            Join.Click();
            Thread.Sleep(2000);

            //Enter FirstName
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"FirstName"));

            //Enter LastName
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EmailAddress"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();


        }
    }
}
