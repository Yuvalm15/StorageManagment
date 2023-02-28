using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    public abstract class Report
    {
        public DateTime ReportDate { get; set; }

        public abstract string getData();
    }
}
