using BoDi;
using ExtentReportAmazon.Common;
using ExtentReportAmazon.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExtentReportAmazon.Steps
{
	[Binding]
	public sealed class AmazonBuyDellXPS : Bootstrapper
	{
		private readonly AmazonPage _amazonPage;

		public AmazonBuyDellXPS(IObjectContainer objectContainer) : base(objectContainer)
		{
			_amazonPage = new AmazonPage(this.Driver);
		}

		[Given(@"I open Amazon website")]
		public void GivenIOpenAmazonWebsite()
		{
			_amazonPage.OpenAmazonWebSite();
		}

		[Given(@"I search by Soap Dove")]
		public void GivenISearchBySoapDove()
		{
			_amazonPage.SearchBy("dell xps");
		}

		[Given(@"I press enter key for submit")]
		public void GivenIPressEnterKeyForSubmit()
		{
			_amazonPage.PressEnterKeyForSubmit();
		}

		[Given(@"I choose the first item of list")]
		public void GivenIChooseTheFirstItemOfList()
		{
			_amazonPage.ChooseTheFirstItemOfList();
		}

		[When(@"I click in Add to Cart button")]
		public void WhenIClickInAddToCartButton()
		{
			_amazonPage.ClickInAddToCartButton();
		}

		[Then(@"Must have one item in cart")]
		public void ThenMustHaveItemInCart()
		{
			var expected = _amazonPage.GetItemsInCart();

			Assert.IsTrue(expected > 0);
			Assert.AreEqual(expected, 1);
			//Assert.AreEqual(expected, 2); // para simular o erro
		}
	}
}
