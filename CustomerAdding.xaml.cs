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
    public sealed partial class CustomerAdding : Page
    {
        public CustomerAdding()
        {
            this.InitializeComponent();
        }

        private void exitBtnClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaleScreen));
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            errorTbl.Text = "";
            try
            {
                var id = IDTbx.Text.ToString();
                if (PCS.Instance.GetCustomer(id) == null)
                {
                    var firstName = firstNameTbx.Text.ToString();
                    var sureName = sureNameTbx.Text.ToString();
                    var phoneNumber = phoneNumberTbx.Text.ToString();
                    var eMail = emailTbx.Text.ToString();
                    DateTimeOffset birthday = (DateTimeOffset)birthdayDatePicker.Date;
                    PCS.Instance.AddCustomer(firstName, sureName, id, phoneNumber, eMail, birthday, DateTime.Now.Date.ToString());
                }
                else
                {
                    throw new Exception("Customer Allready Exist");
                }

            }
            catch (Exception b)
            {
                if (b.Message.Contains("Customer Allready Exist"))
                {
                    errorTbl.Text += "User allready exist";
                }
                else errorTbl.Text += "invalid inputs";

            }
        }
    }
}
