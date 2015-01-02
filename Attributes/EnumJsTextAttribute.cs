using System;

namespace SuperScript.JavaScript.Attributes
{
    /// <summary>
    /// When this enumerated type is serialized into a JavaScript enumeration, the specified text will be written in place of the enumeration text.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class JsEnumTextAttribute : Attribute
    {
        private string jsEnumText;

        /// <summary>
        /// Gets the text stored in this attribute.
        /// </summary>
        /// <value>The text stored in the attribute.</value>
        public string JsEnumText
        {
            get { return jsEnumText; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsEnumTextAttribute"/> class.
        /// </summary>
        /// <param name="jsEnumText">The text to store in this attribute.
        /// </param>
        public JsEnumTextAttribute(string jsEnumText)
        {
            this.jsEnumText = jsEnumText;
        }
    }
}