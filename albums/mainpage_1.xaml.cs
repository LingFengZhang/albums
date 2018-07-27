using newalbums.Models;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace albums
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class mainpage_1 : Page
    {
        private List<Picture> pictures;

        public mainpage_1()
        {
            pictures = somepictrues.Getpictures();
            this.InitializeComponent();
            
        }

        private async void pagechanged(object sender, SelectionChangedEventArgs e)
        {
            if (paint.IsSelected) { await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync(); }
                else if(see.IsSelected) { Frame.Navigate(typeof(mypaint), ""); }
                    else if (add.IsSelected) { }
        }

        private void Hambutton_Click(object sender, RoutedEventArgs e)
        {
            
            AsplitView.IsPaneOpen = !AsplitView.IsPaneOpen;
        }

        private void AsplitView_PaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            miku.Source = new BitmapImage(new Uri("ms-appx:///Assets/NewFolder2", UriKind.RelativeOrAbsolute));

        }

        private void AsplitView_PaneOpening(SplitView sender, object args)
        {
            miku.Source = new BitmapImage(new Uri("ms-appx:///Assets/miku.gif", UriKind.RelativeOrAbsolute));

        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(mypaint),some_pictures.SelectedItem);

        }
    }
}
