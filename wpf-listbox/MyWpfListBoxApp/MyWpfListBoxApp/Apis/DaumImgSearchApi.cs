using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfListBoxApp.Apis
{
    public class DaumImgSearchApi
    {
        public class Response
        {
            public Channel channel { get; set; }

            //cp	"805300"	string
            //cpname	"블로그스팟"	string
            //height	"493"	string
            //image	"http://cdnau.ibtimes.com/sites/au.ibtimes.com/files/styles/v2_article_large/public/2016/09/24/microsoft.jpg"	string
            //link	"https://cyberog.blogspot.kr/2016/11/microsoft-surface-phone.html"	string
            //pubDate	"20161124134900"	string
            //thumbnail	"https://search2.kakaocdn.net/argon/130x130_85_c/c6WEs1MeI9"	string
            //title	"&lt;b&gt;Microsoft&lt;/b&gt; Surface Phone"	string
            //width	"740"	string
            public class Item
            {
                public string image { get; set; }
                public string thumbnail { get; set; }
                public string cpname { get; set; }
                public string width { get; set; }
                public string link { get; set; }
                public string title { get; set; }
                public string cp { get; set; }
                public string pubDate { get; set; }
                public string height { get; set; }
            }

            public class Channel
            {
                public string result { get; set; }
                public string pageCount { get; set; }
                public List<Item> item { get; set; }
                public string lastBuildDate { get; set; }
                public string link { get; set; }
                public string description { get; set; }
                public string generator { get; set; }
                public string title { get; set; }
                public string totalCount { get; set; }
            }
        }

        public async Task<Response> ExecuteAsync(string query)
        {
            //https://hhdfuncopenapicache.azurewebsites.net/api/DaumImgSearchApi?query=microsoft
            var url = $"https://hhdfuncopenapicache.azurewebsites.net/api/DaumImgSearchApi?query={query}";
            var resStr = "";

            using (var client = new HttpClient())
            {
                resStr = await client.GetStringAsync(url);
            }

            var res = JsonConvert.DeserializeObject<Response>(resStr);
            return res;
        }
    }
}
