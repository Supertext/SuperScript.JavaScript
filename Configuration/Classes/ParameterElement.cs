using System;
using System.ComponentModel;
using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class ParameterElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = false, DefaultValue = "System.String, mscorlib")]
        [TypeConverter(typeof (TypeNameConverter))]
        public Type Type
        {
            get { return (Type) this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (String) this["value"]; }
            set { this["value"] = value; }
        }
    }
}