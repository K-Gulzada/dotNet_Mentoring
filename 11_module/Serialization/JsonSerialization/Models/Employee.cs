using System;

namespace JsonSerialization.Models
{
    [Serializable]
    public class Employee
    {
        public string EmployeeName { get; set; }
        public Employee() { }
        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }
    }
}
