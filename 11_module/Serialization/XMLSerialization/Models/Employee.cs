using System;
using System.Xml.Serialization;

namespace XMLSerialization.Models
{
    [Serializable]
    public class Employee
    {
        [XmlElement(ElementName = "employeeName")]
        public string EmployeeName { get; set; }
        public Employee() { }
        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }
    }
}
