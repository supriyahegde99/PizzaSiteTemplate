using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Seleniumautomation
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = null;
            driver = new ChromeDriver(@"C:\DoverCorp");
            Thread.Sleep(2000);
            string url = "http://localhost:60623/Product";
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(5000);

            IWebElement element = driver.FindElement(By.Name("pizza+2"));
            element.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            IWebElement element1 = driver.FindElement(By.Name("checkout"));
            element1.SendKeys(Keys.Enter);

            Thread.Sleep(5000);



            driver.Close();
        }
    }
}





