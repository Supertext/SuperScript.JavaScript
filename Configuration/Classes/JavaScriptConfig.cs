using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    /// <summary>
    /// This class represents the default configuration from the web.config file.
    /// </summary>
    public class JavaScriptConfig : ConfigurationSection
    {
        private static readonly ConfigurationProperty DeclarationsElement = new ConfigurationProperty("declarations", typeof (DeclarationsCollection), null, ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty ContainersElement = new ConfigurationProperty("containers", typeof (ContainersElement), null, ConfigurationPropertyOptions.None);


        [ConfigurationProperty("containers", IsRequired = false)]
        public ContainersElement Containers
        {
            get { return (ContainersElement) this[ContainersElement]; }
        }


        [ConfigurationProperty("declarations", IsRequired = false)]
        public DeclarationsCollection Declarations
        {
            get { return (DeclarationsCollection) this[DeclarationsElement]; }
        }
    }
}