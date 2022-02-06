using System;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ZeroWebApp_Ex1
{
    class AutomationPractise
    {
        [TestFixture]

        public class AutoMationPractiseTests

        {
            [Test]
            public void SearchbyKeyWord()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
                driver.Manage().Window.Maximize();


                Activity.WaitForElementbyID(driver, "search_block_top");
                Activity.SendKeysById(driver, "search_query_top", "dress");
                Activity.ClickbuttonByName(driver, "submit_search");
                Thread.Sleep(5000);


                ReadOnlyCollection<IWebElement> webelements = driver.FindElement(By.XPath("//*[@id='center_column']/ul")).FindElements(By.XPath("//a[contains(@class,'product-name')]"));


                int i = 0;



                for (i=0; i < webelements.Count; i++)
                {
                    
                        string title;
                        title= webelements[i].Text;

                        if (title.Contains("Dress"))
                        {

                        }

                        else
                        {
                            Assert.Fail("The results returned should match the keyword used for the search");
                        }
                    }

                 
            }

            [Test]
            public void VerifyContactForm()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
                driver.Manage().Window.Maximize();


                Activity.WaitForElementbyID(driver, "search_block_top");

                Activity.ClickbuttonByXpath(driver, "//*[@id='contact-link']/a");

                Activity.WaitForElementbyID(driver, "id_contact");

                var contact = driver.FindElement(By.Id("id_contact"));
                //create select element object 
                var selectElement = new SelectElement(contact);


                // select by text
                selectElement.SelectByText("Customer service");

                Activity.SendKeysById(driver, "email","Auto");
                Activity.SendKeysById(driver, "id_order", "Auto-Order");
                Activity.SendKeysById(driver, "message", "description");
                Thread.Sleep(5000);

                Activity.ClickbuttonByXpath(driver, "//span[contains(.,'Send')]");

                try
                {
                    Activity.WaitForElementbyXpath(driver, "//*[contains(.,'Invalid email address')]");
                        
                }

                catch
                {
                    Assert.Fail("Contact form valiations not working as intended, email format incorrect");
                }
                Thread.Sleep(500);
            }


            [Test]
            public void CartInteractions()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
                driver.Manage().Window.Maximize();


                Activity.WaitForElementbyID(driver, "search_block_top");


                Activity.AddtoCart(driver,"//img[contains(@title,'Faded Short Sleeve T-shirts')]");


                Thread.Sleep(4000);

                Activity.ClickbuttonByXpath(driver, "//span[contains(@title,'Close window')]");


                IWebElement element = driver.FindElement(By.XPath("//span[contains(@class,'price cart_block_total ajax_block_cart_total')]"));

                string text = element.GetAttribute("innerText");


                if (text == "$0.00")
                {
                    Assert.Fail("The item was not added to the Cart");


                }

                Activity.SendKeysById(driver, "search_query_top", "dress");

                Activity.ClickbuttonByName(driver, "submit_search");

                Thread.Sleep(4000);

                Activity.AddtoCart(driver, "//img[contains(@title,'Printed Summer Dress')]");

                Thread.Sleep(4000);

                Activity.ClickbuttonByXpath(driver, "//a[contains(@title,'Proceed to checkout')]");

                Activity.WaitForElementbyID(driver, "cart_title");

                Thread.Sleep(4000);

                OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

                IWebElement twoitemprice = driver.FindElement(By.XPath("//span[contains(@class,'price cart_block_total ajax_block_cart_total')]"));

                text = twoitemprice.GetAttribute("innerText");


                IWebElement finalprice = driver.FindElement(By.XPath("//a[contains(@title,'View my shopping cart')]"));


                Thread.Sleep(4000);

                action.MoveToElement(finalprice).Perform();

                Thread.Sleep(4000);


                Activity.ClickbuttonByXpath(driver, "//a[contains(@class,'ajax_cart_block_remove_link')]");



                if(text == finalprice.GetAttribute("innerText"))
                {
                    Assert.Fail("The item was not removed from the Cart");


                }
                Thread.Sleep(3000);
            }


            [TearDown]
            public void testClean()
            {
            }


        }
    }
}
