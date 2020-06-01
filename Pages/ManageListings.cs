using CompetitionTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompetitionTask.Pages
{
    internal class ManageListings : GlobalDefinitions
    {
        [Obsolete]
        public ManageListings()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }
        #region  Initialize Web Elements 
        // Click on Manage Listings
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageListingBtn { get; set; }
       
        // Click on ServiceListing 'isActive' checkbox for activate or deactive the service
        [FindsBy(How = How.XPath, Using = "//tbody//tr[1]/td[7]//input[@name='isActive']")]
        private IWebElement ActiveServic { get; set; }

        // View listing
     
       [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }
        
        // Edit Service list
        [FindsBy(How = How.XPath, Using ="(//i[@class='outline write icon'])[1]")]
        private IWebElement Edit { get; set; }

        // Delete Service list
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement Delete { get; set; }
        // Click on Popup Yes button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement ClickOnYes { get; set; }

        #endregion

        [Obsolete]
        public void ManageList()
        {

            // Navigate to page Manage Listing
            ManageListingBtn.Click();
            Thread.Sleep(5000);
            ActiveServic.Click();
            Thread.Sleep(3000);
            // Update existing data       
            ShareSkill edit = new ShareSkill();
            edit.EditShareSkill();
            Thread.Sleep(3000);
            // click on delete button
            Thread.Sleep(5000);
            Delete.Click();
            Thread.Sleep(3000);
            // Switch to Popup button
            ClickOnYes.Click();
            Thread.Sleep(1000);
            // View Service Listing
            view.Click();
            Thread.Sleep(3000);

        }
    }
}
