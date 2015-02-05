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
        internal Type _type = null;
        private EnumAttribute _enumAttribute = EnumAttribute.None;


        public EnumAttribute EnumAttribute
        {
            get { return _enumAttribute; }
            set { _enumAttribute = value; }
        }


        /// <summary>
        /// The <see cref="System.Type"/> of the enumeration to converted to JavaScript.
        /// </summary>
        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }


        /// <summary>
        /// Returns this enumeration as a formatted JavaScript enumeration.
        /// </summary>
        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append("var ");
            output.Append(Name);
            output.Append(" = { ");

            var firstValue = true;
            var srlsdEnum = Type.ToList(EnumAttribute);
            foreach (var e in srlsdEnum)
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
            EnumAttribute = options._enumAttribute;
            Name = !String.IsNullOrEmpty(options._name)
                       ? options._name
                       : options._type.Name;
            EmitterKey = options._emitterKey;
            Type = options._type;
        }

        #endregion
    }
}