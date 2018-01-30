﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarketClient.Common {
    public class MyWebClient : WebClient {
        public MyWebClient() : base() {
            
        }
        protected override WebRequest GetWebRequest(Uri address) {
            WebRequest res = base.GetWebRequest(address);
            HttpWebRequest hres = res as HttpWebRequest;
            if(hres != null) {
                hres.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                hres.ContentType = "application/x-www-form-urlencoded";
                hres.Accept = "application/xml, text/json, text/x-json, text/javascript, text/xml, application/json";
                hres.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us");
                hres.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }
            res.Timeout = 7000;
            return res;
        }
    }
}
