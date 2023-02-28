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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManagerPannel : Page
    {
        public ManagerPannel()
        {
            this.InitializeComponent();
        }

        private void exitBtnClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaleScreen));
        }

        private void addItemClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddItem));
        }

        private void EditItem_Clicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InventoryPage));
        }
    }
}
