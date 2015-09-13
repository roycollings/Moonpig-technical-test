using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace MoonPigTests
{
    [TestClass]
    public class TestSearch : CommonMethods
    {
        ChromeDriver ChromeDriver;

        [TestInitialize]
        public void TestInitialize()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Navigate().GoToUrl("https://www.moonpig.com/uk/");
        }

        [TestMethod]
        public void CountFunnyCards()
        {
            DoCountTest("funny", 2205);
        }

        [TestMethod]
        public void CountBirthdayCards()
        {
            DoCountTest("birthday", 3989);
        }

        [TestMethod]
        public void CheckFunnyCardList()
        {
            DoSearchResultListTest(
                "funny",
                new List<string>()
                {
                    "ddd056", "btr002", "vv774", "cgc008", "ddd002",
                    "stml017", "rnt015"
                });
        }

        [TestMethod]
        public void CheckBirthdayCardList()
        {
            DoSearchResultListTest(
                "birthday",
                new List<string>()
                {
                    "pu041d","pu042b","pue182",
                    "pue185","pue180"
                });
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ChromeDriver.Quit();
        }

        private void DoCountTest(string text, Int16 resultCount)
        {
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            var TestName = method.Name;

            SearchForText(ChromeDriver, text);

            TestAssert(
                TestName, 
                GetResultSummaryText(ChromeDriver).Contains(resultCount.ToString()));
        }

        private void DoSearchResultListTest(String searchString, List<string> expectedProducts)
        {
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            var TestName = method.Name;

            SearchForText(ChromeDriver, searchString);
            var ProductNumbers = GetSearchResultProductNunmbers(ChromeDriver);
            
            var MissingProducts = new List<string>();

            foreach (var expectedProduct in expectedProducts)
            {
                if (!ProductNumbers.Any(n => n == expectedProduct))
                {
                    MissingProducts.Add(expectedProduct);
                }
            }

            if (MissingProducts.Count > 0)
            {
                Debug.Write("Failed to find products: ");
                foreach (var product in MissingProducts)
                {
                    Debug.Write(" " + product);
                }
                Debug.Flush();
            }

            TestAssert(
                TestName,
                MissingProducts.Count == 0,
                String.Format("{0} expected cards not found.", MissingProducts.Count));
        }
    }
}
