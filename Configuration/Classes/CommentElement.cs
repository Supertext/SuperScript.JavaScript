using System;
using System.Configuration;
using SuperScript.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class CommentElement : DeclarationElement
    {
        [ConfigurationProperty("emitterKey", IsRequired = false)]
        public string EmitterKey
        {
            get { return (string) this["emitterKey"]; }
        }

        [ConfigurationProperty("text", IsRequired = true)]
        public string Text
        {
            get { return (String) this["text"]; }
        }
    }
}