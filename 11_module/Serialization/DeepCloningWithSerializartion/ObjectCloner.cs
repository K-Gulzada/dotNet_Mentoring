using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeepCloningWithSerializartion
{
    public static class ObjectCloner
    {
        public static T Clone<T>(this T source)
        {
            if (typeof(T).IsSerializable)
            {
                using (Stream stream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    binaryFormatter.Serialize(stream, source);
                    stream.Position = 0;

                    return (T)binaryFormatter.Deserialize(stream);
                }
            }

            return default;
        }
    }
}
