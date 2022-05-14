using System;

namespace MyBinarySerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee("Jack", "Sparrow");
            var binarySerializer = new BinarySerializer("employee.bin");
            binarySerializer.Serialize(employee);
            var deserializedEmployee = binarySerializer.Deserialize();
            Console.WriteLine($"{deserializedEmployee.FirstName} {deserializedEmployee.LastName}");
        }
    }
}
