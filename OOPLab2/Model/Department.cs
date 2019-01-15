using System;
using System.Collections.Generic;
using System.Linq;


namespace OOPLab2.Model
{
    class Department: List<Category>
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => _title = value ??
                throw new ArgumentNullException("Name cannot be null", nameof(value));
        }
        private List<Category> categories; 
        public Department() { }
        public Department (string title)
        {
            Title = title;
            categories = new List<Category>();
        }
        public override string ToString()
        {
            return Title;
        }
        public void PrintCategories()
        {
            int index = 1;
            foreach (Category category in this)
            {
                Console.WriteLine($"{index++}. {category}");
            }
        }
    }
}
