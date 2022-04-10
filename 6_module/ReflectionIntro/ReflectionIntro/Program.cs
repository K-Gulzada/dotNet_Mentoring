using Provider.Plugins;
using System.Configuration;
using System.Reflection;

namespace ReflectionIntro
{
    public class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = typeof(ProviderManager).Assembly;

            Type? fileProvidertype = assembly.GetType("Provider.Plugins.FileConfigurationProvider");
            dynamic? file = Activator.CreateInstance(fileProvidertype, BindingFlags.Instance | BindingFlags.Public,
                                                                    null, new object[] { "new new value" }, null);

            Type? configurationManagerConfigurationProvidertype = assembly.GetType("Provider.Plugins.ConfigurationManagerConfigurationProvider");
            dynamic? configurationManager = Activator.CreateInstance(configurationManagerConfigurationProvidertype,
                                                                    BindingFlags.Instance | BindingFlags.Public,
                                                                     null, new object[] { new TimeSpan(11, 09, 11) }, null);
            var configurationBase = new ConfigurationComponentBase(file, configurationManager);

            JsonConfigurationProvider jsonConfigurationProvider = new JsonConfigurationProvider("Json Provider value");
            var configurationBase_2 = new ConfigurationComponentBase(jsonConfigurationProvider);

            try
            {
                configurationBase.SaveAppSettings();
                configurationBase.ReadAppSettings();

                configurationBase_2.SaveAppSettings();
                configurationBase_2.ReadAppSettings();
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save configuration.\n {0}", e.Message);
            }
        }
    }
}

