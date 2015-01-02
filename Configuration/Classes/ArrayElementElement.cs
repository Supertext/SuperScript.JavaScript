using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class ArrayElementElement : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string) this["value"]; }
        }
    }
}