using System;

namespace DeepCloningWithSerializartion.Models
{
    [Serializable]
    public class Employee
    {
        public string EmployeeName { get; set; }
        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }
    }
}
