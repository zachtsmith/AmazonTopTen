using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Threading;


namespace AmazonTopTen
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            IWebDriver ChromeDriver = new ChromeDriver();

            ChromeDriver.Navigate().GoToUrl("https://www.amazon.com/");
            
            //sometimes having issues with a captcha displaying on amazon site, therefore program is unable to find search box
            
            IWebElement element = ChromeDriver.FindElement(By.Id("twotabsearchtextbox"));
            if (element.Displayed)
            {
                Console.WriteLine("opened Amazon.com");
            }else
            {
                Console.WriteLine("did not open Amazon.com");
            };

            Thread.Sleep(3000);

            var input = ChromeDriver.FindElement(By.Id("twotabsearchtextbox"));
            input.Clear();
            input.SendKeys("wooden chess set");
            Console.WriteLine("wooden chess set has been input in search");

            Thread.Sleep(3000);

            input = ChromeDriver.FindElement(By.Id("nav-search-submit-button"));
            input.Click();
            Console.WriteLine("search button has been clicked");
            Thread.Sleep(3000);

            input = ChromeDriver.FindElement(By.Id("a-autoid-0-announce"));
            input.Click();
            Console.WriteLine("Filter drop down has been selected");
            Thread.Sleep(3000);

            input = ChromeDriver.FindElement(By.Id("s-result-sort-select_1"));
            input.Click();
            Console.WriteLine("Sort price low to high has been selected");
            Thread.Sleep(3000);

            //Selecting the first item from the list
            input = ChromeDriver.FindElement(By.CssSelector("div.sg-col-4-of-12"));
            input.Click();
            Console.WriteLine("First item in list has been selected, went to product page to be able to access product details.");

            //On first items page, now grabbing info from that page
            input = ChromeDriver.FindElement(By.Id("title"));
            Actions action = new Actions(ChromeDriver);
          

            // below, I need to figure out how to create new txt file,
            // not use a previously created one, explore user permissions for access to C drive
            
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Demo\\AmazontopTen.txt");
                //Write a line of text
                sw.WriteLine(input.Text);
                //close file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Data added to file.");
            }
            Console.WriteLine("Name for product 1 added to file.");


            Thread.Sleep(3000);

            ChromeDriver.Quit();
        }
    }
}
