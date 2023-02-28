using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_DB
{
    internal class Discount
    {
        public string Name { get; set; }
        public string type { get; set; }
        public double Precent { get; set; }
        public string Date { get; set; }
        private Dictionary<string, object> storedValues;

        public event PropertyChangedEventHandler PropertyChanged;
        public Discount()
        {

        }
        public void RaisePropertyChanged(string propName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void BeginEdit()
        {
            this.storedValues = this.BackUp();
        }

        public void CancelEdit()
        {

            if (this.storedValues == null)
                return;

            foreach (var item in this.storedValues)
            {
                var itemProperties = this.GetType().GetTypeInfo().DeclaredProperties;
                var pDesc = itemProperties.FirstOrDefault(p => p.Name == item.Key);

                if (pDesc != null)
                    pDesc.SetValue(this, item.Value);
            }

        }

        public void EndEdit()
        {

            if (this.storedValues != null)
            {
                this.storedValues.Clear();
                this.storedValues = null;
            }

        }

        protected Dictionary<string, object> BackUp()
        {
            var dictionary = new Dictionary<string, object>();
            var itemProperties = this.GetType().GetTypeInfo().DeclaredProperties;

            foreach (var pDescriptor in itemProperties)
            {

                if (pDescriptor.CanWrite)
                    dictionary.Add(pDescriptor.Name, pDescriptor.GetValue(this));
            }
            return dictionary;
        }

    }
}
