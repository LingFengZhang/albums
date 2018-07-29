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
using albums.Models;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;



// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace albums
{

    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class choice : Page
    {
        public choice()
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
            var inputfile = await picker.PickSingleFileAsync();    //只能选择一个文件

            if (inputfile != null)
            {
                //to do something
                //实例化BitmapImage
                App.filename = inputfile.Name;
                 
                App.fileload = inputfile.Path;
                BitmapImage bit = new BitmapImage();
                //异步加载源，异步打开文件的随机访问流
                await bit.SetSourceAsync(await inputfile.OpenAsync(FileAccessMode.ReadWrite));
                //添加
                
                legend.Source = bit;

                view_this.Height = legend.Height;
                view_this.Width = legend.Width;

                Picture newpicure = new Picture();
                Picture emptypicture = new Picture();
                emptypicture.emptypivture();
                newpicure.picturename = legend.Name;
                newpicure.picturepath = "/Assets/NewFolder1/" + legend.Name;
                //Xmlfile xmlfile = new Xmlfile();

                //xmlfile.append(newpicure, emptypicture, "test_one");

                using (IRandomAccessStream stream = await inputfile.OpenAsync(FileAccessMode.Read))
                {
                    // Create the decoder from the stream
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);

                    // Get the SoftwareBitmap representation of the file
                    softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                }


            }
        }

        

        static SoftwareBitmap softwareBitmap;

        /// <summary>
        /// 保存图片文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AA_clickAsync(object sender, RoutedEventArgs e)
        {
            
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }

        private async void SaveSoftwareBitmapToFile(SoftwareBitmap softwareBitmap, StorageFile outputFile)
        {
            using (IRandomAccessStream stream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                // Create an encoder with the desired format
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);

                // Set the software bitmap
                encoder.SetSoftwareBitmap(softwareBitmap);

                // Set additional encoding parameters, if needed
                encoder.BitmapTransform.ScaledWidth = 320;
                encoder.BitmapTransform.ScaledHeight = 240;
                encoder.BitmapTransform.Rotation = Windows.Graphics.Imaging.BitmapRotation.Clockwise90Degrees;
                encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Fant;
                encoder.IsThumbnailGenerated = true;

                try
                {
                    await encoder.FlushAsync();
                }
                catch (Exception err)
                {
                    const int WINCODEC_ERR_UNSUPPORTEDOPERATION = unchecked((int)0x88982F81);
                    switch (err.HResult)
                    {
                        case WINCODEC_ERR_UNSUPPORTEDOPERATION:
                            // If the encoder does not support writing a thumbnail, then try again
                            // but disable thumbnail generation.
                            encoder.IsThumbnailGenerated = false;
                            break;
                        default:
                            throw;
                    }
                }

                if (encoder.IsThumbnailGenerated == false)
                {
                    await encoder.FlushAsync();
                }


            }
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
            FileSavePicker fileSavePicker = new FileSavePicker();
            fileSavePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileSavePicker.FileTypeChoices.Add("JPEG files", new List<string>() { ".png", ".jpg" });
            fileSavePicker.SuggestedFileName = App.filename;

            var outputFile = await fileSavePicker.PickSaveFileAsync();

            if (outputFile == null)
            {
                // The user cancelled the picking operation
                return;
            }
            SaveSoftwareBitmapToFile(softwareBitmap, outputFile);

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
