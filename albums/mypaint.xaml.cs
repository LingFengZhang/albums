﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using albums.Models;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace albums
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class mypaint : Page
    {
        static int i = 0;
        private List<Picture> pictures;

        public mypaint()
        {
            pictures = somepictrues.Getpictures();
            this.InitializeComponent();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            string stringA = (string)e.Parameter;
            if(stringA != "")
                my_paint.Source = new BitmapImage(new Uri(stringA, UriKind.RelativeOrAbsolute));
            else
                my_paint.Source = new BitmapImage(new Uri("ms-appx:///Assets/miku.gif", UriKind.RelativeOrAbsolute));

        }

        private void clickToAddNewPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(mainpage_1), "");
        }

        private async void AA_clickAsync(object sender, RoutedEventArgs e)
        {
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }

        private  void change_click(object sender, RoutedEventArgs e)
        {

            TextBlock something = new TextBlock();
            something.Text = "2";
            something = choice.SelectedItem as TextBlock;
            
            if (i ==0)
            {
                string string2 = "ms-appx:///Assets/NewFolder2/" + something.Text ;
                my_paint.Source = new BitmapImage(new Uri(string2, UriKind.RelativeOrAbsolute));
                i = 1;
            }
            else if(i ==1)
            {
                string string1 = "ms-appx:///Assets/NewFolder1/" + something.Text ;
                my_paint.Source = new BitmapImage(new Uri(string1, UriKind.RelativeOrAbsolute));
                i = 0;
            }
            
        }

        private void choice_click(object sender, ItemClickEventArgs e)
        {
             var picture = (Picture)e.ClickedItem;
            string string2 = "ms-appx://" + picture.picturepath ;
            my_paint.Source = new BitmapImage(new Uri(string2, UriKind.RelativeOrAbsolute));

        }

        
    }
}
