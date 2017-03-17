using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public static SplitView mySplitView;
        public RootPage(Frame frame)
        {
            this.InitializeComponent();
            mySplitView = this.MySplitView;
            mySplitView.Content = frame;
            (MySplitView.Content as Frame).Navigate(typeof(MainPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Frame myFrame = this.MySplitView.Content as Frame;
            if (myFrame.CanGoBack)
            {
                myFrame.GoBack();
            }
        }

        private void MenuButtonHome_Click(object sender, RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(MainPage));
        }

        private void MenuButtonFilms_Click(object sender, RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(Films));
        }

        private void MenuButtonCompte_Click(object sender, RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(ComptePage));
        }

        private void MenuButtonOptions_Click(object sender, RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(OptionsPage));
        }
    }
}
