using JsonSerialization.Models;
using System.Text.Json;
using SerializerService;
using System.IO;

namespace JsonSerialization
{
    public class MyJsonSerializer : ISerialize<Department>
    {
        private readonly string _path;

        public MyJsonSerializer(string path)
        {
            _path = path;
        }

        public void Serialize(Department department)
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(department));
        }

        public Department Deserialize()
        {
            return JsonSerializer.Deserialize<Department>(File.ReadAllText(_path));
        }
    }
}
