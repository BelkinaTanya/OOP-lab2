using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class CustomerTests
    {
        private string name = "Иванов Иван";
        private string address = "г.Москва, ул. Советская";
        private Customer customer = new Customer();

        [TestMethod]
        public void ToStringTest()
        {
            customer.Name = name;
            customer.DeliveryAddress = address;

            string rezult = customer.ToString();

            Assert.IsTrue(rezult.Contains(name), "Ошибка в имени покупателя");
            Assert.IsTrue(rezult.Contains(address), "Ошибка в поле - адрес");
        }
    }
}
