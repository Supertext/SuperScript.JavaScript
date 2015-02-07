using System;
using System.ComponentModel;
using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class EnumElement : DeclarationElement
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

        [ConfigurationProperty("name", IsRequired = false)]
        public string Name
        {
            get { return (String) this["name"]; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        [TypeConverter(typeof (TypeNameConverter))]
        public Type Type
        {
            get { return (Type) this["type"]; }
        }

        [ConfigurationProperty("enumAttribute", IsRequired = false, DefaultValue = EnumAttribute.None)]
        public EnumAttribute EnumAttribute
        {
            get
            {
                //var specified = (String) this["enumAttribute"];

                if (Enum.IsDefined(typeof (EnumAttribute), this["enumAttribute"]))
                {
                    return (EnumAttribute) this["enumAttribute"];
                }

                return EnumAttribute.None;
            }
        }
    }
}