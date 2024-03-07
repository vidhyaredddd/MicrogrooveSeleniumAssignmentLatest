using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MicrogrooveSeleniumAssignment
{
    public class HerokuAppTests
    {
        [Fact]
        public void TestMethodWithChromeDriver()
        {
            // Set up Chrome WebDriver
            IWebDriver driver = new ChromeDriver();

            // Navigate to the form URL
            driver.Navigate().GoToUrl("https://formy-project.herokuapp.com/form");

            try
            {
                // Find form elements and interact with them
                IWebElement firstNameInput = driver.FindElement(By.Id("first-name"));
                firstNameInput.SendKeys("John");

                IWebElement lastNameInput = driver.FindElement(By.Id("last-name"));
                lastNameInput.SendKeys("Doe");

                IWebElement jobtitleIput = driver.FindElement(By.Id("job-title"));
                jobtitleIput.SendKeys("Tester");

                IWebElement eductionradiobutton = driver.FindElement(By.Id("radio-button-2"));
                eductionradiobutton.Click();

                IWebElement sexCheckbox = driver.FindElement(By.Id("checkbox-2"));
                sexCheckbox.Click();

                // Find the dropdown element
                IWebElement dropdown = driver.FindElement(By.Id("select-menu"));
                // Wrap the dropdown element in a SelectElement object
                SelectElement select = new SelectElement(dropdown);
                // Select by visible text
                select.SelectByText("5-9");
                
                //Select Date
                IWebElement dateInput = driver.FindElement(By.Id("datepicker"));
                dateInput.Click();
                dateInput.Clear();
                dateInput.SendKeys("04242023");
                dateInput.SendKeys(Keys.Tab);

                //Verify date is set to current date
                DateTime currentDate = DateTime.Now;
                string actual = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                Assert.Equal(actual, dateInput.GetAttribute("value"));
               
                // Submit the form
                IWebElement submitButton = driver.FindElement(By.XPath("//a[text()='Submit']"));
                submitButton.Click();

                // Verify success message
                IWebElement confirmationMessage = driver.FindElement(By.XPath("//div[@class=\"alert alert-success\"]"));
                Assert.Equal("The form was successfully submitted!",confirmationMessage.Text);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Test Failed: " + e.Message);
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }

        [Fact]
        public void TestMethodWithFirefoxDriver()
        {
            // Set up Chrome WebDriver
            IWebDriver driver = new FirefoxDriver();

            // Navigate to the form URL
            driver.Navigate().GoToUrl("https://formy-project.herokuapp.com/form");

            try
            {
                // Find form elements and interact with them
                IWebElement firstNameInput = driver.FindElement(By.Id("first-name"));
                firstNameInput.SendKeys("John");

                IWebElement lastNameInput = driver.FindElement(By.Id("last-name"));
                lastNameInput.SendKeys("Doe");

                IWebElement jobtitleIput = driver.FindElement(By.Id("job-title"));
                jobtitleIput.SendKeys("Tester");

                IWebElement eductionradiobutton = driver.FindElement(By.Id("radio-button-2"));
                eductionradiobutton.Click();

                IWebElement sexCheckbox = driver.FindElement(By.Id("checkbox-2"));
                sexCheckbox.Click();

                // Find the dropdown element
                IWebElement dropdown = driver.FindElement(By.Id("select-menu"));
                // Wrap the dropdown element in a SelectElement object
                SelectElement select = new SelectElement(dropdown);
                // Select by visible text
                select.SelectByText("5-9");

                //Select Date
                IWebElement dateInput = driver.FindElement(By.Id("datepicker"));
                dateInput.Click();
                dateInput.Clear();
                dateInput.SendKeys("04242023");
                dateInput.SendKeys(Keys.Tab);

                Thread.Sleep(2000);
                //Verify date is set to default
                Assert.Equal("03/06/2024", dateInput.GetAttribute("value"));
                // Submit the form
                IWebElement submitButton = driver.FindElement(By.XPath("//a[text()='Submit']"));
                submitButton.Click();

                // Wait for the confirmation message
                IWebElement confirmationMessage = driver.FindElement(By.XPath("//div[@class=\"alert alert-success\"]"));
                Assert.Equal("The form was successfully submitted!", confirmationMessage.Text);

            }
            catch (Exception e)
            {
                Console.WriteLine("Test Failed: " + e.Message);
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }


    }
}
