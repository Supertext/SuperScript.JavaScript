using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class ContainersElement : ConfigurationElement
    {
        [ConfigurationProperty("addLocationComments", IsRequired = false, DefaultValue = EmitMode.DebugOnly)]
        public EmitMode AddLocationComments
        {
            get { return (EmitMode) this["addLocationComments"]; }
        }
    }
}