using System;
using System.Collections.Generic;
using System.Linq;
using OOPLab2.Interface;

namespace OOPLab2.Model
{
    class Product: IProduct
    {
        public string Name { get; }
        public string Category { get; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product() { }
        public Product(string name, string category, decimal price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
        public override string ToString() => $"Товар: {Name, -25} Цена: {Price:f2} руб.";
    }
}
