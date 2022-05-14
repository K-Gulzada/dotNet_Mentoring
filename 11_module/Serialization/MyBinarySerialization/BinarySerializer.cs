using SerializerService;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyBinarySerialization
{
    public class BinarySerializer : ISerialize<Employee>
    {
        private readonly string _path;
        public BinarySerializer(string path)
        {
            _path = path;
        }

        public void Serialize(Employee employee)
        {
            using (FileStream stream = new FileStream(
                path: _path,
                mode: FileMode.Create,
                access: FileAccess.Write))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(stream, employee);
            }
        }
        public Employee Deserialize()
        {
            using (FileStream stream = new FileStream(
                 path: _path,
                 mode: FileMode.Open,
                 access: FileAccess.Read))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                return (Employee)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
