using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    internal class Comic : Book
    {
        public Comic(string name, string author, double price, int edition, Genre genre, DateTimeOffset date, int amount, string imagePath, string isbn) : base(name, author, price, edition, genre, date, amount, imagePath, isbn)
        {
        }
    }
}
