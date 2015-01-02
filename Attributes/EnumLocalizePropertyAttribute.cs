using System;

namespace SuperScript.JavaScript.Attributes
{
    /// <summary>
    /// When this enumerated type is serialized into a JavaScript object literal, the specified text will be used to obtain the localized version.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class LocalizePropertyAttribute : Attribute
    {
        private string localizeProperty;

        /// <summary>
        /// Gets the property used for localization for this property
        /// </summary>
        /// <value>The text stored in the attribute.</value>
        public string LocalizeProperty
        {
            get { return localizeProperty; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizePropertyAttribute"/> class.
        /// </summary>
        /// <param name="localizeProperty">The text to store in this attribute.
        /// </param>
        public LocalizePropertyAttribute(string localizeProperty)
        {
            this.localizeProperty = localizeProperty;
        }
    }
}