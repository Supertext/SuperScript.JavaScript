using System;

namespace SuperScript.JavaScript.Attributes
{
    /// <summary>
    /// When this enumerated type is serialized into a JavaScript object literal, the specified text will be written in place of the enumeration text.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class OptionTextAttribute : Attribute
    {
        private string optionText;

        /// <summary>
        /// Gets the option text stored in this attribute.
        /// </summary>
        /// <value>The option text stored in the attribute.</value>
        public string OptionText
        {
            get { return optionText; }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="OptionTextAttribute"/> class.
        /// </summary>
        /// <param name="optionText">The option text to store in this attribute.
        /// </param>
        public OptionTextAttribute(string optionText)
        {
            this.optionText = optionText;
        }
    }
}