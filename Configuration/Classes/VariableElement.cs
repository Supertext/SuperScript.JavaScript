using System;
using System.ComponentModel;
using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class VariableElement : DeclarationElement
    {
        [ConfigurationProperty("comment", IsRequired = false)]
        public string Comment
        {
            get { return (String) this["comment"]; }
        }

        [ConfigurationProperty("emitterKey", IsRequired = false)]
        public string EmitterKey
        {
            get { return (string) this["emitterKey"]; }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (String) this["name"]; }
        }

        [ConfigurationProperty("type", IsRequired = false, DefaultValue = "System.String, mscorlib")]
        [TypeConverter(typeof (TypeNameConverter))]
        public Type Type
        {
            get { return (Type) this["type"]; }
        }

        [ConfigurationProperty("value", IsRequired = false)]
        public string Value
        {
            get { return (String) this["value"]; }
        }
    }
}