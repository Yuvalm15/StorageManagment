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
using Microsoft.Win32;
using Windows.Media.Import;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddItem : Page
    {
        private ImageManager imageMng = new ImageManager();
        private string imagePath;
        //StoreStorage storage = new StoreStorage();
        public AddItem()
        {
            this.InitializeComponent();
            List<string> itemType = new List<string>();
            itemType.Add("Book");
            itemType.Add("Journal");

            itemTypeCmbx.ItemsSource = itemType;


            itemGenreCmbx.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList<Genre>(); ;


        }

        private void exitBtnClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ManagerPannel));
        }

        private void addItemClicked(object sender, RoutedEventArgs e)
        {
            badInputTbx.Text = "";
            try
            {
                var itemName = itemNameTbx.Text.ToString();
                var author = itemAuthorTbx.Text.ToString();
                var price = double.Parse(itemPriceTbx.Text.ToString());
                var itemgenre = itemGenreCmbx.SelectedValue.ToString();
                DateTimeOffset date = (DateTimeOffset)itemPublishDatepicker.Date;
                var amount = int.Parse(itemAmountTbx.Text);
                var edition = 0;
                int type = -1;
                if (itemTypeCmbx.SelectedItem.ToString() == "Book")
                {
                    type = 0;    
                }
                else if (itemTypeCmbx.SelectedItem.ToString() == "Journal")
                {
                    type = 1;
                }
                else if (itemTypeCmbx.SelectedItem.ToString() == "Comic")
                {
                    type = 2;
                }
                StoreStorage.Instance.AddItem(itemName, author, price, edition, (Genre)Enum.Parse(typeof(Genre), itemgenre), date, amount, imagePath, type);
                itemNameTbx.Text = "";
                itemAuthorTbx.Text = "";
                itemPriceTbx.Text = "";
                itemGenreCmbx.SelectedValue = null;
                itemPublishDatepicker.Date = null;
                itemAmountTbx.Text = "";
            }
            catch (Exception)
            {
                badInputTbx.Text += "invalid inputs";
            }


        }

        private void convertChoice()
        {
            var choice = itemGenreCmbx.SelectedValue.ToString();

        }

        private async void uploadItemImgClicked(object sender, RoutedEventArgs e)
        {
            string browseFilePath = await imageMng.FileBrowserAsync();
            if (browseFilePath == null) return;
            imagePath = browseFilePath;
            itemImg.Source = new BitmapImage(new Uri(imagePath));
        }

        public class ImageManager
        {
            // Get Image File using File Picker
            // Saves the Image data as Bytes and returns ImagePath
            // Okay if returns null!
            public async Task<string> FileBrowserAsync()
            {

                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".jpeg");
                picker.FileTypeFilter.Add(".png");

                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
                if (file == null) return default;
                string newFilePath = $@"{Windows.Storage.ApplicationData.Current.LocalFolder.Path}/{file.Name}";
                byte[] storageFileContent = await GetImageByteAsync(file);

                File.WriteAllBytes(newFilePath, storageFileContent);

                return newFilePath;
            }


            //To be used with FileBrowserAsync method:
            private async Task<byte[]> GetImageByteAsync(StorageFile file) // Get the byte[] data from ImageFile
            {

                using (var inputStream = await file.OpenSequentialReadAsync())
                {
                    var readStream = inputStream.AsStreamForRead();

                    var byteArray = new byte[readStream.Length];
                    await readStream.ReadAsync(byteArray, 0, byteArray.Length);

                    return byteArray;
                }
            }
        }
    }
}
