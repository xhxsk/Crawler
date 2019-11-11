using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler.Model
{
    public class CrawlerOperation
    {
        public Action<IWebDriver> Action { get; set; }
        public Func<IWebDriver, object> GetResults { get; set; }
        public string ResultType { get; set; }
    }
}
