using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace File_Cabinet.Serializer
{
    public interface ISerialize<T> where T : class
    {
        public void Serialize(T data);

        public T Deserialize();
    }
}
