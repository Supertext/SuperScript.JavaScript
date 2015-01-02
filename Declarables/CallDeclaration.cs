using System;
using System.Text;

namespace SuperScript.JavaScript.Declarables
{
    /// <summary>
    /// A class for declaring a function call in JavaScript.
    /// </summary>
    public class CallDeclaration : DeclarationBase
    {
        /// <summary>
        /// Represents the collection of parameters for this function call.
        /// </summary>
        public object[] Parameters { get; set; }


        /// <summary>
        /// Returns this instance as a formatted JavaScript declaration.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            // remove the parentheses from the function name
            // - we'll add these back in when we wrap the parameters
            var functionName = Name;
            if (functionName.EndsWith(")"))
            {
                var idx = functionName.LastIndexOf("(", StringComparison.Ordinal);
                if (idx > -1)
                {
                    functionName = Name.Substring(0, idx);
                }
            }

            output.Append(functionName);
            output.Append("(");
            output.Append(FormatParams());
            output.Append(")");
            output.Append(";");

            CheckAppendComment(output);

            return output.ToString();
        }


        private string FormatParams()
        {
            if (Parameters == null)
            {
                return string.Empty;
            }

            var output = new StringBuilder();

            var i = 0;
            var iMax = Parameters.Length;

            while (i < iMax)
            {
                output.Append(GetFormattedValue(Parameters[i]));

                i++;

                if (i < iMax)
                {
                    output.Append(", ");
                }
            }

            return output.ToString();
        }


        #region Constructors

        public CallDeclaration()
        {}


        public CallDeclaration(CallOptions options)
        {
            Comment = options._comment;
            EmitterKey = options._emitterKey;
            Name = options._functionName;
            Parameters = options._parameters;
        }

        #endregion


        internal bool ParamIsStringLiteral(object param)
        {
            var value = param as string;
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            // Criteria:
            // if the string value
            //      DOES NOT contain both "(" and ")"
            // then it is a string literal
            // - an assumption is made that those strings which do match any of the above are functional assignments.
            return !(value.Contains("(") && value.Contains(")"));
        }
    }
}