
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace albums
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
     
public sealed partial class BlankPage1 : Page
    {
        public  BlankPage1()
        {
           
            this.InitializeComponent();       
            
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            string afile = e.Parameter as string;
            string astring = "ms-appx:///Assets/NewFolder2/" + afile;

            // string bstring = @"E:\txupd.exe";
            SQ.Source = new BitmapImage(new Uri(astring, UriKind.RelativeOrAbsolute));
        }

        private void clickToAddNewPage(object sender, RoutedEventArgs e)
        {
            // 此处的NewPage是另一个页面的名字
            Frame.Navigate(typeof(choice), "");
        }
    }
}
