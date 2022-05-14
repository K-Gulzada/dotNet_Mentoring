using System;
using System.Runtime.Serialization;

namespace MyBinarySerialization
{
    [Serializable]
    public class Employee : ISerializable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Employee(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            this.FirstName = (string)serializationInfo.GetValue(
                name: "FirstName",
                type: typeof(string));

            this.LastName = (string)serializationInfo.GetValue(
                name: "LastName",
                type: typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", this.FirstName);
            info.AddValue("LastName", this.LastName);
        }
    }
}
