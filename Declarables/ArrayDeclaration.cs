using System;
using System.Text;

namespace SuperScript.JavaScript.Declarables
{
    /// <summary>
    /// A class for declaring an array in JavaScript.
    /// </summary>
    public class ArrayDeclaration : DeclarationBase
    {
        /// <summary>
        /// <para>
        ///     Indicates whether this declaration is new or is setting the value of an existing variable.
        /// </para>
        /// <para>
        ///     This value determines whether the emitted variable is preceded by the <strong>var</strong> keyword.
        /// </para>
        /// </summary>
        public bool AssignExisting { get; set; }


        /// <summary>
        /// Specifies the elements of the array.
        /// </summary>
        public object[] Elements { get; set; }


        /// <summary>
        /// Returns this instance as a formatted JavaScript declaration.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            if (!AssignExisting)
            {
                output.Append("var ");
            }
            output.Append(Name);
            output.Append(" = [");
            foreach (var arrayElement in Elements)
            {
                output.Append(arrayElement.GetType() != Type
                                  ? GetFormattedValue(arrayElement, Type)
                                  : GetFormattedValue(arrayElement));
                output.Append(", ");
            }
            output.Remove(output.Length - 2, 2);
            output.Append("];");

            CheckAppendComment(output);

            return output.ToString();
        }


        public Type Type { get; set; }


        #region Constructors

        public ArrayDeclaration()
        {
        }


        public ArrayDeclaration(ArrayOptions options)
        {
            AssignExisting = options._assignExisting;
            Comment = options._comment;
            Elements = options._elements;
            EmitterKey = options._emitterKey;
            Name = options._name;
        }

        #endregion
    }
}