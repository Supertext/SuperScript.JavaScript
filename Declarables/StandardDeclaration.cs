using System.Text;

namespace SuperScript.JavaScript.Declarables
{
    /// <summary>
    /// A general class for common declarations in JavaScript
    /// </summary>
    public class StandardDeclaration : DeclarationBase
    {
        internal object _value = null;


        /// <summary>
        /// <para>Indicates whether this declaration is new or is setting the value of an existing variable.</para>
        /// <para>This value determines whether the emitted variable is preceded by the <strong>var</strong> keyword.</para>
        /// </summary>
        public bool AssignExisting { get; set; }


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
        /// Returns this instance as a formatted JavaScript declaration.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append("var ");
            output.Append(Name);
            if (Value != null)
            {
                output.Append(" = ");
                output.Append(GetFormattedValue(_value));
            }
            output.Append(";");

            CheckAppendComment(output);

            return output.ToString();
        }


        #region Constructors

        public StandardDeclaration()
        {}


        public StandardDeclaration(VariableOptions options)
        {
            AssignExisting = options._assignExisting;
            Comment = options._comment;
            EmitterKey = options._emitterKey;
            Name = options._name;
            Value = options._value;
        }

        #endregion
    }
}