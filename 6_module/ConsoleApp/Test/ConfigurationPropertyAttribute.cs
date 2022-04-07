using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ConfigurationPropertyAttribute : Attribute
    {
        private string Name { get; set; }
        private string DefaultValue { get; set; }
        private bool IsRequired { get; set; }
        private bool IsKey { get; set; }

        public ConfigurationPropertyAttribute(string Name, string DefaultValue, bool IsRequired, bool IsKey)
        {
            this.Name = Name;
            this.DefaultValue = DefaultValue;
            this.IsRequired = IsRequired;
            this.IsKey = IsKey;
        }

        public ConfigurationPropertyAttribute(string name, string defaultValue, bool isRequired)
        {
            Name = name;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
        }
    }
}
