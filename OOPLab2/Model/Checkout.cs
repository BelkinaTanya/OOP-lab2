using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPLab2.Model
{
    class Checkout
    {
        public Customer Customer { get; set; }
        private Basket paymentList = new Basket();
        public Checkout(string name, string address)
        {
            Customer = new Customer { Name = name, DeliveryAddress = address };
        }
        public void AddPaymentList(Basket basket)
        {
            foreach (BasketLine basketLine in basket.lines)
            {
                paymentList.AddItem(basketLine.Product);
            }
        }
        public decimal GetPaymentAmount()
        {
            if (paymentList.lines.FirstOrDefault() != null)
                return paymentList.TotalCost();
            else
            {
                Console.WriteLine("Корзина пуста!");
                return 0;
            }
        }
        public void PrintPaymentList()
        {

            if (paymentList == null)
            {
                Console.WriteLine("Товаров к оплате нет!");
            }
            else
            {
                int index = 1;
                Console.WriteLine("   Наименование         цена, р.   количество      Сумма, р.");
                foreach (BasketLine basketLine in paymentList.lines)
                {
                    Console.WriteLine($"{index++}. {basketLine}");
                }
                Console.WriteLine("                                   Сумма к оплпте: {0:f2}", GetPaymentAmount());
            }
        }
    }
}
