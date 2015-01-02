using System;
using System.Collections.Generic;
using System.Text;
using SuperScript.JavaScript.ExtensionMethods;

namespace SuperScript.JavaScript.Declarables
{
    /// <summary>
    /// A class for declaring an enumerated type in JavaScript.
    /// </summary>
    public class EnumDeclaration : DeclarationBase
    {
        internal object _value = null;


        /// <summary>
        /// <para>The value of the JavaScript variable. This is not mandatory for each variable.</para>
        /// <para>This property is ignored for instances of <see cref="CallDeclaration"/>.</para>
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }


        /// <summary>
        /// Returns this enumerated type as a formatted JavaScript enumeration.
        /// </summary>
        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append("var ");
            output.Append(Name);
            output.Append(" = { ");

            var firstValue = true;
            foreach (var e in (IList<SerializedEnumerator>) Value)
            {
                if (firstValue)
                {
                    firstValue = false;
                }
                else
                {
                    output.Append(", ");
                }
                output.Append("\"");
                output.Append(e.Text);
                output.Append("\"");
                output.Append(": ");
                output.Append(e.ID);
            }
            output.Append(" };");

            CheckAppendComment(output);

            return output.ToString();
        }


        #region Constructors

        public EnumDeclaration()
        {}


        public EnumDeclaration(EnumeratedTypeOptions options)
        {
            Comment = options._comment;
            Name = !String.IsNullOrEmpty(options._name)
                ? options._name
                : options._type.Name;
            EmitterKey = options._emitterKey;
            Value = options._type.ToList(EnumAttribute.EnumText);
        }

        #endregion
    }
}