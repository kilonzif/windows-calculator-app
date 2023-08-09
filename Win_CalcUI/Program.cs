using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace Win_CalcUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorUI());


            // Define Appium Options
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app","Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            appiumOptions.AddAdditionalCapability("platformName", "Windows");

            // Create Appium Windows Driver
            WindowsDriver<WindowsElement> driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);

                // Find and Click Number Buttons
                WindowsElement btn1 = driver.FindElementByAccessibilityId("num1Button");
                WindowsElement btn2 = driver.FindElementByAccessibilityId("num2Button");
                WindowsElement btnPlus = driver.FindElementByAccessibilityId("plusButton");
                WindowsElement btnEquals = driver.FindElementByAccessibilityId("equalButton");

                btn1.Click();
                btnPlus.Click();
                btn2.Click();
                btnEquals.Click();

            if (driver == null)
            {
                Console.WriteLine("App not started.");
                return;
            }


            //Taking test screenshots 
            driver.Manage().Window.Maximize();
            var screenShot = driver.GetScreenshot();
            screenShot.SaveAsFile(
            $".\\Screenshot{DateTime.Now.ToString("ddMMyyyyhhmmss")}.png",
            OpenQA.Selenium.ScreenshotImageFormat.Png);

            // Find and Verify Result
            WindowsElement resultText = driver.FindElementByAccessibilityId("CalculatorResults");
                string actualResult = resultText.Text;
                string expectedResult = "Display is 3";

                if (actualResult == expectedResult)
                {
                    Console.WriteLine("Test Passed!");
                }
                else
                {
                    Console.WriteLine("Test Failed!");
                }

         
              driver.Quit();

            }
        }
}


