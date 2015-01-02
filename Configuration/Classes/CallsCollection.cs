using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    [ConfigurationCollection(typeof (CallElement), AddItemName = "call", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class CallsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CallElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CallElement) element).FunctionName;
        }

        public new CallElement this[string functionName]
        {
            get { return (CallElement) BaseGet(functionName); }
        }
    }
}