using BinarySerialization.Models;
using BinarySerialization.Seed;
using System;

namespace BinarySerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = SeedExtension.CreateDefaultDataForDepartment();
            var binarySerializer = new BinarySerializer("department.bin");
            binarySerializer.Serialize(department);
            var deserializedDepartment = binarySerializer.Deserialize();
            Console.WriteLine(deserializedDepartment.DepartmentName);

            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine(employee.EmployeeName);
            }
        }
    }
}
