using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public string DeliveryAddress { get; set; }
        public Customer() { }
        public Customer(string name, string deliveryAddress)
        {
            Name = name;
            DeliveryAddress = deliveryAddress;
        }
        public override string ToString()
        {
            return $"Информация о покупателе:\nИмя: {Name, -20} Адрес доставки: {DeliveryAddress}";
        }
    }
}
