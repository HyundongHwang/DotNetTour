using MyWpfListBoxApp.Apis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<DaumImgSearchApi.Response.Item> _ImgSearchItemsOc
            = new ObservableCollection<DaumImgSearchApi.Response.Item>();

        public MainWindow()
        {
            InitializeComponent();
            this.BtnClear.Click += BtnClear_Click;
            this.BtnQuery.Click += BtnQuery_Click;
            this.TbQuery.KeyDown += _TbQuery_KeyDown;
            this.LbObj.ItemsSource = _ImgSearchItemsOc;
        }

        private async void _TbQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await _QueryAndUpdateUi();
            }
        }

        private async void BtnQuery_Click(object sender, RoutedEventArgs e)
        {
            await _QueryAndUpdateUi();
        }

        private async Task _QueryAndUpdateUi()
        {
            var query = this.TbQuery.Text;
            var api = new DaumImgSearchApi();
            var res = await api.ExecuteAsync(query);

            foreach (var item in res.channel.item)
            {
                _ImgSearchItemsOc.Add(item);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            _ImgSearchItemsOc.Clear();
        }
    }
}
