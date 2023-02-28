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
using Bookstore_DB;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerSearching : Page
    {
        public CustomerSearching()
        {
            this.InitializeComponent();
        }

        private void exitBtnClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaleScreen));
        }

        private void lastPurchaseClicked(object sender, RoutedEventArgs e)
        {
            this.Frame
                .Navigate(typeof(PurchaseHistoryPage));
        }

        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            string inputId = searchTbx.Text;
            var customer = PCS.Instance.GetCustomer(inputId);
            if (customer != null)
            {
                customerFoundNameTbl.Text = customer.FirstName;
                customerFoundIDTbl.Text = customer.Id;
                customerFoundPhoneTbl.Text = customer.PhoneNumber;
                customerFoundMailTbl.Text = customer.EMail;
                customerFoundBdayTbl.Text = customer.dateOfBirth;
                joinDateTbl.Text = customer.dateOfJoin;
            }
            searchTbx.Text = "";
        }
    }
}
