using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class DepartmentTests
    {
        private string title = "Department";

        [TestMethod]
        public void Title_IsNotNull()
        {
            Department department = new Department(title);
            Assert.AreEqual(title, department.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Title_IsNull()
        {
            Department department = new Department(null);
        }

        [TestMethod]
        public void AddCategoryTest()
        {
            Department department = new Department(title);
            Category category = new Category("Детская одежда");

            department.AddCategory(category);

            Assert.IsTrue(department.GetListCategories().Contains(category));
        }

        [TestMethod]
        public void RemoveCategoryTest()
        {
            Department department = new Department(title);
            Category category = new Category("Детская одежда");
            department.AddCategory(category);

            department.RemoveCategory(category);

            Assert.IsFalse(department.GetListCategories().Contains(category));
        }

        [TestMethod]
        public void ClearAllListCategoryTest()
        {
            Department department = new Department(title);
            Category category1 = new Category("Детская одежда");
            department.AddCategory(category1);
            Category category2 = new Category("Женская одежда");
            department.AddCategory(category2);

            department.ClearAllListCategory();

            Assert.AreEqual(0, department.GetListCategories().Count);
        }

        [TestMethod]
        public void GetListDepartmentTest()
        {
            Department department = new Department(title);
            Category category1 = new Category("Детская одежда");
            department.AddCategory(category1);
            Category category2 = new Category("Женская одежда");
            department.AddCategory(category2);
            Category category3 = new Category("Мужская одежда");
            department.AddCategory(category3);

            List<Category> categories = department.GetListCategories();

            Assert.IsTrue(categories.Contains(category1), "Ошибка: в списке отсутствует категория \"Детская одежда\"");
            Assert.IsTrue(categories.Contains(category2), "Ошибка: в списке отсутствует категория \"Женская одежда\"");
            Assert.IsTrue(categories.Contains(category3), "Ошибка: в списке отсутствует категория \"Мужская одежда\"");
        }

        [TestMethod]
        public void EqualsTest_ObjNull_ReturnsFalse()
        {
            Department department1 = new Department(title);
            Department department2 = null;

            Assert.IsFalse(department1.Equals(department2));
        }

        [TestMethod]
        public void EqualsTest_ObjIsNotDepartment_ReturnsFalse()
        {
            Department department1 = new Department(title);
            Category department2 = new Category(title);

            Assert.IsFalse(department1.Equals(department2));
        }

        [TestMethod]
        public void EqualsTest_ObjIsDepartment_ReturnsTrue()
        {
            Department department1 = new Department(title);
            Department department2 = new Department(title);

            Assert.IsTrue(department1.Equals(department2));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Department department1 = new Department(title);
            Category category1 = new Category("Игрушки");
            department1.AddCategory(category1);
            Department department2 = new Department(title);
            Category category2 = new Category("Парфюмерия");
            department2.AddCategory(category2);

            Assert.AreEqual(department1.GetHashCode(), department2.GetHashCode());
        }        
    }
}
