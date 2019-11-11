using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler.Model
{
    public class OnStartEventArgs
    {
        public Uri Uri { get; set; }// 爬虫URL地址

        public OnStartEventArgs(Uri uri)
        {
            this.Uri = uri;
        }
    }
}
