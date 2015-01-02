using System.Collections.Generic;
using System.Configuration;
using SuperScript.JavaScript.Declarables;
using SuperScript.JavaScript.ExtensionMethods;

namespace SuperScript.JavaScript.Configuration
{
    /// <summary>
    /// This class represents any default configured declarations from the web.config.
    /// </summary>
    public class Settings
    {
        #region Public properties

        /// <summary>
        /// Gets or sets whether the emitted output should contain a comment indicating the original location.
        /// </summary>
        public EmitMode AddLocationComments { get; set; }


        /// <summary>
        /// A collection of implementations of <see cref="DeclarationBase"/> which have been configured in web.config.
        /// </summary>
        public IList<DeclarationBase> Declarations;

        #endregion


        #region Singleton stuff

        private static readonly Settings ThisInstance = new Settings();

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Settings()
        {}

        #endregion


        /// <summary>
        /// This constructor contains the logic for parsing the configured values out of the web.config.
        /// </summary>
        /// <exception cref="ConfigurationException">Thrown if the &lt;addLocationComments&gt; element could not be correctly parsed.</exception>
        private Settings()
        {
            var config = ConfigurationManager.GetSection("superScript.JavaScript") as JavaScriptConfig;
            if (config == null)
            {
                return;
            }

            AddLocationComments = config.Containers.AddLocationComments;

            // parse the default Declarations into a Collection<DeclarationBase> object

            var collection = new List<DeclarationBase>();
            var defaultEmitterKey = SuperScript.Configuration.Settings.Instance.DefaultEmitter.Key;

            // comment
            collection.Add(config.Declarations.Comment.ToDeclaration(defaultEmitterKey));

            // arrays
            collection.AddRange(config.Declarations.Arrays.ToDeclarations(defaultEmitterKey));

            // variables
            collection.AddRange(config.Declarations.Variables.ToDeclarations(defaultEmitterKey));

            // function calls
            collection.AddRange(config.Declarations.Calls.ToDeclarations(defaultEmitterKey));

            Declarations = collection;
        }


        /// <summary>
        /// Check the web.config file for configured default declarations.
        /// </summary>
        public static Settings Instance
        {
            get { return ThisInstance; }
        }
    }
}