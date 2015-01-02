using System;
using SuperScript.JavaScript.Declarables;

namespace SuperScript.JavaScript
{
    /// <summary>
    /// Specifies the options available for an object declaration.
    /// </summary>
    public class ObjectOptions : OptionsBase<ObjectOptions>
    {
        internal bool _assignExisting;
        internal string _name;
        internal object _value;


        /// <summary>
        /// Indicates whether the object should be assigned to an existing declaration.
        /// </summary>
        public ObjectOptions AssignExisting(bool value)
        {
            _assignExisting = value;
            return this;
        }


        /// <summary>
        /// Adds a comment (in JavaScript) for the declaration.
        /// </summary>
        public override ObjectOptions Comment(string value)
        {
            _comment = value;
            return this;
        }


        /// <summary>
        /// Specifies which instance of <see cref="SuperScript.Emitters.IEmitter"/> should be used to emit this instance of <see cref="ObjectDeclaration"/>.
        /// </summary>
        public override ObjectOptions EmitterKey(string value)
        {
            _emitterKey = value;
            return this;
        }


        /// <summary>
        /// Permits this instance of <see cref="ObjectDeclaration"/> to be inserted into the collection at the specified index.
        /// </summary>
        public override ObjectOptions InsertAt(int? value)
        {
            _insertAt = value;
            return this;
        }


        /// <summary>
        /// The name (in JavaScript) of this variable.
        /// </summary>
        public ObjectOptions Name(string value)
        {
            _name = value;
            return this;
        }


        /// <summary>
        /// The value of the JavaScript declaration's source (i.e., the right-hand side).
        /// </summary>
        public ObjectOptions Value(object value)
        {
            _value = value;

            // if no name has been explicitly specified then use the name of the class
            // - and force the first letter to lower-case
            if (String.IsNullOrWhiteSpace(_name))
            {
                var n = _value.GetType().Name;
                _name = Char.ToLowerInvariant(n[0]) + n.Substring(1);
            }

            return this;
        }
    }
}