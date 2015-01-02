using System;
using System.Dynamic;
using System.Text;
using Newtonsoft.Json;

namespace SuperScript.JavaScript.Declarables
{
    /// <summary>
    /// This class holds each of the declarations: JavaScript variable with or without value, function call, or a JavaScript comment.
    /// </summary>
    public abstract class DeclarationBase : SuperScript.Declarables.DeclarationBase
    {
        /// <summary>
        /// This text may be emitted onto its own line or after a variable, depending upon the DeclarationType enumeration.
        /// </summary>
        public string Comment { get; set; }


        #region Internal Logic

        /// <summary>
        /// Appends the <strong>Comment</strong> property to the end of the StringBuilder, if the <strong>Comment</strong>
        /// is not null or white-space.
        /// </summary>
        /// <param name="output">
        /// The instance of <strong>System.Text.StringBuilder</strong> which is concatenating this Declaration's output string.
        /// </param>
        /// <param name="prependTab">
        /// Indicates whether the comment should be preceded by a tab indentation. Default value is <strong>true</strong>.
        /// </param>
        internal void CheckAppendComment(StringBuilder output, bool prependTab = true)
        {
            if (String.IsNullOrWhiteSpace(Comment)) return;

            if (prependTab)
            {
                output.Append("\t");
            }
            output.Append("/* ");
            output.Append(Comment);
            output.Append(" */");
        }


        /// <summary>
        /// <para>
        /// Gets the <strong>Value</strong> in the necessary format for the output declaration.
        /// </para>
        /// <para>
        /// When declaring the output of a declaration it can be useful to specify an existing declaration. This method
        /// will then assign the name of the existing declaration as the value of this new declaration.
        /// </para>
        /// </summary> 
        /// <returns>
        /// If the <see cref="value"/> is an instance of <see cref="DeclarationBase"/> then <see cref="DeclarationBase.Name"/>
        /// will be returned; otherwise the <see cref="value"/> will be returned in a suitable format (i.e. wrapped in 
        /// quotation marks when a string, lower-case when boolean).
        /// </returns>
        /// <example>
        /// DeclarationBase exampleVar = Declarations.AddVariable(opt => opt.Name("exampleVar").Value("hello world"));
        /// DeclarationBase anotherVar = Declarations.AddVariable(opt => opt.Name("anotherVar").Value(exampleVar));
        /// 
        /// will be rendered as
        /// 
        /// var exampleVar = "hello world";
        /// var anotherVar = exampleVar;
        /// </example>
        internal string GetFormattedValue(object value)
        {
            var decbase = value as DeclarationBase;
            if (decbase != null)
            {
                return decbase.Name;
            }

            //if (value is Boolean)
            //{
            //    return value.ToString().ToLower();
            //}

            if (value is String && IsFuncCall(value))
            {
                return value.ToString();
            }

            return value == JavaScriptValues.Null
                       ? "null"
                       : JsonConvert.SerializeObject(value);
        }


        /// <summary>
        ///Determines if the specified value is a <see cref="string"/> which represents a function call.
        /// </summary>
        /// <returns>
        /// <c>True</c> if the value matches the business rules for a functional assignment; <c>false</c> otherwise.
        /// </returns>
        private bool IsFuncCall(object value)
        {
            var val = value as string;
            if (string.IsNullOrEmpty(val))
            {
                return false;
            }

            // Criteria:
            // if the index of "(" != -1
            // if the index of ")" != -1
            // the index of ")" is greater than "("
            var idxOpenPar = val.IndexOf('(');
            var idxClosePar = val.IndexOf(')');
            return idxOpenPar != -1 && idxClosePar != -1 && idxClosePar > idxOpenPar;
        }

        #endregion
    }
}