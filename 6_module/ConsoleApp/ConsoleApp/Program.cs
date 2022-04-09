using Provider;
using System.Reflection;

namespace ReflectionModule
{
    public class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = typeof(ProviderProgram).Assembly;

            Type? fileProvidertype = assembly.GetType("Provider.Plugins.FileConfigurationProvider");
            dynamic? file = Activator.CreateInstance(fileProvidertype);

            Type? configurationManagerConfigurationProvidertype = assembly.GetType("Provider.Plugins.ConfigurationManagerConfigurationProvider");
            dynamic? configurationManager = Activator.CreateInstance(configurationManagerConfigurationProvidertype);
            
            var configurationBase_1 = new ConfigurationComponentBase(file);
            var configurationBase_2 = new ConfigurationComponentBase(configurationManager);
            configurationBase_1.Save(new TimeSpan(20, 20, 20));
            configurationBase_2.Save("string value");
            configurationBase_1.Load();
            configurationBase_2.Load();
        }
    }
}






//   Type fileProvidertype = assembly.GetType("Provider.Plugins.FileConfigurationProvider");
// Type configurationManagerConfigurationProvidertype = assembly.GetType("Provider.Plugins.ConfigurationManagerConfigurationProvider");

// Tasks 1(week 1): 

// Create a console application which demonstrates the use of a custom attribute.
// Attribute should allow to read / write a configuration value via at least two configuration providers:
// FileConfigurationProvider and ConfigurationManagerConfigurationProvider,
// which would allow to get / store a setting value in a custom file and app.config(appsettings.json) respectively.
// It could be a single attribute ConfigurationItemAttribute with parameters: settingName, providerType(File, Configuration Manager);
// or multiple attributes: FileConfigurationItemAttribute, ConfigurationManagerConfigurationItemAttribute.
// Any other settings providers are also acceptable, even instead of proposed ones(File / Configuration Manager).

// Requirements: 

// + Created attribute(s) should be applicable only to properties

// Attributes usage should be implemented in a base class (ConfigurationComponentBase) of a class where the attribute was applied.

// Attribute should allow to read/write setting values of basic types: int, float, string, TimeSpan

// Reading / Writing of the settings could be initiated either by a method used in Set / Get parts of the property,
// or, as a simpler approach, by the methods of the base class (ConfigurationComponentBase): SaveSettings, LoadSettings, which will be invoked externally


/*
 
         Создайте консольное приложение, которое демонстрирует использование пользовательского атрибута. 
         Атрибут должен позволять считывать/записывать значение конфигурации по крайней мере через двух поставщиков конфигурации: 
         FileConfigurationProvider и ConfigurationManagerConfigurationProvider, 
         что позволило бы получать/сохранять значение настройки в пользовательском файле и app.config (appsettings.json) соответственно. 
         Это может быть один атрибут Элемента конфигурации атрибута с параметрами: имя настройки, тип поставщика (файл, Менеджер конфигурации); 
         или несколько атрибутов: FileConfigurationItemAttribute, ConfigurationManagerConfigurationItemAttribute. 
         Любые другие поставщики настроек также приемлемы, даже вместо предложенных (File / Configuration Manager).


       + Созданные атрибуты должны быть применимы только к свойствам

        Использование атрибутов должно быть реализовано в базовом классе (ConfigurationComponentBase) класса, к которому был применен атрибут.

        Атрибут должен позволять считывать/записывать значения настроек основных типов: int, float, string, TimeSpan

        Чтение / запись настроек может быть инициировано либо методом, используемым в Set / Get частях свойства, 
        либо, в качестве более простого подхода, методами базового класса (ConfigurationComponentBase): 
        saveSettings, loadSettings, которые будут вызываться извне
 
 */