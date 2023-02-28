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
    public sealed partial class InventoryPage : Page
    {
        public InventoryPage()
        {
            this.InitializeComponent();
            InventoryData.ItemsSource = Bookstore_DB.StoreStorage.Instance.GetObservableItemCollection();
        }
        private void exitBtnClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ManagerPannel));
        }
        private void AddItem_Tapped(object sender, RoutedEventArgs e)
        {
            
        }
        private void AddDiscount_Tapped(object sender, RoutedEventArgs e)
        {
            
        }
        private void RemoveItem_Tapped(object sender, RoutedEventArgs e)
        {
            
        }
        private void BackToMenu_Tapped(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
