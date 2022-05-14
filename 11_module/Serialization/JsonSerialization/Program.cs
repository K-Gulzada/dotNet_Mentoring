using JsonSerialization.Models;
using JsonSerialization.Seed;
using System;

namespace JsonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var department = SeedExtension.CreateDefaultDataForDepartment();
            var jsonSerializer = new MyJsonSerializer("department.json");
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
