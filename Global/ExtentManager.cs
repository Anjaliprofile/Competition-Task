using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;



namespace CompetitionTask.Global
{
   
    public class ExtentManager
    {
        public static ExtentHtmlReporter htmlReporter;

        private static ExtentReports extent;
        private ExtentManager()
        {

        }
        public static ExtentReports getInstance()
        {
            if(extent == null)
            {
                //string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                //filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
                string reportPath = @"A:\CompetitionTask\CompetitionTask\ExtentReports\Report.html";
                string reportFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(".", "_");
                htmlReporter = new ExtentHtmlReporter(reportPath + reportFile);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Window 10 Home");
                extent.AddSystemInfo("Host Name", "Anjali");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("UserName", "Anjali");
            }
            return extent;
        }
    }
}
