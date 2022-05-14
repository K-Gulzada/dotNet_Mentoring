using DeepCloningWithSerializartion.Models;
using DeepCloningWithSerializartion.Seed;
using System;

namespace DeepCloningWithSerializartion
{
    class Program
    {
        static void Main(string[] args)
        {
            var department = SeedExtension.CreateDefaultDataForDepartment();
            Department clonedDepartment = department.Clone();

            string message = ReferenceEquals(department, clonedDepartment) ? "successfully deep cloned" : "Failed to deep clone";
            Console.WriteLine(message);
        }
    }
}
