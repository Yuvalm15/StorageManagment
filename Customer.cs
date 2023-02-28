using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string dateOfBirth { get; set; }
        public string dateOfJoin { get; set; }
        public List<PurchaseReport> purchaseReports = new List<PurchaseReport>();

        public Customer(string firstName, string surname, string id, string phoneNumber, string eMail, string dateOfBirth, string dateofJoin)
        {
            FirstName = firstName;
            Surname = surname;
            Id = id;
            PhoneNumber = phoneNumber;
            EMail = eMail;
            this.dateOfBirth = dateOfBirth;
            this.dateOfJoin = dateofJoin;
        }

        public void AddPurchse(AbstractItem item, double paid)
        {
            purchaseReports.Add(new PurchaseReport(item, paid));
            PCS.Instance.Save();
        }

        public List<PurchaseReport> GetPurchaseHistory()
        {
            return purchaseReports;
        }
    }
}
