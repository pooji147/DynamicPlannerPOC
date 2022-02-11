using BoDi;
using DynamicPlanner.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DynamicPlanner.Hooks
{
    [Binding]
    public sealed class Hooks
    {

		private readonly IObjectContainer _objectContainer;
		private IWebDriver _driver;
		private static DriverFactory _driverFactory;

		public Hooks(IObjectContainer objectContainer)
		{
			_objectContainer = objectContainer;
		}

		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			_driverFactory = new DriverFactory();
			//Directory.CreateDirectory(Path.Combine("..", "..", "TestResults"));
		}

		[BeforeScenario(Order = 0)]
		public void BeforeScenario()
		{
			_driver = _driverFactory.CreateDriver();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Manage().Window.Maximize();
			_objectContainer.RegisterInstanceAs(_driver);
		}

		[AfterScenario]
		public void AfterScenario(ScenarioContext scenarioContext)
		{
			//if (scenarioContext.TestError != null)
			//{
			//	_driver.TakeScreenshot().SaveAsFile(Path.Combine("..", "..", "TestResults", $"{scenarioContext.ScenarioInfo.Title}.png"), ScreenshotImageFormat.Png);
			//}
			_driver?.Dispose();
		}
	}
}