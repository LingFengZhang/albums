using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using GalaSoft.MvvmLight.Threading;



// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace albums
{

    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {

            this.InitializeComponent();

        }


        private async void Open_ClickAsync(object sender, RoutedEventArgs e)
        {
            
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;  //设置文件的现实方式，这里选择的是图标
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary; //设置打开时的默认路径，这里选择的是图片库
            picker.FileTypeFilter.Add(".srt");                       //添加可选择的文件类型，这个必须要设置
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            var file = await picker.PickSingleFileAsync();    //只能选择一个文件

            if (file != null)
            {
                //to do something
                //实例化BitmapImage
                App.filename = file.Name;
                 
                App.fileload = file.Path;
                BitmapImage bit = new BitmapImage();
                //异步加载源，异步打开文件的随机访问流
                await bit.SetSourceAsync(await file.OpenAsync(FileAccessMode.ReadWrite));
                //添加
                
                legend.Source = bit;

                view_this.Height = legend.Height;
                view_this.Width = legend.Width;
            }
        }

        

        

        private async void AA_clickAsync(object sender, RoutedEventArgs e)
        {
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }

        private void clickToSee(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(mypaint), "");

        }

        private void click_Add(object sender, RoutedEventArgs e)
        {
        }

        private async void view_click(object sender, RoutedEventArgs e)
        {

            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(BlankPage1), App.filename);
                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);

        }
    }
}
