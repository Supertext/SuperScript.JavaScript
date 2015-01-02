using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Ajax.Utilities;
using SuperScript.ExtensionMethods;
using SuperScript.Modifiers;
using SuperScript.Modifiers.Post;

namespace SuperScript.JavaScript.Modifiers.Post
{
    /// <summary>
    /// Minifies the specified string using Microsoft's WebGrease.
    /// </summary>
    public class JavaScriptMinifier : CollectionPostModifier
    {
        /// <summary>
        /// Minifies the JavaScript. If errors occur during the minification process then an error message is rendered in place.
        /// </summary>
        /// <remarks>
        /// This method uses Microsoft's WebGrease assembly.
        /// </remarks>
        /// <param name="args">
        /// An instance of <see cref="PreModifierArgs"/> where the 'Emitter' property contains the JavaScript to be minified.
        /// </param>
        /// <returns>A string containing the specified JavaScript in minified form.</returns>
        public override PostModifierArgs Process(PostModifierArgs args)
        {
            if (!this.ShouldEmitForCurrentContext())
            {
                return args;
            }

            var minifier = new Minifier();
            var cs = new CodeSettings {EvalLiteralExpressions = true};
            var str = minifier.MinifyJavaScript(args.Emitted, cs);

            if (!minifier.ErrorList.Any())
            {
                args.Emitted = str;
                return args;
            }

            var e = new StringBuilder();
            e.AppendLine("\r\n/*");
            foreach (var error in minifier.ErrorList)
            {
                e.Append("Error:\t");
                e.Append(error.Message);
                e.Append(", line ");
                e.Append(error.StartLine);
                e.Append(", column ");
                e.AppendLine(error.StartColumn.ToString(CultureInfo.InvariantCulture));
            }
            e.AppendLine("*/");

            args.Emitted = e.ToString();

            return args;
        }
    }
}