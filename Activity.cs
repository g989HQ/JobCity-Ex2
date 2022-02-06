using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

public class Activity
{


	public static void WaitForElementbyID(IWebDriver driver, string id, int maxwait = 30000)
	{
		//IWebDriver driver = new ChromeDriver();
		WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(maxwait));


		try
		{
			//var element = driver.FindElement(By.Id(id));
			var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
		}

		catch { }


	}

	public static bool WaitForElementbyXpath(IWebDriver driver, string xpath, int maxwait = 30000)
	{
		//IWebDriver driver = new ChromeDriver();
		WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(maxwait));


		try
		{
			//var element = driver.FindElement(By.Id(id));
			var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
			return true;
		}

		catch
		{

			return false;

		}



	}

	public static void NavigateTabs(IWebDriver driver, string id, string expecteddisplay)
	{
		try
		{
			IWebElement searchitem = driver.FindElement(By.Id(id));
			if (searchitem.Displayed)
			{
				searchitem.Click();
				Activity.WaitForElementbyXpath(driver, expecteddisplay);
			}


		}
		catch (NoSuchElementException)
		{
			System.Console.WriteLine("Element or button not found");
		}



	}

	public static void ClickbuttonById(IWebDriver driver, string id)
	{
		try
		{

			IWebElement element = driver.FindElement(By.Id(id));

			element.Click();
		}

		catch
		{
			System.Console.WriteLine("Element or button not found");
		}
	}

	public static void ClickbuttonByXpath(IWebDriver driver, string xpath)
	{
		try
		{

			IWebElement element = driver.FindElement(By.XPath(xpath));

			element.Click();
		}

		catch
		{
			System.Console.WriteLine("Element or button not found");
		}
	}



	public static void ClickbuttonByName(IWebDriver driver, string name)
	{
		try
		{

			IWebElement element = driver.FindElement(By.Name(name));

			element.Click();
		}

		catch
		{
			System.Console.WriteLine("Element or button not found");
		}
	}


	public static void SendKeysById(IWebDriver driver, string id, string text)
	{
		try
		{

			IWebElement element = driver.FindElement(By.Id(id));
			element.SendKeys(text);
		}

		catch
		{
			System.Console.WriteLine("Element or button not found");
		}
	}

	public static void AddtoCart(IWebDriver driver, string product)
	{


		try
		{
			IWebElement cart = driver.FindElement(By.XPath(product));


			OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);
			Thread.Sleep(4000);

			action.MoveToElement(cart).Perform();

			Thread.Sleep(4000);

			Activity.ClickbuttonByXpath(driver, "//span[contains(.,'Add to')]");
		}

		catch
		{
			System.Console.WriteLine("Element or button not found");

		}
	}
}