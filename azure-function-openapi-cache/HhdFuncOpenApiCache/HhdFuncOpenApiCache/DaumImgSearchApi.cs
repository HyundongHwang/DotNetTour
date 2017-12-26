using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;

namespace HhdFuncOpenApiCache
{
    public static class DaumImgSearchApi
    {
        //http://localhost:7071/api/HttpTriggerCSharp?query=microsoft
        [FunctionName("DaumImgSearchApi")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]HttpRequestMessage req, TraceWriter log)
        {
            //https://apis.daum.net/search/image?apikey=....&q=카카오프렌즈-네오&output=json

            log.Info("DaumImgSearchApi start !!!");
            var kvPairs = req.GetQueryNameValuePairs();
            var paramQuery = kvPairs.FirstOrDefault(kv => kv.Key == "query").Value;
            log.Info($"PartitionJs.Run paramQuery : {paramQuery}");

            var storageAccount = CloudStorageAccount.Parse(SecureKeys.AZURE_STORAGE_CONNECTION_STRING);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("daumimgsearchapi");
            container.CreateIfNotExists();

            var url = $"https://apis.daum.net/search/image?apikey={SecureKeys.DAUM_APIKEY}&q={paramQuery}&output=json";
            var dateHourStr = DateTime.UtcNow.ToString("yyMMdd-HH0000");
            var hashStr = "";

            using (var sha = new SHA256Managed())
            {
                var keyBuf = Encoding.UTF8.GetBytes($"{url} {dateHourStr}");
                byte[] hashBuf = sha.ComputeHash(keyBuf);
                hashStr = BitConverter.ToString(hashBuf);
            }

            var blob = container.GetBlockBlobReference(hashStr);
            var content = "";

            if (blob.Exists())
            {
                using (var os = blob.OpenRead())
                using (var sr = new StreamReader(os))
                {
                    content = sr.ReadToEnd();
                }
            }
            else
            {
                var client = new HttpClient();
                content = await client.GetStringAsync($"https://apis.daum.net/search/image?apikey={SecureKeys.DAUM_APIKEY}&q={paramQuery}&output=json");
                blob.UploadText(content);
            }

            var res = req.CreateResponse(HttpStatusCode.OK);
            res.Content = new StringContent(content);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("text/json");
            res.Content.Headers.ContentType.CharSet = "utf-8";
            log.Info("DaumImgSearchApi end !!!");
            return res;
        }
    }
}