using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    internal class ReportManager
    {
        public static ReportManager Instance { get; } = new ReportManager();
        public List<Report> PurchaseReportList;
        public List<string> ActionReportList;
        private JsonManager<Report> _jsonManagerPurchase;
        private JsonManager<string> _jsonManagerAction;

        private ReportManager()
        {
            _jsonManagerPurchase = new JsonManager<Report>("/PurchaseReportList.txt", PurchaseReportList);
            _jsonManagerAction = new JsonManager<string>("/ActionReportList.txt", ActionReportList);
            PurchaseReportList = _jsonManagerPurchase.DeSerialze();
            if (PurchaseReportList == null)
            {
                PurchaseReportList = new List<Report>();
            }
            ActionReportList = _jsonManagerAction.DeSerialze();
            if (ActionReportList == null)
            {
                ActionReportList = new List<string>();
            }
        }
    }
}
