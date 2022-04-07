//using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using Test;

public class UsingConfigurationPropertyAttribute
{

    // Create a custom section and save it in the 
    // application configuration file.
    static void CreateCustomSection()
    {
        try
        {

            // Create a custom configuration section.
            UrlsSection customSection = new UrlsSection();
            customSection.Url = "http://youtube.com";
            customSection.Name = "TestCustomName";
            customSection.Port = "3030";


            // Get the current configuration file.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Add the custom section to the application
            // configuration file.
            config.Sections.Remove("CustomSection");
            if (config.Sections["CustomSection"] == null)
            {
                config.Sections.Add("CustomSection", customSection);
            }

            // Save the application configuration file.
            customSection.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Modified);

            Console.WriteLine("Created custom section in the application configuration file: {0}",
                config.FilePath);
            Console.WriteLine();
        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("CreateCustomSection: {0}", err.ToString());
        }
    }

    static void ReadCustomSection()
    {
        try
        {
            // Get the application configuration file.
            Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Read and display the custom section.
            UrlsSection customSection = config.GetSection("CustomSection") as UrlsSection;
            Console.WriteLine("Reading custom section from the configuration file.");
            Console.WriteLine("Section name: {0}", customSection.Name);
            Console.WriteLine("Url: {0}", customSection.Url);
            Console.WriteLine("Port: {0}", customSection.Port);
            Console.WriteLine();
        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("ReadCustomSection(string): {0}", err.ToString());
        }
    }

    static void Main(string[] args)
    {

        // Get the name of the application.
        string appName =
            Environment.GetCommandLineArgs()[0];

        // Create a custom section and save it in the 
        // application configuration file.
        CreateCustomSection();

        // Read the custom section saved in the
        // application configuration file.
        ReadCustomSection();

        Console.WriteLine("Press enter to exit.");




        /* ReadAllSettings();
         ReadSetting("Setting1");
         ReadSetting("NotValid");
         AddUpdateAppSettings("NewSetting", "April 6, 2022");
         AddUpdateAppSettings("Setting1", "April 10, 2022");
         ReadAllSettings();*/

        Console.ReadLine();
    }


    public static void ReadAllSettings()
    {

        /* Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.Save(ConfigurationSaveMode.Minimal);*/

        try
        {
            var appSettings = ConfigurationManager.AppSettings;

            if (appSettings.Count == 0)
            {
                Console.WriteLine("AppSettings is empty.");
            }
            else
            {
                foreach (var key in appSettings.AllKeys)
                {
                    Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                }
            }
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error reading app settings");
        }
    }

    static void ReadSetting(string key)
    {
        try
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            Console.WriteLine(result);
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error reading app settings");
        }
    }

    static void AddUpdateAppSettings(string key, string value)
    {
        try
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error writing app settings");
        }
    }
}