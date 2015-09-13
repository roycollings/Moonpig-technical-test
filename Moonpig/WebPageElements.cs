using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace MoonPigTests
{
    public class WebPageElements
    {
        public IWebElement GetSearchMenuOption(ChromeDriver driver)
        {
            return driver.FindElementById("menu-item-search");
        }

        public IWebElement GetSearchBox(ChromeDriver driver)
        {
            return driver.FindElementById("search-box");
        }

        public IWebElement GetSearchButton(ChromeDriver driver)
        {
            return driver.FindElementById("search-btn");
        }

        public IWebElement GetSearchResultsText(ChromeDriver driver)
        {
            return driver.FindElementById("searchResultsText");
        }

        public List<string> GetSearchResultProductNunmbers(ChromeDriver driver)
        {
            var Products = new List<string>();

            foreach (var nameEl in driver.FindElements(By.XPath("//img[@class='product-image']")))
            {
                Products.Add(nameEl.GetAttribute("alt").Split(' ').Last());
            }

            return Products;
        }
    }
}
