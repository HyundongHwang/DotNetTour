using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitTaskSample
{
    public enum Commands
    {
        none,
        download_image_list_sync,
        download_image_list_async,
        download_image_list_when_all,
    }
}
