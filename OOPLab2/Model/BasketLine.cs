using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPLab2.Interface;

namespace OOPLab2.Model
{
    class BasketLine
    {
        public Product Product { get; set; }
        public int QuantityOfGoods { get; set; }
        private decimal TotalSum()
        {
          
            return Product.Price * QuantityOfGoods;
        }

        public override string ToString()
        {
            return $"{Product.Name, -20} {Product.Price, -15:f2}  {QuantityOfGoods,-10}{TotalSum():f2}";
        }

    }
}
