using System;
using XMLSerialization.Models;
using XMLSerialization.Seed;

namespace XMLSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = SeedExtension.CreateDefaultDataForDepartment();
            var jsonSerializer = new MyXmlSerializer("department.xml");
            jsonSerializer.Serialize(department);

            var deserializedDepartment = jsonSerializer.Deserialize();
            Console.WriteLine(deserializedDepartment.DepartmentName);

            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine(employee.EmployeeName);
            }
        }
    }
}
