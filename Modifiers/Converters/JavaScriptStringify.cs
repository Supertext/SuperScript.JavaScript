using System.Linq;
using System.Text;
using SuperScript.JavaScript.Declarables;
using SuperScript.Modifiers;
using SuperScript.Modifiers.Converters;

namespace SuperScript.JavaScript.Modifiers.Converters
{
    /// <summary>
    /// Converts the 'Declarations' property of the specified <see cref="PreModifierArgs"/> into an instance of <see cref="PostModifierArgs"/> 
    /// where the 'Emitted' property contains the stringified JavaScript.
    /// </summary>
    public class JavaScriptStringify : CollectionConverter
    {
        public override PostModifierArgs Process(PreModifierArgs args)
        {
            var decs = args.Declarations as DeclarationBase[] ?? args.Declarations.ToArray();

            var postArgs = new PostModifierArgs(args.CustomObject);

            if (!decs.Any())
            {
                return postArgs;
            }

            var contents = new StringBuilder();
            const string tab = "\t";

            foreach (var declaration in decs.Where(d => d != null))
            {
                contents.Append(tab);
                contents.AppendLine(declaration.ToString());
            }

            postArgs.Emitted = contents.ToString();

            return postArgs;
        }
    }
}