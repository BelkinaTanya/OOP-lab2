using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class CheckoutTests
    {
        private Customer customer = new Customer { Name = "Иванов Иван", DeliveryAddress = "г.Москва, ул. Советская" };
        private Basket paymentList = new Basket();
        private Product product = new Product("Кукла", "Игрушки", 300, 20);
        private Product product2 = new Product("Пылесос", "Бытовая техника", 600, 10);
        Checkout checkout = new Checkout();

        [TestMethod]
        public void AddCustomerTest()
        {
            checkout.AddCustomer(customer);

            Assert.IsTrue(checkout.GetInfoCustomer().Contains(customer.Name));
            Assert.IsTrue(checkout.GetInfoCustomer().Contains(customer.DeliveryAddress));
        }

        [TestMethod]
        public void AddPaymentListTest()
        {
            paymentList.AddItem(product);
            paymentList.AddItem(product2);

            checkout.AddPaymentList(paymentList);

            Assert.IsTrue(checkout.GetPaymentList().lines.Contains(checkout.GetPaymentList().lines.Where(p => p.Product.Name == product.Name).FirstOrDefault()));
            Assert.IsTrue(checkout.GetPaymentList().lines.Contains(checkout.GetPaymentList().lines.Where(p => p.Product.Name == product2.Name).FirstOrDefault()));
        }

        [TestMethod]
        public void GetInfoCustomerTest()
        {
            checkout.AddCustomer(customer);

            string rezult = checkout.GetInfoCustomer();

            Assert.AreEqual(rezult, customer.ToString());
        }

        [TestMethod]
        public void GetPaymentListTest()
        {
            paymentList.AddItem(product);
            paymentList.AddItem(product2);
            checkout.AddPaymentList(paymentList);

            var rezult = checkout.GetPaymentList();

            Assert.AreEqual(rezult.lines.Count(), 2);
        }

        [TestMethod]
        public void GetPaymentAmountTest_300Plus600_Returns900()
        {
            paymentList.AddItem(product);
            paymentList.AddItem(product2);
            checkout.AddPaymentList(paymentList);

            var rezult = checkout.GetPaymentAmount();

            Assert.AreEqual(rezult, 900);
        }

        [TestMethod]
        public void GetPaymentAmountTest_EmptyList_Returns0()
        {
            var rezult = checkout.GetPaymentAmount();

            Assert.AreEqual(rezult, 0);
        }


    }
}
