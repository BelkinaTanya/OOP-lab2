using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPLab2.Model;

namespace OOPLab2Tests.Model
{
    [TestClass]
    public class CategoryTests
    {
        private string title = "Category";

        [TestMethod]
        public void Title_IsNotNull()
        {
            Category category = new Category(title);
            Assert.AreEqual(title, category.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Title_IsNull()
        {
            Category category = new Category(null);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Category category = new Category(title);

            string rezult = category.ToString();

            Assert.AreEqual(rezult, title);
        }        
    }
}
