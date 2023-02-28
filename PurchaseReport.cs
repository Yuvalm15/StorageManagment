using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    public class PurchaseReport : Report
    {
        public AbstractItem _purchasedItem { get; set; }
        public double _purchasePrice { get; set; }
        public PurchaseReport(AbstractItem purchasedItem, double purchasePrice)
        {
            _purchasedItem = purchasedItem;
            _purchasePrice = purchasePrice;
            ReportDate = DateTime.Now;
        }

        public override string getData()
        {
            return $"Purchesed {_purchasedItem.Name} by {_purchasedItem.Author} in genre {_purchasedItem.Genre} for {_purchasePrice} at {ReportDate}";
        }
    }
}
