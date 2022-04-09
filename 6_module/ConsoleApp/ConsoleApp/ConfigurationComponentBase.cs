using Provider.Plugins;


namespace ReflectionModule
{
    public class ConfigurationComponentBase
    {
        [ConfigurationItem(SettingName = "Setting_1", ProviderType = "File_Configuration_Provider")]
        public FileConfigurationProvider? fileConfigurationProvider { get; set; }

        [ConfigurationItem(SettingName = "Setting_2", ProviderType = "Configuration_Manager_Configuration_Provider")]
        public ConfigurationManagerConfigurationProvider? configurationManagerConfigurationProvider { get; set; }
        public ConfigurationComponentBase(FileConfigurationProvider fileConfigurationProvider)
        {
            this.fileConfigurationProvider = fileConfigurationProvider;
        }
        public ConfigurationComponentBase(ConfigurationManagerConfigurationProvider configurationManagerConfigurationProvider)
        {
            this.configurationManagerConfigurationProvider = configurationManagerConfigurationProvider;
        }

        public void Save<T>(T value)
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
                                {
                                    if (fileConfigurationProvider != null)
                                    {
                                        fileConfigurationProvider.SaveSettings(property, value);
                                    }
                                    break;
                                }

                            case "Configuration_Manager_Configuration_Provider":
                                {
                                    if (configurationManagerConfigurationProvider != null)
                                    {
                                        configurationManagerConfigurationProvider.SaveSettings(property, value);
                                    }
                                    break;
                                }

                        }
                    }
                }
            }


        }

        public void Load()
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
                                {
                                    if (fileConfigurationProvider != null)
                                    {
                                        fileConfigurationProvider.LoadSettings(property);
                                    }
                                    break;
                                }

                            case "Configuration_Manager_Configuration_Provider":
                                {
                                    if (configurationManagerConfigurationProvider != null)
                                    {
                                        configurationManagerConfigurationProvider.LoadSettings(property);
                                    }
                                    break;
                                }
                        }
                    }
                }
            }

        }

    }
}
