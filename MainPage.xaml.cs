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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BookStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly string adminPass, emplyPass;
        public MainPage()
        {
            this.InitializeComponent();
            adminPass = "admin";
            emplyPass = "1234";
        }

        private void logInClicked(object sender, RoutedEventArgs e)
        {
            
            if (passwordTbx.Password.ToString().Equals(adminPass))
            {
                SaleScreen.isManager = true;
                this.Frame.Navigate(typeof(SaleScreen));
            }
            else if (passwordTbx.Password.ToString().Equals(emplyPass))
            {
                SaleScreen.isManager = false;
                this.Frame.Navigate(typeof(SaleScreen));
            }
            else
            {
                EnterPasswordTbx.Text = "";
                EnterPasswordTbx.Text += "Wrong Password";
                
            }
        }

        private void exitBtnClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
