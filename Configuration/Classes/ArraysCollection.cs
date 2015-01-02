using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    [ConfigurationCollection(typeof (ArrayElement), AddItemName = "array", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ArraysCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ArrayElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ArrayElement) element).Name;
        }

        public new ArrayElement this[string name]
        {
            get { return (ArrayElement) BaseGet(name); }
        }
    }
}