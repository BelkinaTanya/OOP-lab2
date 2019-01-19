using System;
using System.Collections.Generic;
using System.Linq;


namespace OOPLab2.Model
{
     public class Store: IDisposable
     {
        private string _title;
        private List<Department> _departments;
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
            _departments = new List<Department>();
        }
        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }
        public void RemoveDepartment(Department department)
        {
            _departments.Remove(department);
        }
        public void ClearAllListDepartment()
        {
            _departments.Clear();
        }
        public void Dispose()
        {
            Dispose();
        }       
        public void PrintDepartments()
        {
            int index = 1;
           foreach(Department department in _departments)
            {
                Console.WriteLine($"{index++}. {department}");
            } 
        }
        public List<Department> GetListDepartments()
        {           
            return _departments; 
        }
    }
}
