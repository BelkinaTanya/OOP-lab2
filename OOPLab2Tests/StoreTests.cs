using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2.Tests
{
    [TestClass]
    public class StoreTests
    {
        private string title = "Department store";
        private Store store = new Store();

        [TestMethod]
        public void Title_IsNotNull()
        {
            Store store = new Store(title);
            Assert.IsNotNull(title);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Title_IsNull()
        {
            Store store = new Store(null);
        }

        [TestMethod]
        public void PrintDepartments_ListDepartmens_ContainDepartment()
        {            
            Department department1 = new Department("Одежда");
            Department department2 = new Department("Обувь");
            Department department3 = new Department("Игрушки");
            store.Add(department1);
            store.Add(department2);
            store.Add(department3);
            CollectionAssert.Contains(store, department1);
            CollectionAssert.Contains(store, department2);
            CollectionAssert.Contains(store, department3);
        }
    }
}
