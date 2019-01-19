using System;
using System.Collections.Generic;
using System.Linq;


namespace OOPLab2.Model
{
    public class Department
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => _title = value ??
                throw new ArgumentNullException("Name cannot be null", nameof(value));
        }
        private List<Category> _categories; 
        public Department() { }
        public Department (string title)
        {
            Title = title;
            _categories = new List<Category>();
        }
        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }
        public void RemoveCategory(Category category)
        {
            _categories.Remove(category);
        }
        public void ClearAllListCategory()
        {
            _categories.Clear();
        }
        public List<Category> GetListCategories()
        {
            return _categories;
        }
        public override string ToString()
        {
            return Title;
        }
        public void PrintCategories()
        {
            int index = 1;
            foreach (Category category in _categories)
            {
                Console.WriteLine($"{index++}. {category}");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var department = obj as Department;
            if (department == null)
                return false;
            return department.Title == Title;
        }
        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}
