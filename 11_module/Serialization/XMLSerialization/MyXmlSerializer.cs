using SerializerService;
using System.IO;
using System.Xml.Serialization;
using XMLSerialization.Models;

namespace XMLSerialization
{
    public class MyXmlSerializer : ISerialize<Department>
    {
        private readonly string _path;

        public MyXmlSerializer(string path)
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
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));

                xmlSerializer.Serialize(stream, department);
            }
        }

        public Department Deserialize()
        {
            using (FileStream stream = new FileStream(
                path: _path,
                mode: FileMode.Open,
                access: FileAccess.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));

                return (Department)xmlSerializer.Deserialize(stream);
            }
        }
    }
}
