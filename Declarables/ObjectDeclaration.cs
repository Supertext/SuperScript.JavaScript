using System;
using Newtonsoft.Json;

namespace SuperScript.JavaScript.Declarables
{
    /// <summary>
    /// A class for declaring an object in JavaScript.
    /// </summary>
    public class ObjectDeclaration : DeclarationBase
    {
        internal object _value = null;


        /// <summary>
        /// <para>Indicates whether this declaration is new or is setting the value of an existing variable.</para>
        /// <para>This value determines whether the emitted value is preceded by the <strong>var</strong> keyword.</para>
        /// </summary>
        public bool AssignExisting { get; set; }


        /// <summary>
        /// Returns the specified <see cref="Value"/> property as an object in JavaScript Object Notation (JSON).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var jsonObj = JsonConvert.SerializeObject(_value);

            // if no name has been explicitly specified then use the name of the class
            // - and force the first letter to lower-case
            // * This code is also in the ObjectOptions.Value method, but has been duplicated here in case 
            // * someone has forcefully removed the name after setting the value.
            if (String.IsNullOrWhiteSpace(Name))
            {
                var n = _value.GetType().Name;
                Name = Char.ToLowerInvariant(n[0]) + n.Substring(1);
            }

            return (AssignExisting
                        ? String.Empty
                        : "var ")
                   + Name + " = " + jsonObj + ";"
                   + (!String.IsNullOrWhiteSpace(Comment)
                          ? "\t/* " + Comment + " */"
                          : String.Empty);
        }


        /// <summary>
        /// The value of the JavaScript declaration's source (i.e., the right-hand side).
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }


        #region Constructors

        public ObjectDeclaration()
        {
        }


        public ObjectDeclaration(ObjectOptions options)
        {
            AssignExisting = options._assignExisting;
            Comment = options._comment;
            Value = options._value;
            EmitterKey = options._emitterKey;
            Name = options._name;
        }

        #endregion
    }
}