using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    [ConfigurationCollection(typeof (VariableElement), AddItemName = "variable", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class VariablesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new VariableElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((VariableElement) element).Name;
        }

        public new VariableElement this[string name]
        {
            get { return (VariableElement) BaseGet(name); }
        }
    }
}