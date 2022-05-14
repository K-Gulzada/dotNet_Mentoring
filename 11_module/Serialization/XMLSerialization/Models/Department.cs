using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLSerialization.Models
{
    [Serializable]
    public class Department
    {
        [XmlElement(ElementName = "departmentName")]
        public string DepartmentName { get; set; }
        [XmlElement(ElementName = "employees")]
        public List<Employee> Employees { get; set; }
    }
}
