using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExtentReportAmazon.Common
{
	public class Bootstrapper : IDisposable
	{
		protected IWebDriver Driver { get; }

		public Bootstrapper(IObjectContainer objectContainer)
		{
			objectContainer.RegisterInstanceAs(new ChromeDriver(), typeof(IWebDriver));
			Driver = objectContainer.Resolve<IWebDriver>();
		}

		public void Dispose()
		{
			Driver?.Quit();
			Driver?.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}