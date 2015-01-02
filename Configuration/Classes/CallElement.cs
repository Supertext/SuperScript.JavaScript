using System;
using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class CallElement : DeclarationElement
    {
        private static readonly ConfigurationProperty ParametersElement = new ConfigurationProperty("parameters", typeof (ParametersCollection), null, ConfigurationPropertyOptions.None);

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

        [ConfigurationProperty("functionName", IsRequired = true)]
        public string FunctionName
        {
            get { return (string) this["functionName"]; }
        }

        [ConfigurationProperty("parameters", IsRequired = false)]
        public ParametersCollection Parameters
        {
            get { return (ParametersCollection) this[ParametersElement]; }
        }
    }
}