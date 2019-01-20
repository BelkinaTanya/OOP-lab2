using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPLab2.Model
{
    public class Checkout
    {
        private Customer _customer = new Customer();
        private Basket _paymentList = new Basket();
        public Checkout() { }
        public void AddCustomer(Customer customer)
        {
            _customer = customer;
        }
        public void AddPaymentList(Basket basket)
        {
            foreach (BasketLine basketLine in basket.lines)
            {
                _paymentList.AddItem(basketLine.Product);
            }
        }
        public string GetInfoCustomer()
        {
            return _customer.ToString();
        }
        public Basket GetPaymentList()
        {
            return _paymentList;
        }
        public decimal GetPaymentAmount()
        {
            if (_paymentList.lines.FirstOrDefault() != null)
                return _paymentList.TotalCost();
            else
            {
                Console.WriteLine("Корзина пуста!");
                return 0;
            }
        }
        public void PrintPaymentList()
        {

            if (_paymentList == null)
            {
                Console.WriteLine("Товаров к оплате нет!");
            }
            else
            {                
                _paymentList.PrintBasket();
                Console.WriteLine(GetInfoCustomer());
            }
        }
    }
}
