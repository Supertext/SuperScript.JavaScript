using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    [ConfigurationCollection(typeof (EnumElement), AddItemName = "enum", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class EnumsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EnumElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EnumElement) element).Name;
        }

        public new EnumElement this[string name]
        {
            get { return (EnumElement) BaseGet(name); }
        }
    }
}