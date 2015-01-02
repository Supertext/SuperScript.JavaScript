namespace SuperScript.JavaScript.Declarables
{
    public class CollectedScript : SuperScript.Declarables.DeclarationBase
    {
        internal object _value = null;


        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }


        /// <summary>
        /// Returns the entire relocated contents of the ScriptContainer element.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }


        /// <summary>
        /// Wraps the <see cref="Value"/> property in a JavaScript-formatted comment indicating the original location.
        /// </summary>
        /// <param name="virtualPath">The original location which will be emitted inside a JavaScript-formatted comment.</param>
        public void WrapInLocationComment(string virtualPath)
        {
            const string scriptNewLine = "\n";

            var commentOpen = "/* Located dynamically from " + virtualPath + "*/";
            var commentClose = "/* End of script from " + virtualPath + "*/";

            _value = string.Format("{0}{1}{0}{2}{0}{3}{0}",
                                   scriptNewLine,
                                   commentOpen,
                                   _value,
                                   commentClose);
        }
    }
}