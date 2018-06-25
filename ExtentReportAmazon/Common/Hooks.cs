using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using ExtentReportAmazon.ExtensionMethods;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace ExtentReportAmazon.Common
{
	[Binding]
	public class Hooks
	{
		private static ExtentTest _feature;
		private static ExtentTest _scenario;
		private static ExtentReports _extent;
		private static readonly string PathReport = $"{AppDomain.CurrentDomain.BaseDirectory}ExtentReportAmazon.html";

		[BeforeTestRun]
		public static void ConfigureReport()
		{
			var reporter = new ExtentHtmlReporter(PathReport);
			_extent = new ExtentReports();
			_extent.AttachReporter(reporter);
		}

		[BeforeFeature]
		public static void CreateFeature()
		{
			_feature = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
		}

		[BeforeScenario]
		public static void CreateScenario()
		{
			_scenario = _feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
		}

		[AfterStep]
		public static void InsertReportingSteps()
		{
			switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
			{
				case StepDefinitionType.Given:
					_scenario.StepDefinitionGiven();
					break;

				case StepDefinitionType.Then:
					_scenario.StepDefinitionThen();
					break;

				case StepDefinitionType.When:
					_scenario.StepDefinitionWhen();
					break;
			}
		}

		[AfterTestRun]
		public static void FlushExtent()
		{
			_extent.Flush();
			System.Diagnostics.Process.Start(PathReport);
		}
	}
}