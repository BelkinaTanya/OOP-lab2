using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OOPLab2.Model
{
    public static class ServiceSerializationDB
    {
        public static void SerializeObjectInXML(List<Product> products, string pathToFile)
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, products);
            }
        }
        public static List<Product> DeserializeObject(string pathToFile)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                List<Product> newProducts = (List<Product>)formatter.Deserialize(fs);                
                return newProducts;
            }
        }
    }
}
