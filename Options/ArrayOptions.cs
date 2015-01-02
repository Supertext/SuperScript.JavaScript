using SuperScript.JavaScript.Declarables;

namespace SuperScript.JavaScript
{
    /// <summary>
    /// Specifies the options available for a SuperScript array declaration.
    /// </summary>
    public class ArrayOptions : OptionsBase<ArrayOptions>
    {
        internal bool _assignExisting;
        internal string _name;
        internal object[] _elements = null;


        /// <summary>
        /// Indicates whether the <see cref="Elements"/> properties should be assigned to an existing declaration.
        /// </summary>
        public ArrayOptions AssignExisting(bool value)
        {
            _assignExisting = value;
            return this;
        }


        /// <summary>
        /// Adds a comment (in JavaScript) for the declaration.
        /// </summary>
        public override ArrayOptions Comment(string value)
        {
            _comment = value;
            return this;
        }


        /// <summary>
        /// Specifies the elements of the array.
        /// </summary>
        public ArrayOptions Elements(object[] value)
        {
            _elements = value;
            return this;
        }


        /// <summary>
        /// Specifies which instance of <see cref="SuperScript.Emitters.IEmitter"/> should be used to emit this instance of <see cref="ArrayDeclaration"/>.
        /// </summary>
        public override ArrayOptions EmitterKey(string value)
        {
            _emitterKey = value;
            return this;
        }


        /// <summary>
        /// Permits this instance of <see cref="ArrayDeclaration"/> to be inserted into the collection at the specified index.
        /// </summary>
        public override ArrayOptions InsertAt(int? value)
        {
            _insertAt = value;
            return this;
        }


        /// <summary>
        /// The name (in JavaScript) of this variable.
        /// </summary>
        public ArrayOptions Name(string value)
        {
            _name = value;
            return this;
        }
    }
}