using Bookstore_DB;
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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SaleScreen : Page
    {
        //StoreStorage storage = new StoreStorage();
        public static bool isManager = false;
        public SaleScreen()
        {
            this.InitializeComponent();
            SaleScreenGV.ItemsSource = StoreStorage.Instance.Inventory;
            genreCmbx.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList<Genre>();
            DateTime now = DateTime.Now;

        }

        private void exitBtnClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void addCustomerClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CustomerAdding));
        }

        private void searchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            genreCmbx.SelectedItem = Genre.None;
            if (searchTbx.Text == null)
            {
                return;
            }
            if (sortByNameRdbtn.IsChecked == true)
            {
                SaleScreenGV.ItemsSource = StoreStorage.Instance.GetItemsBy(searchTbx.Text.ToLower());
            }
            if (sortByAuthorRdbtn.IsChecked == true)
            {
                SaleScreenGV.ItemsSource = StoreStorage.Instance.GetItemsBy(",./", searchTbx.Text.ToLower());
            }
        }

        private void searchCustomerClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CustomerSearching));
        }

        private void managerPannelClicked(object sender, RoutedEventArgs e)
        {
            if (isManager)
            {
                this.Frame.Navigate(typeof(ManagerPannel));
            }
            else
            {
                managerPannelBtn.Content = "Access denied";
                managerPannelBtn.IsEnabled = false;
            }
        }

        private void GridView_ItemClicked(object sender, ItemClickEventArgs e)
        {

        }

        private void Genre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemgenre = genreCmbx.SelectedValue.ToString();
            if ((Genre)genreCmbx.SelectedValue != Genre.None)
            {
                searchTbx.Text = "";
            }
            SaleScreenGV.ItemsSource = StoreStorage.Instance.GetItemsBy(",./", ",./", (Genre)Enum.Parse(typeof(Genre), itemgenre));
        }
    }
}
