namespace SuperScript.JavaScript
{
    /// <summary>
    /// Base class for SuperScript declaration options.
    /// </summary>
    public abstract class OptionsBase<T> : SuperScript.OptionsBase<T>
    {
        internal string _comment;
        internal string _emitterKey;
        internal int? _insertAt;


        /// <summary>
        /// Adds a comment (in JavaScript) for the declaration.
        /// </summary>
        public abstract T Comment(string value);


        protected OptionsBase()
        {
            _emitterKey = base._emitterKey;
            _insertAt = base._insertAt;
        }
    }
}