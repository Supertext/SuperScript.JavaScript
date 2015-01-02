using SuperScript.JavaScript.Declarables;

namespace SuperScript.JavaScript
{
    /// <summary>
    /// Specifies the options available for a SuperScript enumerated type declaration.
    /// </summary>
    public class EnumeratedTypeOptions : OptionsBase<EnumeratedTypeOptions>
    {
        internal string _name;
        internal System.Type _type;


        /// <summary>
        /// Adds a comment (in JavaScript) for the declaration.
        /// </summary>
        public override EnumeratedTypeOptions Comment(string value)
        {
            _comment = value;
            return this;
        }


        /// <summary>
        /// Specifies which instance of <see cref="SuperScript.Emitters.IEmitter"/> should be used to emit this instance of <see cref="EnumDeclaration"/>.
        /// </summary>
        public override EnumeratedTypeOptions EmitterKey(string value)
        {
            _emitterKey = value;
            return this;
        }


        /// <summary>
        /// Permits this instance of <see cref="EnumDeclaration"/> to be inserted into the collection at the specified index.
        /// </summary>
        public override EnumeratedTypeOptions InsertAt(int? value)
        {
            _insertAt = value;
            return this;
        }


        /// <summary>
        /// <para>The name that the enumerated type will have in JavaScript.</para>
        /// <para>If empty then the enumerated type's name will be used for the JavaScript declaration.</para>
        /// </summary>
        public EnumeratedTypeOptions Name(string name)
        {
            _name = name;
            return this;
        }


        /// <summary>
        /// The type of enum.
        /// </summary>
        public EnumeratedTypeOptions Type(System.Type type)
        {
            _type = type;
            return this;
        }
    }
}