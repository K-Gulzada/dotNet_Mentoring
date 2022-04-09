using Provider.Plugins;


namespace ReflectionIntro
{
    // ConfigurationManagerConfigurationProvider
    public class ConfigurationComponentBase
    {
        [ConfigurationItem(SettingName = "Setting_1", ProviderType = "File_Configuration_Provider")]
        public FileConfigurationProvider fileConfigurationProvider { get; set; }

        [ConfigurationItem(SettingName = "Setting_2", ProviderType = "Configuration_Manager_Configuration_Provider")]
        public ConfigurationManagerConfigurationProvider configurationManagerConfigurationProvider { get; set; }

        [ConfigurationItem(SettingName = "Setting_3", ProviderType = "Json_Configuration_Provider")]
        public JsonConfigurationProvider jsonConfigurationProvider { get; set; }

        public ConfigurationComponentBase(FileConfigurationProvider fileConfigurationProvider,
                                          ConfigurationManagerConfigurationProvider configurationManagerConfigurationProvider)
        {
            if (fileConfigurationProvider == null || configurationManagerConfigurationProvider == null)
            {
                throw new ArgumentNullException("property cannot be null");
            }
            else
            {
                this.fileConfigurationProvider = fileConfigurationProvider;
                this.configurationManagerConfigurationProvider = configurationManagerConfigurationProvider;
            }
        }

        public ConfigurationComponentBase(JsonConfigurationProvider jsonConfigurationProvider)
        {
            this.jsonConfigurationProvider = jsonConfigurationProvider;
        }

        public void SaveAppSettings()
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
                                        if (fileConfigurationProvider.Value != null)
                                        {
                                            fileConfigurationProvider.SaveSettings(property, fileConfigurationProvider.Value);
                                        }
                                    }
                                    break;
                                }
                            case "Configuration_Manager_Configuration_Provider":
                                {
                                    if (configurationManagerConfigurationProvider != null)
                                    {
                                        if (configurationManagerConfigurationProvider.Value != null)
                                        {
                                            configurationManagerConfigurationProvider.SaveSettings(property, configurationManagerConfigurationProvider.Value);
                                        }
                                    }
                                    break;
                                }
                            case "Json_Configuration_Provider":
                                {
                                    if (jsonConfigurationProvider != null)
                                    {
                                        if (jsonConfigurationProvider.Value != null)
                                        {
                                            jsonConfigurationProvider.SaveSettings(property, jsonConfigurationProvider.Value);
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }

        public void ReadAppSettings()
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
                                if (fileConfigurationProvider != null)
                                {
                                    fileConfigurationProvider.LoadSettings(property);
                                }
                                break;
                            case "Configuration_Manager_Configuration_Provider":
                                {
                                    if (configurationManagerConfigurationProvider != null)
                                    {
                                        configurationManagerConfigurationProvider.LoadSettings(property);
                                    }
                                    break;
                                }
                            case "Json_Configuration_Provider":
                                {
                                    if (jsonConfigurationProvider != null)
                                    {
                                        jsonConfigurationProvider.LoadSettings(property);
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
