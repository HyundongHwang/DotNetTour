using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitTaskSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AsyncAwaitTaskSample.");
            Console.WriteLine("This is cmd list : ");
            var cmdList = Enum.GetNames(typeof(Commands));

            foreach (var cmd in cmdList)
            {
                Console.WriteLine($"* {cmd}");
            }

            while (true)
            {
                Console.Write("CMD> ");
                var cmd = Commands.none;
                var cmdStr = Console.ReadLine();
                Enum.TryParse<Commands>(cmdStr, out cmd);

                if (cmd == Commands.none)
                {
                }
                else if (cmd == Commands.download_image_list_sync)
                {
                    download_image_list_sync();
                }
                else if (cmd == Commands.download_image_list_async)
                {
                    download_image_list_async();
                }
                else if (cmd == Commands.download_image_list_when_all)
                {
                    download_image_list_when_all();
                }
            }
        }



        private static void download_image_list_sync()
        {
            var old = DateTime.Now;
            Console.WriteLine($"download_image_list_sync start ...");

            foreach (var url in Constances.WALLPAPERSWIDE_IMAGE_LIST)
            {
                Console.WriteLine($"download start !!! url : {url}");

                var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var fileName = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                var filePath = Path.Combine(exeDir, fileName);

                using (var client = new HttpClient())
                using (var resStream = client.GetStreamAsync(url).Result)
                using (var fs = File.Open(filePath, FileMode.Create))
                {
                    resStream.CopyTo(fs);
                }

                Console.WriteLine($"download end !!! url : {url}");
            }

            Console.WriteLine($"download_image_list_sync end !!! {(DateTime.Now - old).TotalMilliseconds} ms");
        }



        private static async void download_image_list_async()
        {
            var old = DateTime.Now;
            Console.WriteLine($"download_image_list_async start ...");

            foreach (var url in Constances.WALLPAPERSWIDE_IMAGE_LIST)
            {
                Console.WriteLine($"download start ... url : {url}");

                var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var fileName = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                var filePath = Path.Combine(exeDir, fileName);

                using (var client = new HttpClient())
                using (var resStream = await client.GetStreamAsync(url))
                using (var fs = File.Open(filePath, FileMode.Create))
                {
                    resStream.CopyTo(fs);
                }

                Console.WriteLine($"download end !!! url : {url}");
            }

            Console.WriteLine($"download_image_list_async end !!! {(DateTime.Now - old).TotalMilliseconds} ms");
        }



        private static async void download_image_list_when_all()
        {
            var old = DateTime.Now;
            Console.WriteLine($"download_image_list_when_all start ...");
            var taskList = new List<Task>();

            foreach (var url in Constances.WALLPAPERSWIDE_IMAGE_LIST)
            {
                var task = _download_img(url);
                taskList.Add(task);
            }

            Console.WriteLine($"Task.WhenAll start ...");
            await Task.WhenAll(taskList);
            Console.WriteLine($"Task.WhenAll end !!!");
            Console.WriteLine($"download_image_list_when_all end !!! {(DateTime.Now - old).TotalMilliseconds} ms");
        }

        private static async Task _download_img(string url)
        {
            Console.WriteLine($"download start ... url : {url}");

            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileName = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            var filePath = Path.Combine(exeDir, fileName);

            using (var client = new HttpClient())
            using (var resStream = await client.GetStreamAsync(url))
            using (var fs = File.Open(filePath, FileMode.Create))
            {
                resStream.CopyTo(fs);
            }

            Console.WriteLine($"download end !!! url : {url}");
        }

        

    }
}
