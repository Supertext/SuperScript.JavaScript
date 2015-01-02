/*
Based partly on the following tutorial, but with lots of changes:
http://www.codeproject.com/Articles/19980/Data-Binding-an-Enum-with-Descriptions
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SuperScript.JavaScript.Attributes;

namespace SuperScript.JavaScript.ExtensionMethods
{
    /// <summary>
    /// Provides a static utility object of methods and properties to interact with enumerated types. 
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// <para>
        ///     Gets the <see cref="JsEnumTextAttribute"/> of an <see cref="Enum"/> type value.
        /// </para>
        /// <para>
        ///     If the attribute has not been declared then the enumeration string will be returned.
        /// </para>
        /// </summary>
        /// <param name="value">The <see cref="Enum"/> type value.</param>
        /// <param name="attr">An enumeration of <see cref="Attribute"/> which specifies an attribute whose value should be retrieved.</param>
        /// <returns>A string containing the text of the <see cref="JsEnumTextAttribute"/>.</returns>
        private static string GetAttribute(Enum value, EnumAttribute attr)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (attr == EnumAttribute.None)
            {
                return value.ToString();
            }

            var attrValue = value.ToString();
            var fieldInfo = value.GetType().GetField(attrValue);

            switch (attr)
            {
                case EnumAttribute.EnumText:
                    var attrDesc = (JsEnumTextAttribute[]) fieldInfo.GetCustomAttributes(typeof (JsEnumTextAttribute), false);
                    if (attrDesc.Length > 0)
                    {
                        return attrDesc[0].JsEnumText.Replace(" ", string.Empty);
                    }
                    break;

                case EnumAttribute.OptionText:
                    var attrOptText = (OptionTextAttribute[]) fieldInfo.GetCustomAttributes(typeof (OptionTextAttribute), false);
                    if (attrOptText.Length > 0)
                    {
                        return attrOptText[0].OptionText;
                    }
                    break;
            }
            return attrValue;
        }


        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <param name="valueAttr">An enumeration of <see cref="Attribute"/> which specifies an attribute whose value should be retrieved for the textual property.</param>
        /// <returns>An <see cref="IList"/> containing a collection of KeyValuePair&lt;int, string&gt; objects which describe the enum.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "This is a more advanced use of the ToList function; providing a type parameter has no semantic meaning for this function and would actually make the calling syntax more complicated.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IList<SerializedEnumerator> ToList(this Type type, EnumAttribute valueAttr = EnumAttribute.None)
        {
            var list = new List<SerializedEnumerator>();

            if (type == null || !type.IsEnum)
            {
                return list;
            }

            list.AddRange(from Enum value in Enum.GetValues(type)
                          select new SerializedEnumerator
                                 {
                                     ID = (int) Convert.ChangeType(value, typeof (int)),
                                     Text = GetAttribute(value, valueAttr)
                                 });

            return list;
        }
    }


    public class SerializedEnumerator
    {
        #region Properties

        public int ID { get; set; }
        public string Text { get; set; }

        #endregion

        #region Constructors

        public SerializedEnumerator()
        {
        }

        public SerializedEnumerator(int id, string text)
        {
            ID = id;
            Text = text;
        }

        #endregion
    }
}