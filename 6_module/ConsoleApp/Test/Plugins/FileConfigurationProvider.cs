using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.Provider
{
    public class FileConfigurationProvider : IProvider
    {

        public void LoadSettings(PropertyInfo propertyInfo)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings[propertyInfo.Name] == String.Empty)
                {
                    Console.WriteLine("AppSettings[propertyInfo.Name] is empty.");
                }
                else
                {
                    Console.WriteLine("Key: {0} Value: {1}", propertyInfo.Name, appSettings[propertyInfo.Name]);

                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public void SaveSettings(PropertyInfo propertyInfo, object? value)
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
    }
}
