using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace MoonPigTests
{
    public class CommonMethods : WebPageElements
    {
        public void SearchForText(ChromeDriver driver, string text)
        {
            GetSearchMenuOption(driver).Click();
            GetSearchBox(driver).SendKeys(text);
            GetSearchButton(driver).Click();
        }

        public string GetResultSummaryText(ChromeDriver driver)
        {
            return GetSearchResultsText(driver).Text;
        }

        public void TestAssert(string TestName, bool IsTrue, string TestComment = "")
        {
            var Today = DateTime.Now.ToString("yyyyMMdd");


            using (StreamWriter file =
            new StreamWriter(String.Format(@"C:\Tests\Moonpig\TestResults\TestResults_{0}.txt", Today), true))
            {
                file.WriteLine(String.Format(
                    "{0}|{1}|{2}", 
                    TestName,
                    (IsTrue ? "pass" : "fail"), 
                    TestComment));
            }

            Assert.IsTrue(IsTrue);
        }

    }
}
