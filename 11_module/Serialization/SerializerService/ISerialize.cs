using System;

namespace SerializerService
{
    public interface ISerialize<T> where T : class
    {
        void Serialize(T data);
        T Deserialize();
    }
}
