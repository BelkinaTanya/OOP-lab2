using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Model
{
    public class Basket
    {
        List<BasketLine> basketLines = new List<BasketLine>();
        public Basket() { }
        public void AddItem(Product product)
        {
            BasketLine line = basketLines.Where(p => p.Product.Name == product.Name).FirstOrDefault();
            if (line == null)
            {
                basketLines.Add(new BasketLine
                {
                    Product = product,
                    QuantityOfGoods = 1 
                });
            }
            else
            {
                line.QuantityOfGoods += 1;
            }
        }
        public void RemoveLine(Product product)
        {
            basketLines.RemoveAll(l => l.Product.Name == product.Name);
        }
        public decimal TotalCost()
        {
            return basketLines.Sum(s => s.Product.Price * s.QuantityOfGoods);
        }
        public void Clear()
        {
            basketLines.Clear();
        }
        public IEnumerable<BasketLine> lines
        {
            get { return basketLines; }
        }
        public void PrintBasket()
        {
            if (this.basketLines.FirstOrDefault() == null)
            {
                Console.WriteLine("Товаров в корзине нет!");
            }
            else
            {
                int index = 1;
                Console.WriteLine("                   КОРЗИНА");
                Console.WriteLine("   Наименование         цена, р.   количество      Сумма, р.");
                foreach (BasketLine basketLine in basketLines)
                {
                    Console.WriteLine($"{index++}. {basketLine}");
                }
                Console.WriteLine("                              Общая сумма товаров: {0:f2}", TotalCost());
            }
        }
    }
}
