//using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Reflection;

namespace Provider.Plugins
{
    public class JsonConfigurationProvider : FileConfigurationProvider
    {
        public JsonConfigurationProvider(object value) : base(value) { }

        public override void SaveSettings(PropertyInfo propertyInfo, object value)
        {
            JObject jsonObj = JObject.Parse(File.ReadAllText(GetFilePath()));
            if (jsonObj[propertyInfo.Name] == null)
            {
                jsonObj.Add(propertyInfo.Name, value.ToString());
            }
            else
            {
                jsonObj[propertyInfo.Name] = value.ToString();

            }

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(GetFilePath(), output);
        }

        public override void LoadSettings(PropertyInfo propertyInfo)
        {
            JObject jsonObj = JObject.Parse(File.ReadAllText(GetFilePath()));

            if (jsonObj[propertyInfo.Name] != null)
            {
                Console.WriteLine("Key: {0} Value: {1}", propertyInfo.Name, jsonObj[propertyInfo.Name]);
            }
            else
            {
                Console.WriteLine("There is no data with this providerName");
            }
        }

        private string GetFilePath()
        {
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string filePath = projectPath + @"appsettings.json";

            return filePath;
        }
    }
}
