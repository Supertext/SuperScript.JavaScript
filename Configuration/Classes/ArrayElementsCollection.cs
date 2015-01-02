using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    [ConfigurationCollection(typeof (ArrayElementElement), AddItemName = "element", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ArrayElementsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ArrayElementElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ArrayElementElement) element).Value;
        }

        public ArrayElementElement this[int index]
        {
            get { return (ArrayElementElement) BaseGet(index); }
        }
    }
}