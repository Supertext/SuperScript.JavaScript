using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SuperScript.Modifiers;
using SuperScript.Modifiers.Post;
using SuperScript.Modifiers.Writers;

namespace SuperScript.JavaScript.Modifiers.Writers
{
    /// <summary>
    /// <para>Writes the formatted output of the <see cref="PostModifierArgs.Emitted"/> into an HTML &lt;script&gt; tag.</para>
    /// <para>An instance of this class will be processed after any implementations of the abstract class <see cref="CollectionPostModifier"/>.</para>
    /// </summary>
    public class ScriptTagWriter : HtmlWriter
    {
		private readonly KeyValuePair<string, string>[] _defaultAttributes = { new KeyValuePair<string, string>("type", "text/javascript") };
	    private const string DefaultTagName = "script";

	    #region Properties

		/// <summary>
	    /// <para>Gets or sets a collection of key-value pairs which form the tag's attribute collection.</para>
	    /// <para>Default value is a single key-value pair, type="text/javascript".</para>
	    /// </summary>
	    public IEnumerable<KeyValuePair<string, string>> TagAttributes { get; set; }


		/// <summary>
		/// <para>Gets or sets the name of the enclosing HTML tag.</para>
		/// <para>Default value is "script".</para>
		/// </summary>
	    public string TagName { get; set; }

		#endregion


		/// <summary>
        /// Executes this instance of <see cref="HtmlWriter"/> upon the specified argument object.
        /// </summary>
        /// <param name="args">An instance of <see cref="PostModifierArgs"/> which contains an instance of <see cref="TagArguments"/> in the <see cref="PostModifierArgs.CustomObject"/> property.</param>
        /// <returns>
        /// An HTML tag, whose name and attributes are specified in <see cref="PostModifierArgs.CustomObject"/>, and containing the contents as specified in <see cref="PostModifierArgs.Emitted"/>.
        /// </returns>
        public override IHtmlString Process(PostModifierArgs args)
        {
	        var output = new StringBuilder();

            // otherwise add the tag
            output.Append("<");
            output.Append(TagName);

            if (TagAttributes != null && TagAttributes.Any())
            {
                foreach (var tagAttribute in TagAttributes.Where(ta => !string.IsNullOrWhiteSpace(ta.Key)))
                {
                    output.Append(" ");
                    output.Append(tagAttribute.Key);

                    if (string.IsNullOrWhiteSpace(tagAttribute.Value))
                    {
                        continue;
                    }

                    output.Append("=\"");
                    output.Append(tagAttribute.Value);
                    output.Append("\"");
                }
            }

            output.AppendLine(">");

            output.Append(args.Emitted);

            output.Append("</");
            output.Append(TagName);
            output.AppendLine(">");

            return new HtmlString(output.ToString());
		}


		#region Constructors

	    /// <summary>
	    /// Default constructor for <see cref="ScriptTagWriter"/> which initialises the values of properties.
	    /// </summary>
	    public ScriptTagWriter()
	    {
			TagAttributes = _defaultAttributes;
		    TagName = DefaultTagName;
	    }

	    #endregion
	}
}