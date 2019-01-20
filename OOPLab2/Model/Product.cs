using System;
using System.Collections.Generic;
using System.Linq;
using OOPLab2.Interface;

namespace OOPLab2.Model
{
    [Serializable]
    public class Product: IProduct, IDisposable
    {
        private string _name;
        private string _category;
        private decimal _price;
        private int _quantity;
        public string Name
        {
            get => _name;
            set => _name = value ??
               throw new ArgumentNullException("Name cannot be null", nameof(value));
        }
        public string Category
        {
            get => _category;
            set => _category = value ??
               throw new ArgumentNullException("Name cannot be null", nameof(value));
        }
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Price must be greater than zero");
                _price = value;
            }     
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Quantity must be greater than zero");
                _quantity = value;
            }
        }
        public Product() { }
        public Product(string name, string category, decimal price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
        public override string ToString() => $"Товар: {Name, -25} Цена: {Price:f2} руб.";
        public void Dispose()
        {
            Dispose();
        }
    }
}
