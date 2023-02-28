using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    public class PCS
    {
        public static PCS Instance { get; } = new PCS();
        private JsonManager<Customer> _jsonManager;
        private List<Customer> _customersList;
        private PCS()
        {
            List<Customer> customers = new List<Customer>();
            _jsonManager = new JsonManager<Customer>("/PCSData.txt", _customersList);
            _customersList = _jsonManager.DeSerialze();
            if (_customersList == null)
            {
                _customersList = new List<Customer>();
            }

        }
        public void Save()
        {
            _jsonManager.Serialze();
        }

        public void AddCustomer(string firstname, string surname, string id, string phone, string email, DateTimeOffset birthday, string dateOfJoin)
        {
            _customersList.Add(new Customer(firstname, surname, id, phone, email, birthday.Date.ToString(), dateOfJoin));
            _jsonManager.Serialze();
        }
        public void RemoveCustomer(string id)
        {
            _customersList.ForEach(T => { if (T.Id.Equals(id)) _customersList.Remove(T); }); 
            _jsonManager.Serialze();
        }

        public Customer GetCustomer(string id)
        {
            foreach (var customer in _customersList)
            {
                if (customer.Id.Equals(id))
                {
                    return customer;
                }
            }
            return null;
        }



    }
}
