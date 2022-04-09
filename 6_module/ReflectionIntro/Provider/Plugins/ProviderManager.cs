using System.Configuration;
using System.Reflection;

namespace Provider.Plugins
{
    public abstract class ProviderManager
    {
        public object? Value { get; set; }
        protected ProviderManager() { }
        public ProviderManager(object value)
        {
            Value = value;
        }

        public virtual void SaveSettings(PropertyInfo propertyInfo, object value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(propertyInfo.Name, value.ToString());

            if (config.AppSettings.Settings[$"{propertyInfo.Name}"] == null)
            {
                config.AppSettings.Settings.Add(propertyInfo.Name, value.ToString());
            }
            else
            {
                config.AppSettings.Settings[$"{propertyInfo.Name}"].Value = value.ToString();
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }
        public virtual void LoadSettings(PropertyInfo propertyInfo)
        {
            var appSettings = ConfigurationManager.AppSettings;

            if (appSettings.Count == 0)
            {
                Console.WriteLine("AppSettings is empty.");
            }
            else
            {
                Console.WriteLine("Key: {0} Value: {1}", propertyInfo.Name, appSettings[propertyInfo.Name]);
            }
        }
    }
}
