using MyWpfListBoxApp.Apis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWpfListBoxApp.Views
{
    /// <summary>
    /// Interaction logic for MyImgItemView.xaml
    /// </summary>
    public partial class MyImgItemView : UserControl
    {
        public MyImgItemView()
        {
            InitializeComponent();
            this.DataContextChanged += _This_DataContextChanged;
            this.MouseDoubleClick += _This_MouseDoubleClick;
        }

        private void _This_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (DaumImgSearchApi.Response.Item)this.DataContext;
            Process.Start(item.link);
        }

        private void _This_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var item = (DaumImgSearchApi.Response.Item)this.DataContext;
            this.ImgObj.Source = new BitmapImage(new Uri(item.thumbnail));
            this.TbTitle.Text = HttpUtility.HtmlDecode(item.title);
            this.TbTime.Text = item.pubDate;
        }


    }


    public class DummyMyImgItemViewItem : DaumImgSearchApi.Response.Item
    {
        public DummyMyImgItemViewItem()
        {
            this.title = "title";
            this.thumbnail = "https://c.s-microsoft.com/en-us/CMSImages/lrn-share-site-ms-logo.png";
        }
    }
}
