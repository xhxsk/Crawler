using Crawler;
using Crawler.Model;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            var crawler = new Crawler.Crawler();
            Operation operation = new Operation
            {
                Timeout = 5000
            };
            string source = string.Empty;
            var res = crawler.Start(new Uri("url地址"), "", operation, ref source);

            Login(res);
            Console.ReadKey();
        }
        static bool Login(OnCompletedEventArgs e)
        {
            #region  获取验证码
            //项目ID
            string items = "4065";
            //运营商ID
            string PhoneType = "0";
            string Token = "";
            using (var httpClient = new HttpClient())
            {
                Comm client = new Comm();
                var TokenMessage = client.Clients("http://api.yyyzmpt.com/index.php/reg/login?username=aaazzz147&password=taolu9826");
               // var a = JsonConvert.DeserializeObject<object>(TokenMessage);

                Console.WriteLine(TokenMessage.ToString());
                string[] strs = TokenMessage.ToString().Split('&');
                Token = strs[0];
                var GetItems = client.Clients($"http://api.w23zu.cn:9002/uGetItems?token={Token}&tp=ut");
                Console.WriteLine(GetItems);
                //var Areas = client.Clients("http://api.w23zu.cn:9002/uGetArea?");
                //Console.WriteLine(Areas);
                string phone = string.Empty;
                while (true)
                {
                    phone = client.Clients($" http://api.w23zu.cn:9002/pubApi/GetPhone?ItemId={items}&token={Token}&PhoneType=PhoneType").ToString();
                    if (!phone.ToString().Contains("!DOCTYPE"))
                    {
                        break;
                    }
                }

                string strPhone = phone.ToString().Substring(0, phone.ToString().Length - 1);
                e.WebDriver.FindElement(By.XPath("//*[@id='rootContainer']/div[2]/div[1]/div/div[2]/input")).SendKeys(strPhone);
                Thread.Sleep(5000);
                e.WebDriver.FindElement(By.XPath("//*[@id='rootContainer']/div[2]/div[1]/div/div[3]/span")).Click();

                while (true)
                {

                    var Gmessaage = client.Clients($"http://api.w23zu.cn:9002/pubApi/GMessage?token={Token}&ItemId={items}&Phone={strPhone}");
                    Console.WriteLine(Gmessaage.ToString());
                    Thread.Sleep(5000);
                    if (!Gmessaage.ToString().Contains("False") && !Gmessaage.ToString().Contains("!DOCTYPE"))
                    {
                        e.WebDriver.FindElement(By.XPath("//*[@id='rootContainer']/div[2]/div[1]/div/div[3]/input")).SendKeys(Gmessaage.ToString());
                        e.WebDriver.FindElement(By.XPath("//*[@id='rootContainer']/div[2]/div[1]/div/div[4]")).Click();
                        break;
                    }
                }
                return true;

            }
            #endregion




        }
    }
}
