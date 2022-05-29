using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace File_Cabinet.Serializer
{
    public class MyJsonSerializer<T> : ISerialize<T> where T : class
    {
        private readonly string _path;

        public MyJsonSerializer(string path)
        {
            _path = path;
        }

          public void Serialize(T data)
          {
              File.WriteAllText(_path, JsonSerializer.Serialize(data));
          }

          public T Deserialize()
          {
              return JsonSerializer.Deserialize<T>(File.ReadAllText(_path));
          }
    }
}
