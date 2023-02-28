using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    public class Journal : AbstractItem
    {
        public Journal(string name, string author, double price, Genre genre, DateTimeOffset date, int amount, string imagePath, string isbn) : base(name, author, price, genre, date, amount, imagePath, isbn)
        {

        }
    }
}
