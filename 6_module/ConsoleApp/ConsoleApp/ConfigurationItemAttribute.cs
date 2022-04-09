

namespace ReflectionModule
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; set; } 
        public string ProviderType { get; set; }
    }
}
