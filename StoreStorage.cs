using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace Bookstore_DB
{
    public class StoreStorage
    {
        public static StoreStorage Instance { get; } = new StoreStorage();
        private JsonManager<AbstractItem> _jsonManager;
        public List<AbstractItem> Inventory;
        public static int ISBN = 0;
        private StoreStorage()
        {
            _jsonManager = new JsonManager<AbstractItem>("/Storage.txt", Inventory);
            Inventory = _jsonManager.DeSerialze();
            if (Inventory == null)
            {
                Inventory = new List<AbstractItem>();
            }
        }


        public void AddItem(string itemName, string author, double price, int edition, Genre genre, DateTimeOffset date, int amount, string imagePath, int selection)
        {
            switch (selection)
            {
                case 0:
                    Book book = new Book(itemName, author, price, edition, genre, date, amount, imagePath, ISBN++.ToString());
                    Inventory.Add(book);
                    break;
                case 1:
                    Journal journal = new Journal(itemName, author, price, genre, date, amount, imagePath, ISBN++.ToString());
                    Inventory.Add(journal);
                    break;
                case 2:
                    Comic comic = new Comic(itemName, author, price, edition, genre, date, amount, imagePath, ISBN++.ToString());
                    Inventory.Add(comic);
                    break;
            }
            _jsonManager.Serialze();
        }

        public List<AbstractItem> GetItemsBy(string bookname = ",./", string authorname = ",./", Genre genre = Genre.None)
        {
            List<AbstractItem> items = new List<AbstractItem>();
            foreach (AbstractItem item in Inventory)
            {
                if (item.Name.ToLower().Contains(bookname) || item.Author.ToLower().Contains(authorname) || item.Genre.Equals(genre))
                {
                    items.Add(item);
                }
            }
            return items;
        }
        public List<AbstractItem> GetAllItems()
        {

            return Inventory;
        }

        public ObservableCollection<AbstractItem> GetObservableItemCollection()
        {
            return new ObservableCollection<AbstractItem>(Inventory);
        }

        public void RemoveItem(AbstractItem item)
        {
            if (Inventory.Remove(item))
            {
                _jsonManager.Serialze();
            }
        }
        public AbstractItem SelectedAbstractItem(List<AbstractItem> items, string selectedItem)
        {
            if (selectedItem == null || items == null) return null;

            AbstractItem selectedBook = PrivateSelectedAbstractItem(items, selectedItem);
            return selectedBook;
        }
        private AbstractItem PrivateSelectedAbstractItem(List<AbstractItem> items, string selectedItem)
        {
            if (selectedItem == null || items == null) return null;

            AbstractItem temp = null;
            foreach (var item in items)
            {
                if (selectedItem == item.Name)
                    temp = item;
            }
            if (temp == null)
            {
                throw new ArgumentNullException("No Item was selected.");
            }
            return temp;
        }

    }
}
