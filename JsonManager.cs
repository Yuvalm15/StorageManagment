using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;

namespace Bookstore_DB
{
    internal class JsonManager<T>
    {
        private string _path;
        private List<T> _collection;

        public JsonManager(string path, List<T> collection)
        {
            _path = path;
            _collection = collection;
        }
        public void Serialze()
        {
            // get folder
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            // create file
            string path = folder.Path + _path;

            // for visual
            var format = Newtonsoft.Json.Formatting.Indented;

            // for Inheritance
            var setting = new JsonSerializerSettings();
            setting.TypeNameHandling = TypeNameHandling.Auto;

            // convert from object to string (Json style);
            string strToSave = JsonConvert.SerializeObject(_collection, format, setting);

            // write string to file 
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(strToSave);
            }


        }
        public List<T> DeSerialze()
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            string path = folder.Path + _path;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    var setting = new JsonSerializerSettings();
                    setting.TypeNameHandling = TypeNameHandling.Auto;
                    _collection = JsonConvert.DeserializeObject<List<T>>(json, setting);
                }
            }
            else
            {
                _collection = new List<T>();
            }
            return _collection;
        }
    }
}
