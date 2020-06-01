using CompetitionTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoItX3Lib;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AventStack.ExtentReports;
using static CompetitionTask.Global.GlobalDefinitions;

namespace CompetitionTask.Pages
{
    internal class ShareSkill
    {
        [Obsolete]
        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }
        #region  Initialize Web Elements 
        // click on Share skill
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }
        //Fill value in title textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }
        // Fill Value in Description textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }
        // Click on Categories dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement Category { get; set; }
        //Click on Categories dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategory { get; set; }
        // Enter Tag Name in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }
        // Select Service Type
        // Service type option 1
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='0']")]
        private IWebElement ServiceTypeOption1 { get; set; }
        // Service type option 2
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='1']")]
        private IWebElement ServiceTypeOption2 { get; set; }

        // Select Location Type
        // Select option 1
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='0']")]
        private IWebElement LocationTypeOption1 { get; set; }
        // Select option 2
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='1']")]
        private IWebElement LocationTypeOption2 { get; set; }
        // Click on start date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDate { get; set; }
        // Click on End date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDate { get; set; }

        //Click on Available date
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]")]
        private IWebElement Row1 { get; set; }
        //Click on available days 

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @index='0']")]
        private IWebElement Sun { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @index='1']")]
        private IWebElement Mon { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @index='2']")]
        private IWebElement Tue { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @index='3']")]
        private IWebElement Wed { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @index='4']")]
        private IWebElement Thr { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @index='5']")]
        private IWebElement Fri { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @index='6']")]
        private IWebElement Sat { get; set; }

        //Click on Start time
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='0']")]
        private IWebElement SunStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='1']")]
        private IWebElement MonStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='2']")]
        private IWebElement TueStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='3']")]
        private IWebElement WedStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='4']")]
        private IWebElement ThrStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='5']")]
        private IWebElement FriStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='6']")]
        private IWebElement SatStartTime { get; set; }

        // Fill the value in End Time
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='0']")]
        private IWebElement SunEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='1']")]
        private IWebElement MonEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='2']")]
        private IWebElement TueEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='3']")]
        private IWebElement WedEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='4']")]
        private IWebElement ThrEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='5']")]
        private IWebElement FriEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='6']")]
        private IWebElement SatEndTime { get; set; }

        //Select Skill Trade option1
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='true']")]
        private IWebElement SkillTradeOption1 { get; set; }
        //Select Skill Trade option2
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='false']")]
        private IWebElement SkillTradeOption2 { get; set; }

        // Enter amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }
        // Enter Skill-Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }
        //Click on Active/Hidden option
        // option1
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='true']")]
        private IWebElement ActiveOption1 { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='false']")]
        private IWebElement ActiveOption2 { get; set; }
        // Add Work Samples
        [FindsBy(How =How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement WorkSample { get; set; }
        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save' and @type='button']")]
        private IWebElement Save { get; set; }
        // Click on Cancel
        [FindsBy(How = How.XPath, Using = "//input[@value='Cancel' and @type='button']")]
        private IWebElement Cancel { get; set; }
        //Click on Edit button
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[8]/div/button[2]")]
        private IWebElement Edit { get; set; }

        // Click on Delete button
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[8]/div/button[3]")]
        private IWebElement Delete { get; set; }
        // Click on Popup Yes button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement ClickOnYes { get; set; }
        // Click on Manage Listings
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageListingBtn { get; set; }
        // Verify Added Share Skills
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]")]
        private IWebElement VerfyShareSkill { get; set; }

        #endregion

        // Fill Values in ShareSkill form
        internal void AddShareSkill()
        {
            Thread.Sleep(2000);
            //Click on ShareSkill button
            ShareSkillButton.Click();
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"A:\CompetitionTask\CompetitionTask\TestData\TestData.xlsx", "ShareSkills");
            Thread.Sleep(2000);
            // Write Title to describe the service
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            // Add description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            // Choose category
            Thread.Sleep(1000);
            SelectElement select = new SelectElement(Category);
            select.SelectByIndex(4);
            //Category.SendKeys("Select Category" + Keys.Down + Keys.Enter);
            // Choose Sub Category
            Thread.Sleep(1000);
            SelectElement select2 = new SelectElement(SubCategory);
            select2.SelectByIndex(3);
            
            //SubCategory.SendKeys("Select Subcategory" + Keys.Down + Keys.Enter);
            // enter Tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Return);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Return);
            // Select Service Type
            ServiceTypeOption1.Click();
            // Select Location time
            LocationTypeOption2.Click();
            // Fill Start date
            StartDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            // Fill End Date
            EndDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));

            // Click on availble days

            //Sun.Click();
            //SunStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            //SunEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            Mon.Click();
            MonStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            MonEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            Tue.Click();
            TueStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "StartTime"));
            TueEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndTime"));

            Wed.Click();
            WedStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "StartTime"));
            WedEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "EndTime"));

            //Thr.Click();
            //ThrStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            //ThrEndTime.SendKeys("0422");

            //Fri.Click();
            //FriStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            //FriEndTime.SendKeys("0522");

            //Sat.Click();
            //SatStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            //SatEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            //Select Skill Trade

            //SkillTradeOption2.Click();
            //CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "CreditAmount"));

            SkillTradeOption1.Click();

            //Add Skill Exchange
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Return);
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Return);
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Return);

            //Click on Work sample
            WorkSample.Click();            
            //AutoIT            
            AutoItX3 AutoIt = new AutoItX3();
            AutoIt.WinActivate("Open");
            Thread.Sleep(1000);
            AutoIt.Send(@"A:\CompetitionTask\TW.docx");
            Thread.Sleep(1000);
            AutoIt.Send("{ENTER}");
            // clickon Active
            ActiveOption1.Click();
            //ActiveOption2.Click();
            Thread.Sleep(1000);
            // Click on Save
            Save.Click();
            SaveScreenShotClass.SaveScreenshot(driver, "SkillsAdded");
            Thread.Sleep(5000);
            // Verify ShareSkill
            try
            {
                String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                string actualValue = VerfyShareSkill.Text;
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
            Thread.Sleep(2000);
        }
        internal void EditShareSkill()
        {
            // After Click on Save button Page navigate to Manage Listing
            ManageListingBtn.Click();
            Thread.Sleep(3000);
            // Click On Edit button of Saved Share skill
            Edit.Click();
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"A:\CompetitionTask\CompetitionTask\TestData\TestData.xlsx", "UpdatedServiceListing");
            Thread.Sleep(2000);
            // Write Title to describe the service
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Updated_Title"));
            // Add description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Updated_Description"));
            // Choose category
            Thread.Sleep(1000);
            SelectElement select = new SelectElement(Category);
            select.SelectByIndex(4);
            //Category.SendKeys("Select Category" + Keys.Down + Keys.Enter);
            // Choose Sub Category
            Thread.Sleep(1000);
            SelectElement select2 = new SelectElement(SubCategory);
            select2.SelectByIndex(3);

            //SubCategory.SendKeys("Select Subcategory" + Keys.Down + Keys.Enter);
            // enter Tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Updated_Tags"));
            Tags.SendKeys(Keys.Return);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Updated_Tags"));
            Tags.SendKeys(Keys.Return);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Updated_Tags"));
            Tags.SendKeys(Keys.Return);
            // Select Service Type
            ServiceTypeOption1.Click();
            // Select Location time
            LocationTypeOption2.Click();
            // Fill Start date
            StartDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            // Fill End Date
            EndDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));

            // Click on availble days

            //Sun.Click();
            //SunStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            //SunEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            Mon.Click();
            MonStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            MonEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            Tue.Click();
            TueStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "StartTime"));
            TueEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndTime"));

            Wed.Click();
            WedStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "StartTime"));
            WedEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "EndTime"));

            //Thr.Click();
            //ThrStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            //ThrEndTime.SendKeys("0422");

            //Fri.Click();
            //FriStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            //FriEndTime.SendKeys("0522");

            //Sat.Click();
            //SatStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
            //SatEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            //Select Skill Trade

            //SkillTradeOption2.Click();
            //CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "CreditAmount"));

            SkillTradeOption1.Click();

            //Add Skill Exchange
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Return);
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Return);
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Return);

            //Click on Work sample
            WorkSample.Click();
            //AutoIT            
            AutoItX3 AutoIt = new AutoItX3();
            AutoIt.WinActivate("Open");
            Thread.Sleep(1000);
            AutoIt.Send(@"A:\CompetitionTask\TW.docx");
            Thread.Sleep(1000);
            AutoIt.Send("{ENTER}");
            // clickon Active
            ActiveOption1.Click();
            //ActiveOption2.Click();
            Thread.Sleep(1000);
            // Click on Save
            Save.Click();
            SaveScreenShotClass.SaveScreenshot(driver, "SkillsUpdated");
            // Click on cancel
            //Cancel.Click();
        }
   
    }

    }