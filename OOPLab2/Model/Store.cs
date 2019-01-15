using System;
using System.Collections.Generic;
using System.Linq;


namespace OOPLab2.Model
{
    class Store: List<Department>, IDisposable
    {
        private string _title;
        private List<Department> departments;
        public string Title
        {
            get => _title;
            set => _title = value ??
                throw new ArgumentNullException("Name cannot be null", nameof(value));
        }
        public Store() { }
        public Store(string title)
        {
            Title = title;
            departments = new List<Department>();
        }
        public void Dispose()
        {
            this.Dispose();
        }
        public void PrintDepartments()
        {
            int index = 1;
           foreach(Department department in this)
            {
                Console.WriteLine($"{index++}. {department}");
            } 
        }
    }
}
