using AventStack.ExtentReports;
using CompetitionTask.Pages;
using ExcelDataReader;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CompetitionTask.Global
{
    class GlobalDefinitions
    {
        // Initialize the browser
        public static IWebDriver driver { get; set; }

        // OneTime Setup

        [Obsolete]
        [OneTimeSetUp]
        public void StartUpStep()
        {
            // Extent report
            ExtentReports rep = ExtentManager.getInstance();
            ExtentTest test;

            try
            {
                test = rep.CreateTest("LoginTest");
                test.Log(Status.Info, "Opening Chrome Driver");
                //Defining the browser
                driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

                //Maximise the window
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://192.168.99.100:5000/");
                test.Log(Status.Info, "go to website");
                test.Log(Status.Info, "Start Logging");
                //Steps for SignIn
                SignIn signInObj = new SignIn();
                signInObj.SignInStep(driver);
                test.Log(Status.Info, "Test Passed, LoggedIn successfully");
                SaveScreenShotClass.SaveScreenshot(driver, "LoggedIn");
                test.Log(Status.Pass, "Test Passed");

            }
            catch (TimeoutException e)
            {
                Thread.Sleep(5000);
                Console.WriteLine(e);
            }
            rep.Flush();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            // Close the driver            
            driver.Close();
        }


        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }

        [Obsolete]
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }
        #endregion

        #region Excel 
        public class ExcelLib
        {
            static List<Datacollection> dataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }


            public static void ClearData()
            {
                dataCol.Clear();
            }


            private static DataTable ExcelToDataTable(string fileName, string SheetName)
            {

                // Open file and return as Stream
                using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        //excelReader.IsFirstRowAsColumnNames = true;


                        //Return as dataset
                        DataSet result1 = excelReader.AsDataSet();
                        //Get all the tables
                        DataTableCollection table = result.Tables;

                        // store it in data table
                        DataTable resultTable = table[SheetName];

                        //excelReader.Dispose();
                        //excelReader.Close();
                        return resultTable;
                    }

                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations

                    rowNumber = rowNumber - 1;
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                    return data.ToString();
                }

                catch (Exception e)
                {
                    //Added by Kumar
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                ExcelLib.ClearData();
                DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };


                        //Add all the details for each row
                        dataCol.Add(dtTable);

                    }
                }

            }
        }

        #endregion

        #region screenshots
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (@"A:\CompetitionTask\CompetitionTask\ExtentReports\ScreenShot\");

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);
                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }
        #endregion

    }
}


