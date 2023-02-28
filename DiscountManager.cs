using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    internal class DiscountManager
    {
        public static DiscountManager Instance { get; } = new DiscountManager();
        public List<Discount> DiscountList;
        private JsonManager<Discount> _jsonManager;
        private DiscountManager()
        {
            _jsonManager = new JsonManager<Discount>("/Storage.txt", DiscountList);
            DiscountList = _jsonManager.DeSerialze();
            if (DiscountList == null)
            {
                DiscountList = new List<Discount>();
            }
        }
    }
}
