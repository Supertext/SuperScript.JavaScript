using SuperScript.JavaScript.Attributes;

namespace SuperScript.JavaScript
{
    public enum EnumAttribute
    {
        /// <summary>
        /// Specifies that the text in the <see cref="JsEnumTextAttribute"/> should be obtained, if the attribute has been declared.
        /// </summary>
        EnumText,

        /// <summary>
        /// Specifies that the enumerator's textual value should be obtained. All attributes will be ignored.
        /// </summary>
        None,

        /// <summary>
        /// Specifies that the text in the <see cref="OptionTextAttribute"/> should be obtained, if the attribute has been declared.
        /// </summary>
        OptionText
    }
}