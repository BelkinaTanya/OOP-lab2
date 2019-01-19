using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class ProductTests
    {
        private string name = "Кукла";
        private string category = "Игрушки";
        private decimal price = 300;
        private int quantity = 10;

        [TestMethod]
        public void Name_IsNotNull()
        {
            Product product = new Product(name, category, price, quantity);
            Assert.AreEqual(name, product.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_IsNull()
        {
            Product product = new Product(null, category, price, quantity);
        }

        [TestMethod]
        public void Category_IsNotNull()
        {
            Product product = new Product(name, category, price, quantity);
            Assert.AreEqual(category, product.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Category_IsNull()
        {
            Product product = new Product(name, null, price, quantity);
        }

        [TestMethod]
        public void Price_AboveZero()
        {
            Product product = new Product(name, category, price, quantity);
            Assert.AreEqual(price, product.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Price_LessThenZero()
        {
            Product product = new Product(name, category, -300, quantity);
        }

        [TestMethod]
        public void Quantity_AboveZero()
        {
            Product product = new Product(name, category, price, quantity);
            Assert.AreEqual(quantity, product.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Quantity_LessThenZero()
        {
            Product product = new Product(name, category, price, -10);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Product product = new Product(name, category, price, quantity);

            string rezult = product.ToString();

            Assert.IsTrue(rezult.Contains(name), "Ошибка в наименовании товара");
            Assert.IsTrue(rezult.Contains(price.ToString()), "Ошибка в поле - цена");
        }        
    }
}
