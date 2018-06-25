using System;
using System.Threading;
using OpenQA.Selenium;

namespace ExtentReportAmazon.Pages
{
	public class AmazonPage
	{
		private readonly IWebDriver _webDriver;
		private IWebElement _inputSearchBox;

		public AmazonPage(IWebDriver webDriver)
		{
			_webDriver = webDriver;
		}

		public void OpenAmazonWebSite()
		{
			_webDriver.Navigate().GoToUrl("http://www.amazon.com");
		}

		public void SearchBy(string text)
		{
			_inputSearchBox = _webDriver.FindElement(By.Id("twotabsearchtextbox"));
			_inputSearchBox.SendKeys(text);
		}

		public void PressEnterKeyForSubmit()
		{
			_inputSearchBox.Submit();
		}

		public void ChooseTheFirstItemOfList()
		{
			_webDriver.FindElement(By.XPath("//*[@id=\"result_0\"]//a")).Click();
		}

		public void ClickInAddToCartButton()
		{
			_webDriver.FindElement(By.ClassName("a-button-input")).Click();
		}

		public int GetItemsInCart()
		{
			var count = _webDriver.FindElement(By.Id("nav-cart-count")).Text;
			return string.IsNullOrEmpty(count) ? 0 : Convert.ToInt32(count);
		}
	}
}