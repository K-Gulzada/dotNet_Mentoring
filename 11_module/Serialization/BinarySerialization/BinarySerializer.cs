using BinarySerialization.Models;
using SerializerService;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    public class BinarySerializer : ISerialize<Department>
    {
        private readonly string _path;
        public BinarySerializer(string path)
        {
            _path = path;
        }

        public void Serialize(Department department)
        {
            using (FileStream stream = new FileStream(
                path: _path,
                mode: FileMode.Create,
                access: FileAccess.Write))
            {
                IFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, department);
            }
        }
        public Department Deserialize()
        {
            using (FileStream stream = new FileStream(
                 path: _path,
                 mode: FileMode.Open,
                 access: FileAccess.Read))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                return (Department)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
