using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitTaskSample
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AsyncAwaitTaskSample.");
            Console.WriteLine("This is cmd list : ");

            var methodList = typeof(Program).GetRuntimeMethods().Where(m => m.Name.StartsWith("dt")).ToList();

            foreach (var m in methodList)
            {
                Console.WriteLine($"* {m.Name}");
            }

            Console.WriteLine("Type the keyword ... ");



            while (true)
            {
                Console.Write("CMD> ");
                var cmdStr = Console.ReadLine();
                var count = methodList.Where(m => m.Name.Contains(cmdStr)).Count();

                if (string.IsNullOrEmpty(cmdStr))
                {
                    continue;
                }

                if (count != 1)
                {
                    Console.WriteLine("wrong command !!!");
                    continue;
                }



                var foundMethod = methodList.Where(m => m.Name.Contains(cmdStr)).First();

                try
                {
                    Console.WriteLine($"{foundMethod.Name} invoke !!!");
                    foundMethod.Invoke(null, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ex : {ex}");
                }
            }
        }



        private static void dt_sync()
        {
            DtUtils.ConsoleWriteLine("dt_sync start ... ", "dt_sync");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(3000);
                DtUtils.ConsoleWriteLine($"dt_sync {i} ...");
            }

            DtUtils.ConsoleWriteLine("dt_sync end !!! ", "dt_sync");
        }


        private static void dt_callback()
        {
            DtUtils.ConsoleWriteLine("dt_callback start ... ", "dt_callback");
            _idx = 0;
            _dt_callback();
        }

        private static void _dt_callback()
        {
            ThreadPool.QueueUserWorkItem((arg) =>
            {
                if (_idx == 10)
                {
                    DtUtils.ConsoleWriteLine("dt_callback end !!! ", "dt_callback");
                    return;
                }

                Thread.Sleep(3000);
                DtUtils.ConsoleWriteLine($"dt_callback {_idx} ...");
                _idx = _idx + 1;
                _dt_callback();
            });
        }

        private static async void dt_async()
        {
            DtUtils.ConsoleWriteLine("dt_async start ... ", "dt_async");

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    await _run_long_task(i);
                }
            }
            catch (TaskCanceledException tcex)
            {
                DtUtils.ConsoleWriteLine($"tasks is canceled !!!");
            }
            catch (Exception ex)
            {
                DtUtils.ConsoleWriteLine($"another exception !!! ex : {ex}");
            }

            DtUtils.ConsoleWriteLine("dt_async end !!! ", "dt_async");
        }

        private static async Task _run_long_task(int i)
        {
            await Task.Run(() => 
            {
                Thread.Sleep(3000);
                DtUtils.ConsoleWriteLine($"dt_async {i} ...");
            }, _cts.Token);
        }

        private static void dt_download_image_list_sync()
        {
            var old = DateTime.Now;
            DtUtils.ConsoleWriteLine($"download_image_list_sync start ...");

            foreach (var url in Constances.WALLPAPERSWIDE_IMAGE_LIST)
            {
                DtUtils.ConsoleWriteLine($"download start ... url : {url}");

                var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var fileName = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                var filePath = Path.Combine(exeDir, fileName);

                using (var client = new HttpClient())
                using (var resStream = client.GetStreamAsync(url).Result)
                using (var fs = File.Open(filePath, FileMode.Create))
                {
                    resStream.CopyTo(fs);
                }

                DtUtils.ConsoleWriteLine($"download end !!! url : {url}");
            }

            DtUtils.ConsoleWriteLine($"download_image_list_sync end !!! {(DateTime.Now - old).TotalMilliseconds} ms");
        }



        private static int _idx = 0;

        private static void dt_download_image_list_callback()
        {
            if (_idx >= Constances.WALLPAPERSWIDE_IMAGE_LIST.Length)
            {
                DtUtils.ConsoleWriteLine($"download_image_list_callback end !!!");
                _idx = 0;
                return;
            }
            else
            {
                if (_idx == 0)
                    DtUtils.ConsoleWriteLine($"download_image_list_callback start ...");

                _idx = _idx + 1;
            }
            
            var url = Constances.WALLPAPERSWIDE_IMAGE_LIST[_idx];
            DtUtils.ConsoleWriteLine($"download start ... url : {url}");
            var req = (HttpWebRequest)WebRequest.CreateHttp(url);
            req.BeginGetResponse(_res_callback, req);
        }

        private static void _res_callback(IAsyncResult ar)
        {
            var req = (HttpWebRequest)ar.AsyncState;
            var url = req.RequestUri.ToString();
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileName = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            var filePath = Path.Combine(exeDir, fileName);

            using (var res = req.EndGetResponse(ar))
            using (var resStream = res.GetResponseStream())
            using (var fs = File.Open(filePath, FileMode.Create))
            {
                resStream.CopyTo(fs);
            }

            DtUtils.ConsoleWriteLine($"download end !!! url : {url}");
            dt_download_image_list_callback();
        }
        

        
        private static async void dt_download_image_list_async()
        {
            var old = DateTime.Now;
            DtUtils.ConsoleWriteLine($"download_image_list_async start ...");

            foreach (var url in Constances.WALLPAPERSWIDE_IMAGE_LIST)
            {
                DtUtils.ConsoleWriteLine($"download start ... url : {url}");

                var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var fileName = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                var filePath = Path.Combine(exeDir, fileName);

                using (var client = new HttpClient())
                using (var resStream = await client.GetStreamAsync(url))
                using (var fs = File.Open(filePath, FileMode.Create))
                {
                    resStream.CopyTo(fs);
                }

                DtUtils.ConsoleWriteLine($"download end !!! url : {url}");
            }

            DtUtils.ConsoleWriteLine($"download_image_list_async end !!! {(DateTime.Now - old).TotalMilliseconds} ms");
        }
        


        private static CancellationTokenSource _cts = new CancellationTokenSource();

        private static void dt_cancel()
        {
            _cts?.Cancel();
        }



        private static async void dt_download_image_list_when_all()
        {
            var old = DateTime.Now;
            DtUtils.ConsoleWriteLine($"download_image_list_when_all start ...");
            var taskList = new List<Task>();

            foreach (var url in Constances.WALLPAPERSWIDE_IMAGE_LIST)
            {
                var task = _download_img(url);
                taskList.Add(task);
            }

            DtUtils.ConsoleWriteLine($"Task.WhenAll start ...");

            try
            {
                await Task.WhenAll(taskList);
            }
            catch (TaskCanceledException tcex)
            {
                DtUtils.ConsoleWriteLine($"tasks is canceled !!!");
            }
            catch (Exception ex)
            {
                DtUtils.ConsoleWriteLine($"another exception !!! ex : {ex}");
            }

            DtUtils.ConsoleWriteLine($"Task.WhenAll end !!!");
            DtUtils.ConsoleWriteLine($"download_image_list_when_all end !!! {(DateTime.Now - old).TotalMilliseconds} ms");
        }

        private static async Task _download_img(string url)
        {
            DtUtils.ConsoleWriteLine($"download start ... url : {url}");

            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileName = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            var filePath = Path.Combine(exeDir, fileName);

            using (var client = new HttpClient())
            {
                var resMsg = await client.GetAsync(url, _cts.Token);

                using (var resStream = await resMsg.Content.ReadAsStreamAsync())
                using (var fs = File.Open(filePath, FileMode.Create))
                {
                    resStream.CopyTo(fs);
                }
            }

            DtUtils.ConsoleWriteLine($"download end !!! url : {url}");
        }
    }
}
