//using Microsoft.Extensions.Configuration;


//using ConsoleApp.Provider;
using Provider;
using System.Configuration;
using System.Reflection;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Assembly assembly = typeof(Program).Assembly;
           // Assembly assembly = typeof(ProviderProgram).Assembly;


            Type? fileProvidertype = assembly.GetType("Provider.Plugins.FileConfigurationProvider");
            dynamic file = Activator.CreateInstance(fileProvidertype);

            Type? configurationManagerConfigurationProvidertype = assembly.GetType("ConsoleApp.Provider.ConfigurationManagerConfigurationProvider");
            dynamic configurationManager = Activator.CreateInstance(configurationManagerConfigurationProvidertype);

            var configurationBase = new ConfigurationComponentBase(file, configurationManager);
            configurationBase.SaveSettings(new TimeSpan(22, 22, 22));
            configurationBase.LoadSettings();
        }

    }
}

