using SuperScript.JavaScript.Declarables;

namespace SuperScript.JavaScript
{
    /// <summary>
    /// Specifies the options available for a SuperScript comment declaration.
    /// </summary>
    public class CommentOptions : OptionsBase<CommentOptions>
    {
        /// <summary>
        /// Adds a comment (in JavaScript) for the declaration.
        /// </summary>
        public override CommentOptions Comment(string value)
        {
            _comment = value;
            return this;
        }


        /// <summary>
        /// Specifies which instance of <see cref="SuperScript.Emitters.IEmitter"/> should be used to emit this instance of <see cref="CommentDeclaration"/>.
        /// </summary>
        public override CommentOptions EmitterKey(string value)
        {
            _emitterKey = value;
            return this;
        }


        /// <summary>
        /// Permits this instance of <see cref="CommentDeclaration"/> to be inserted into the collection at the specified index.
        /// </summary>
        public override CommentOptions InsertAt(int? value)
        {
            _insertAt = value;
            return this;
        }
    }
}