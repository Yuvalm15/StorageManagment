using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    public class ActionReport : Report
    {
        private string _action;
        public ActionReport(string actionDone)
        {
            _action = actionDone;
            ReportDate = DateTime.Now;
        }
        public override string getData()
        {
            return $"{_action} at {ReportDate}";
        }
    }
}
