using System;
using System.Collections.Generic;
using System.Linq;
using SuperScript.Emitters;
using SuperScript.JavaScript.Configuration;
using SuperScript.JavaScript.Declarables;

namespace SuperScript.JavaScript.ExtensionMethods
{
    /// <summary>
    /// Contains extension methods which can be invoked upon the classes which are implemented in the web.config &lt;superScript&gt; section.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Yields a <see cref="CommentDeclaration"/> object based upon the configured <see cref="CommentElement"/>.
        /// </summary>
        /// <param name="commentElement">This is expected to be configured in the web.config.</param>
        /// <param name="defaultEmitterKey">Required in case the <see cref="IEmitter"/> has not been specified.</param>
        public static CommentDeclaration ToDeclaration(this CommentElement commentElement, string defaultEmitterKey)
        {
            if (commentElement == null)
            {
                return null;
            }

            var commentOptions = new CommentOptions();
            commentOptions.Comment(commentElement.Text);
            commentOptions.EmitterKey(!String.IsNullOrWhiteSpace(commentElement.EmitterKey) ? commentElement.EmitterKey : defaultEmitterKey);

            return new CommentDeclaration(commentOptions);
        }


        /// <summary>
        /// Yields a collection of <see cref="ArrayDeclaration"/> objects based upon the configured <see cref="ArraysCollection"/>.
        /// </summary>
        /// <param name="arrayCollection">These are expected to be configured in the web.config.</param>
        /// <param name="defaultEmitterKey">Required in case the <see cref="IEmitter"/> has not been specified.</param>
        public static IEnumerable<ArrayDeclaration> ToDeclarations(this ArraysCollection arrayCollection, string defaultEmitterKey)
        {
            if (arrayCollection == null || arrayCollection.Count == 0)
            {
                yield break;
            }

            foreach (ArrayElement array in arrayCollection)
            {
                var items = new List<object>();

                if (array.Elements != null)
                {
                    items.AddRange(from string t in array.Elements
                                   select Convert.ChangeType(t, array.Type));
                }

                //items.AddRange(from ArrayElementElement t in array.ArrayElements
                //               select Convert.ChangeType(t.Value, array.Type));

                var arrayOptions = new ArrayOptions();
                arrayOptions.Comment(array.Comment);
                arrayOptions.Elements(items.ToArray());
                arrayOptions.EmitterKey(!String.IsNullOrWhiteSpace(array.EmitterKey) ? array.EmitterKey : defaultEmitterKey);
                arrayOptions.Name(array.Name);

                yield return new ArrayDeclaration(arrayOptions);
            }
        }


        /// <summary>
        /// Yields a collection of <see cref="CallDeclaration"/> objects based upon the configured <see cref="CallsCollection"/>.
        /// </summary>
        /// <param name="callCollection">These are expected to be configured in the web.config.</param>
        /// <param name="defaultEmitterKey">Required in case the <see cref="IEmitter"/> has not been specified.</param>
        public static IEnumerable<CallDeclaration> ToDeclarations(this CallsCollection callCollection, string defaultEmitterKey)
        {
            if (callCollection == null || callCollection.Count == 0)
            {
                yield break;
            }

            foreach (CallElement callElement in callCollection)
            {
                // build an object array of parameters
                var length = callElement.Parameters.Count;
                var parameters = new object[length];
                for (var i = 0; i < length; i++)
                {
                    var paramType = callElement.Parameters[i].Type;
                    parameters[i] = Convert.ChangeType(callElement.Parameters[i].Value, paramType);
                }

                var callOptions = new CallOptions();
                callOptions.Comment(callElement.Comment);
                callOptions.EmitterKey(!String.IsNullOrWhiteSpace(callElement.EmitterKey) ? callElement.EmitterKey : defaultEmitterKey);
                callOptions.FunctionName(callElement.FunctionName);
                callOptions.Parameters(parameters);

                yield return new CallDeclaration(callOptions);
            }
        }


        /// <summary>
        /// Yields a collection of <see cref="StandardDeclaration"/> objects based upon the configured <see cref="VariablesCollection"/>.
        /// </summary>
        /// <param name="variableCollection">These are expected to be configured in the web.config.</param>
        /// <param name="defaultEmitterKey">Required in case the <see cref="IEmitter"/> has not been specified.</param>
        public static IEnumerable<StandardDeclaration> ToDeclarations(this VariablesCollection variableCollection, string defaultEmitterKey)
        {
            if (variableCollection == null || variableCollection.Count == 0)
            {
                yield break;
            }

            foreach (VariableElement variableElement in variableCollection)
            {
                var varOptions = new VariableOptions();
                varOptions.Comment(variableElement.Comment);
                varOptions.EmitterKey(!String.IsNullOrWhiteSpace(variableElement.EmitterKey) ? variableElement.EmitterKey : defaultEmitterKey);
                varOptions.Name(variableElement.Name);
                varOptions.Value(Convert.ChangeType(variableElement.Value, variableElement.Type));

                yield return new StandardDeclaration(varOptions);
            }
        }
    }
}