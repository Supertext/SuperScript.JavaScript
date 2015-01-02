using SuperScript.JavaScript.Declarables;

namespace SuperScript.JavaScript
{
    /// <summary>
    /// Specifies the options available for a SuperScript variable declaration.
    /// </summary>
    public class VariableOptions : OptionsBase<VariableOptions>
    {
        internal bool _assignExisting = false;
        internal string _name = null;
        internal object _value = null;


        /// <summary>
        /// Indicates whether the <see cref="Value"/> property should be assigned to an existing declaration.
        /// </summary>
        public VariableOptions AssignExisting(bool value)
        {
            _assignExisting = value;
            return this;
        }


        /// <summary>
        /// Adds a comment (in JavaScript) for the declaration.
        /// </summary>
        public override VariableOptions Comment(string value)
        {
            _comment = value;
            return this;
        }


        /// <summary>
        /// Specifies which instance of <see cref="SuperScript.Emitters.IEmitter"/> should be used to emit this instance of <see cref="StandardDeclaration"/>.
        /// </summary>
        public override VariableOptions EmitterKey(string value)
        {
            _emitterKey = value;
            return this;
        }


        /// <summary>
        /// Permits this instance of <see cref="StandardDeclaration"/> to be inserted into the collection at the specified index.
        /// </summary>
        public override VariableOptions InsertAt(int? value)
        {
            _insertAt = value;
            return this;
        }


        /// <summary>
        /// The name (in JavaScript) of this variable.
        /// </summary>
        public VariableOptions Name(string value)
        {
            _name = value;
            return this;
        }


        /// <summary>
        /// The value (in JavaScript) assigned to this variable.
        /// </summary>
        public VariableOptions Value(object value)
        {
            _value = value;
            return this;
        }
    }
}