using System.Text;

namespace SuperScript.JavaScript.Declarables
{
    /// <summary>
    /// A class for declaring a comment in JavaScript.
    /// </summary>
    public class CommentDeclaration : DeclarationBase
    {
        /// <summary>
        /// Returns this instance as a formatted JavaScript declaration.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            CheckAppendComment(output, false);

            return output.ToString();
        }


        #region Constructors

        public CommentDeclaration()
        {}


        public CommentDeclaration(CommentOptions options)
        {
            Comment = options._comment;
            EmitterKey = options._emitterKey;
        }

        #endregion
    }
}