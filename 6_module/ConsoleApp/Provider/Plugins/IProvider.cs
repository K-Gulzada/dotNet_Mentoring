using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Plugins
{
    internal interface IProvider
    {
        void SaveSettings(PropertyInfo propertyInfo, object? value);
        void LoadSettings(PropertyInfo propertyInfo);
       
    }
}
