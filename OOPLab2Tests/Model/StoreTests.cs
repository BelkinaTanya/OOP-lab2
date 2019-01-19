using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class StoreTests
    {
        private string title = "Department store";
        
        [TestMethod]
        public void Title_IsNotNull()
        {
            Store store = new Store(title);
            Assert.AreEqual(title, store.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Title_IsNull()
        {
            Store store = new Store(null);
        }

        [TestMethod]
        public void AddDepartmentTest()
        {
            Store store = new Store(title);
            Department department = new Department("Одежда");

            store.AddDepartment(department);

            Assert.IsTrue(store.GetListDepartments().Contains(department));
        }

        [TestMethod]
        public void RemoveDepartmentTest()
        {
            Store store = new Store(title);
            Department department = new Department("Одежда");
            store.AddDepartment(department);

            store.RemoveDepartment(department);

            Assert.IsFalse(store.GetListDepartments().Contains(department));
        }

        [TestMethod]
        public void ClearAllListDepartmentTest()
        {
            Store store = new Store(title);
            Department department1 = new Department("Одежда");
            Department department2 = new Department("Игрушки");
            Department department3 = new Department("Бытовая техника");
            store.AddDepartment(department1);
            store.AddDepartment(department2);
            store.AddDepartment(department3);

            store.ClearAllListDepartment();

            Assert.AreEqual(0, store.GetListDepartments().Count);
        }

        [TestMethod]
        public void GetListDepartmentTest()
        {
            Store store = new Store(title);
            Department department1 = new Department("Одежда");
            Department department2 = new Department("Игрушки");
            Department department3 = new Department("Бытовая техника");
            store.AddDepartment(department1);
            store.AddDepartment(department2);
            store.AddDepartment(department3);

            List<Department> departments = store.GetListDepartments();

            Assert.IsTrue(departments.Contains(department1), "Ошибка: в списке отсутствует отдел №1");
            Assert.IsTrue(departments.Contains(department2), "Ошибка: в списке отсутствует отдел №2");
            Assert.IsTrue(departments.Contains(department3), "Ошибка: в списке отсутствует отдел №3");
        }
    }
} 
