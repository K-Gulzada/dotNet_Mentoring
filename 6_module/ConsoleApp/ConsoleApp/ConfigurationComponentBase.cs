//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using Provider.Plugins;

using ConsoleApp.Provider;

namespace ConsoleApp
{
    // ConfigurationManagerConfigurationProvider
    public class ConfigurationComponentBase
    {
        [ConfigurationItem(SettingName = "Setting_1", ProviderType = "File_Configuration_Provider")]
        public FileConfigurationProvider fileConfigurationProvider { get; set; }

        [ConfigurationItem(SettingName = "Setting_2", ProviderType = "Configuration_Manager_Configuration_Provider")]
        public ConfigurationManagerConfigurationProvider configurationManagerConfigurationProvider { get; set; }

        public ConfigurationComponentBase(FileConfigurationProvider fileConfigurationProvider,
                                          ConfigurationManagerConfigurationProvider configurationManagerConfigurationProvider)
        {
            this.fileConfigurationProvider = fileConfigurationProvider;
            this.configurationManagerConfigurationProvider = configurationManagerConfigurationProvider;
        }

        public void SaveSettings(object? value)
        {
            var properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(ConfigurationItemAttribute), false);

                foreach (var attribute in attributes)
                {
                    if (attribute is ConfigurationItemAttribute configurationAttribute)
                    {
                        switch (configurationAttribute.ProviderType)
                        {
                            case "File_Configuration_Provider":
                                fileConfigurationProvider.SaveSettings(property, value);
                                break;

                            case "Configuration_Manager_Configuration_Provider":
                                configurationManagerConfigurationProvider.SaveSettings(property, value);
                                break;

                        }
                    }
                }
            }


        }

        public void LoadSettings()
        {
            var properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(ConfigurationItemAttribute), false);

                foreach (var attribute in attributes)
                {
                    if (attribute is ConfigurationItemAttribute configurationAttribute)
                    {
                        switch (configurationAttribute.ProviderType)
                        {
                            case "File_Configuration_Provider":
                                fileConfigurationProvider.LoadSettings(property);
                                break;

                            case "Configuration_Manager_Configuration_Provider":
                                configurationManagerConfigurationProvider.LoadSettings(property);
                                break;

                        }
                    }
                }
            }

        }

        public void Test()
        {
            var type = this.GetType();

            // Get the PropertyInfo object:
            var properties = this.GetType().GetProperties();
            Console.WriteLine("Finding properties for {0} ...", type.Name);
            foreach (var property in properties)
            {
                Console.WriteLine("Property:  " + property.Name);

                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(attribute.ToString());
                    Console.ResetColor();
                }
            }
        }
    }
}
