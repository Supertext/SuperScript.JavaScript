using SuperScript.JavaScript.Declarables;

namespace SuperScript.JavaScript
{
    /// <summary>
    /// Specifies the options available for a SuperScript function call declaration.
    /// </summary>
    public class CallOptions : OptionsBase<CallOptions>
    {
        internal string _functionName;
        internal object[] _parameters;


        /// <summary>
        /// Adds a comment (in JavaScript) for the declaration.
        /// </summary>
        public override CallOptions Comment(string value)
        {
            _comment = value;
            return this;
        }


        /// <summary>
        /// Specifies which instance of <see cref="SuperScript.Emitters.IEmitter"/> should be used to emit this instance of <see cref="CallDeclaration"/>.
        /// </summary>
        public override CallOptions EmitterKey(string value)
        {
            _emitterKey = value;
            return this;
        }


        /// <summary>
        /// The name (in JavaScript) of the function to be called.
        /// </summary>
        public CallOptions FunctionName(string value)
        {
            _functionName = value;
            return this;
        }


        /// <summary>
        /// Permits this instance of <see cref="CallDeclaration"/> to be inserted into the collection at the specified index.
        /// </summary>
        public override CallOptions InsertAt(int? value)
        {
            _insertAt = value;
            return this;
        }


        /// <summary>
        /// The parameters to be passed to the function call.
        /// </summary>
        public CallOptions Parameters(params object[] parameters)
        {
            _parameters = parameters;
            return this;
        }
    }
}