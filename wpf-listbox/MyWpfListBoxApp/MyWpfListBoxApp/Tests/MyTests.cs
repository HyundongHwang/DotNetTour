using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWpfListBoxApp.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfListBoxApp.Tests
{
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void daum_img_search_api()
        {
            var api = new DaumImgSearchApi();
            var res = api.ExecuteAsync("microsoft").Result;
            Assert.IsTrue(res.channel.item.Count > 0);
        }
    }
}
