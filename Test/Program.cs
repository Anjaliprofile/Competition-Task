using AventStack.ExtentReports;
using CompetitionTask.Global;
using CompetitionTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompetitionTask 
{
    class Program : GlobalDefinitions
    {
        [Obsolete]
        static void Main(string[] args)
        {
            // Steps for SignUp
            SignUp signUp = new SignUp();
            signUp.register();

        }
        [TestFixture, Description("ShareSkill Test Cases")]
        [Parallelizable]
        class ShareSkillTestSuite : GlobalDefinitions
        {
            // Extent report
            ExtentReports rep = ExtentManager.getInstance();
            ExtentTest test;
            [Obsolete]
            [Test]
            public void SaveShareSkill()
            {
                test = rep.CreateTest("ShareSkill");
                test.Log(Status.Info, "Adding ShareSkills");
                // Steps for Add ShareSkill
                ShareSkill shareskill = new ShareSkill();
                shareskill.AddShareSkill();
                test.Log(Status.Info, "Added successfully");
                SaveScreenShotClass.SaveScreenshot(driver, "AddedSkill");
                rep.Flush();

            }

            [Obsolete]
            [Test]
            public void UpdateServiceListing()
            {
                test = rep.CreateTest("EditServiceList");
                test.Log(Status.Info, "Editing ShareSkills");
                // Steps for Edit Servic listing
                ShareSkill Listing = new ShareSkill();
                Listing.EditShareSkill();
                test.Log(Status.Info, "Updated successfully");
                SaveScreenShotClass.SaveScreenshot(driver, "Updated");
                rep.Flush();
            }
        }

        [TestFixture, Description("ManageListing Test Cases")]
        [Parallelizable]
        class ManageListingTestSuit : GlobalDefinitions
        {
            // Extent report
            ExtentReports rep = ExtentManager.getInstance();
            ExtentTest test;

            // Steps for view sevice detail
            [Obsolete]
            [Test]
            public void ServiceListing()
            {
                test = rep.CreateTest("ManageListing");
                test.Log(Status.Info, "Manageing Services");

                ManageListings MngList = new ManageListings();
                MngList.ManageList();
                test.Log(Status.Info, "Managed successfully");
                SaveScreenShotClass.SaveScreenshot(driver, "ManageList");
                rep.Flush();
            }

        }
    }
}

