using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    [ConfigurationCollection(typeof (ParameterElement), AddItemName = "parameter", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ParametersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ParameterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ParameterElement) element).Value;
        }

        public ParameterElement this[int index]
        {
            get { return (ParameterElement) BaseGet(index); }
        }
    }
}