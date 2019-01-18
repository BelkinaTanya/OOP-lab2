using System;
using System.Collections.Generic;
using System.Linq;

//using OOPLab2.Interface;

namespace OOPLab2.Model
{
    public class Category
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => _title = value ??
                throw new ArgumentNullException("Name cannot be null", nameof(value));
        }
        public Category() { }
        public Category(string title)
        {
            Title = title;
        }
        public override string ToString()
        {
            return Title;
        }
      
    }
}
