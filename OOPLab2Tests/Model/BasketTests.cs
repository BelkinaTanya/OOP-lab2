using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class BasketTests
    {       
        private Basket basket = new Basket();
        private List<BasketLine> basketLines = new List<BasketLine>();
        private Product product = new Product("Кукла", "Игрушки", 300, 20);
        private Product product2 = new Product("Пылесос", "Бытовая техника", 6500, 10);

        [TestMethod]
        public void AddItemTest_NoItem()
        {
            basket.AddItem(product);
            var rezult = basket.lines.Where(p => p.Product.Name == product.Name).FirstOrDefault().QuantityOfGoods;

            Assert.AreEqual(rezult, 1);
        }

        [TestMethod]
        public void AddItemTest_1ItemPlus1_Returns2()
        {
            basket.AddItem(product);
            basket.AddItem(product);
            var rezult = basket.lines.Where(p => p.Product.Name == product.Name).FirstOrDefault().QuantityOfGoods;

            Assert.AreEqual(rezult, 2);
        }

        [TestMethod]
        public void RemoveLineTest()
        {
            basket.AddItem(product);
            basket.AddItem(product2);

            basket.RemoveLine(product2);
            var rezult = basket.lines.Contains(basket.lines.Where(p => p.Product.Name == product2.Name).FirstOrDefault());

            Assert.IsFalse(rezult);  
        }

        [TestMethod]
        public void ClearTest()
        {
            basket.AddItem(product);
            basket.AddItem(product);
            basket.AddItem(product2);

            basket.Clear();

            Assert.AreEqual(basket.lines.Count(), 0);
        }
    }
}
