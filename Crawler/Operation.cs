using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler
{
    public class Operation
    {
        public int Timeout { get; set; }

        public Action<IWebDriver> Action { get; set; }

        public Func<IWebDriver, bool> Condition { get; set; }

    }
}
