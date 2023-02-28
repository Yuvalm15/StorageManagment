using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    public class Book : AbstractItem
    {
        public int Edition { get; private set; }
        public Book(string name, string author, double price, int edition, Genre genre, DateTimeOffset date, int amount, string imagePath, string isbn) : base(name, author, price, genre, date, amount, imagePath, isbn)
        {
            Edition = edition;
        }
    }
}
