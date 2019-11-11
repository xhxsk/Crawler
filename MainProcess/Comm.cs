using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MainProcess
{
    public class Comm
    {
        /// <summary>
        /// GET 请求
        /// </summary>
        /// <param name="urls"></param>
        /// <returns></returns>
        public object Clients(string urls)
        {
            using (var httpClient = new HttpClient())
            {
                //get
                var url = new Uri(urls);
                // response
                var response = httpClient.GetAsync(url).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                return data;//接口调用成功获取的数据
            }
        }
        //public object PostMessage(string urls, string phone)
        //{
        //    PostMessModel model = new PostMessModel();
        //    model.phone = phone;
        //    model.type = "20";
        //    model.orgin = "1";
        //    model.user_id = "0";
        //    model.token = "";
        //    model.sh_id = "0";
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    string jsonData = js.Serialize(model);//序列化  
        //    using (var httpClient = new HttpClient())
        //    {

        //        //post
        //        var url = new Uri(urls);
        //        var body = new FormUrlEncodedContent(new Dictionary<string, string>
        //        {
        //            { "data",jsonData },
        //            { "apisign", ""},
        //            { "from", "mobile"},
        //        });
        //        // response
        //        var response = httpClient.PostAsync(url, body).Result;
        //        var data = response.Content.ReadAsStringAsync().Result;
        //        return data;//接口调用成功数据
        //    }
        //}

    }
}
