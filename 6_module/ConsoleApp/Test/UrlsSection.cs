//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Test
{
    public class UrlsSection : ConfigurationSection
    {

        [ConfigurationProperty(Name:"CustomName", DefaultValue: "Contoso", IsRequired: true, IsKey: true)]
     //   public string Name { get; set; }
        public string Name
        {
            get
            {
                return (string)this["Name"];
            }
            set
            {
                this["Name"] = value;
            }
        }

        [ConfigurationProperty("http://google.com", defaultValue:"http://www.contoso.com", isRequired:true)]
        public string Url { get; set; }
        /*     public string Url
             {
                 get
                 {
                     return (string)this["url"];
                 }
                 set
                 {
                     this["url"] = value;
                 }
             }*/

        [ConfigurationProperty("8080", defaultValue:"0", isRequired:false)]
        public string Port { get; set; }
       /* public int Port
        {
            get
            {
               // return (int)this["port"];
                return 8080;
            }
            set
            {
                this["port"] = value.ToString();
            }
        }*/
    }
}

