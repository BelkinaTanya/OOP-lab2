using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class BasketLineTests
    {
        private Product product = new Product("Кукла", "Игрушки", 300, 20);
        private int quantityOfGoods = 2;

        [TestMethod]
        public void TotalSumTest_300Multiply2_Returns600()
        {
            BasketLine basketLine = new BasketLine { Product = product, QuantityOfGoods = quantityOfGoods };

            decimal rezult = basketLine.TotalSum();

            Assert.AreEqual(rezult, 600);
        }

        [TestMethod]
        public void ToStringTest()
        {
            BasketLine basketLine = new BasketLine { Product = product, QuantityOfGoods = quantityOfGoods };

            string rezult = basketLine.ToString();

            Assert.IsTrue(rezult.Contains(product.Name), "Ошибка в наименовании товара");
            Assert.IsTrue(rezult.Contains(product.Price.ToString()), "Ошибка в поле - цена");
            Assert.IsTrue(rezult.Contains(quantityOfGoods.ToString()), "Ошибка в поле - количество");
            Assert.IsTrue(rezult.Contains(basketLine.TotalSum().ToString()), "Ошибка в поле - общая сумма");
        }
    }
}
