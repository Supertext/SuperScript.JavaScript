using System;
using System.Collections.Generic;
using SuperScript.Configuration;
using SuperScript.JavaScript.Declarables;
using SuperScript.Emitters;
using SuperScript.ExtensionMethods;

namespace SuperScript.JavaScript
{
    /// <summary>
    /// <para>This static class offers the entire site a centralised location for adding instances of <see cref="DeclarationBase"/>.</para>
    /// <para>This collection should then be emitted in a convenient location.</para>
    /// <para>The developer can select whether to emit specific declarations in one location and the rest of the 
    /// collection in a different location, or simply emit them all together in a single location.</para>
    /// </summary>
    public static class Declarations
    {
        #region Properties

        private static IList<SuperScript.Declarables.DeclarationBase> collection;
        private static IEnumerable<IEmitter> emitters;


        /// <summary>
        /// Contains the collection of all JavaScript variables across this HTTP request.
        /// </summary>
        public static IList<SuperScript.Declarables.DeclarationBase> Collection
        {
            get { return collection ?? (collection = SuperScript.Declarations.Collection); }
        }


        /// <summary>
        /// Contains the instances of IEmitter which will be used to emit the <see cref="DeclarationBase"/> instances.
        /// </summary>
        public static IEnumerable<IEmitter> Emitters
        {
            get { return emitters ?? (emitters = SuperScript.Declarations.Emitters); }
        }

        #endregion


        #region Methods

        /// <summary>
        /// <para>Adds the specified array to the collection for the current HTTP request.</para>
        /// <para>This declaration will overwrite any previous declarations of a variable with the same name.</para>
        /// </summary>
        /// <exception cref="CollectionNotInstantiatedException">The <see cref="Collection"/> (ICollection{DeclarationBase}) property has not been instantiated. This should be done for each HTTP request.</exception>
        public static ArrayDeclaration AddArray(Action<ArrayOptions> optionConfig)
        {
            var options = DoDefault(optionConfig);

            if (String.IsNullOrEmpty(options._name))
            {
                throw new NotSpecifiedException("A name must be specified for this SuperScript array.");
            }

            // if a variable with the same name has already been declared then remove it from the collection
            //Collection.RemoveByName(name);

            var declaration = new ArrayDeclaration(options)
                              {
                                  AssignExisting = options._assignExisting,
                                  Elements = options._elements
                              };

            return SuperScript.Declarations.AddDeclaration<ArrayDeclaration>(declaration);
        }


        /// <summary>
        /// <para>Adds the specified function call with any specified parameters.</para>
        /// <para>Parentheses are not necessary - the function name will suffice.</para>
        /// </summary>
        /// <exception cref="CollectionNotInstantiatedException">The <see cref="Collection"/> (ICollection{DeclarationBase}) property has not been instantiated. This should be done for each HTTP request.</exception>
        public static CallDeclaration AddCall(Action<CallOptions> optionConfig)
        {
            var options = DoDefault(optionConfig);
            var declaration = new CallDeclaration(options);

            if (String.IsNullOrEmpty(options._functionName))
            {
                throw new NotSpecifiedException("A function name must be specified for this SuperScript function call.");
            }

            return SuperScript.Declarations.AddDeclaration<CallDeclaration>(declaration);
        }


        /// <summary>
        /// <para>Adds the specified text as a comment.</para>
        /// <para>Note that this comment will be emitted on a new line.</para>
        /// </summary>
        /// <remarks>
        /// If you wish to add a comment after any other JavaScript declaration, this can be specified in the same method call as the declaration.
        /// </remarks>
        /// <exception cref="CollectionNotInstantiatedException">The <see cref="Collection"/> (ICollection{DeclarationBase}) property has not been instantiated. This should be done for each HTTP request.</exception>
        public static CommentDeclaration AddComment(Action<CommentOptions> optionConfig)
        {
            var options = DoDefault(optionConfig);
            var declaration = new CommentDeclaration(options);

            return SuperScript.Declarations.AddDeclaration<CommentDeclaration>(declaration);
        }


        /// <summary>
        /// <para>Converts the specified enumerated type into a JavaScript-formatted enumeration.</para>
        /// <para>If no name is explicitly set for the JavaScript version of this enumerated type then the name of the enumerated type will be used.</para>
        /// </summary>
        /// <exception cref="CollectionNotInstantiatedException">The <see cref="Collection"/> (ICollection{DeclarationBase}) property has not been instantiated. This should be done for each HTTP request.</exception>
        public static EnumDeclaration AddEnum(Action<EnumeratedTypeOptions> optionConfig)
        {
            var options = DoDefault(optionConfig);
            var declaration = new EnumDeclaration(options);

            Collection.RemoveDuplicates(declaration);

            return SuperScript.Declarations.AddDeclaration<EnumDeclaration>(declaration);
        }


        /// <summary>
        /// <para>Converts the specified object into JavaScript Object Notation (JSON).</para>
        /// <para>If no name is explicitly set for the JavaScript version of this object then the name of the object will be used.</para>
        /// </summary>
        /// <exception cref="CollectionNotInstantiatedException">The <see cref="Collection"/> (ICollection{DeclarationBase}) property has not been instantiated. This should be done for each HTTP request.</exception>
        public static ObjectDeclaration AddObject(Action<ObjectOptions> optionConfig)
        {
            var options = DoDefault(optionConfig);
            var declaration = new ObjectDeclaration(options);

            Collection.RemoveDuplicates(declaration);

            return SuperScript.Declarations.AddDeclaration<ObjectDeclaration>(declaration);
        }


        /// <summary>
        /// Adds the specified properties as a JavaScript variable to the collection.
        /// </summary>
        /// <param name="optionConfig"></param>
        /// <returns></returns>
        public static StandardDeclaration AddVariable(Action<VariableOptions> optionConfig)
        {
            var options = DoDefault(optionConfig);
            var declaration = new StandardDeclaration(options);

            if (String.IsNullOrEmpty(options._name))
            {
                throw new NotSpecifiedException("A name must be specified for this SuperScript variable.");
            }

            // if this variable has already been declared then remove it from the collection
            Collection.RemoveDuplicates(declaration);

            return SuperScript.Declarations.AddDeclaration<StandardDeclaration>(declaration);
        }


        /// <summary>
        /// Internal method for handling the specified and default options.
        /// </summary>
        private static T DoDefault<T>(Action<T> optionConfig) where T : OptionsBase<T>, new()
        {
            var options = new T();
            optionConfig(options);
            if (String.IsNullOrWhiteSpace(options._emitterKey))
            {
                options.EmitterKey(Settings.Instance.DefaultEmitter.Key);
            }

            return options;
        }

        #endregion
    }
}