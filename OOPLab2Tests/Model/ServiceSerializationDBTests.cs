using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class ServiceSerializationDBTests
    {
        private List<Product> products1 = new List<Product>();
        private List<Product> products2 = new List<Product>();  

        [TestInitialize]
        public void Initialize()
        {
            Product product1 = new Product("Кукла", "Игрушки", 300, 20);
            Product product2 = new Product("Пылесос", "Бытовая техника", 6500, 10);
            products1.Add(product1);
            products1.Add(product2);            
        }

        [TestMethod]
        public void SerializeTest_Count()
        {
            string pathFile = "FileXML1.xml";
            ServiceSerializationDB.SerializeObjectInXML(products1, pathFile);
            products2 = ServiceSerializationDB.DeserializeObject(pathFile);

            Assert.AreEqual(products1.Count, products2.Count);
        }
    }
}

