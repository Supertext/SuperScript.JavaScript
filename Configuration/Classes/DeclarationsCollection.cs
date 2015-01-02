using System;
using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class DeclarationsCollection : ConfigurationElementCollection
    {
        private static readonly ConfigurationProperty ArrayCollectionElement = new ConfigurationProperty("arrays", typeof (ArraysCollection), null, ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty CallCollectionElement = new ConfigurationProperty("calls", typeof (CallsCollection), null, ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty CommentElement = new ConfigurationProperty("comment", typeof (CommentElement), null, ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty VariableCollectionElement = new ConfigurationProperty("variables", typeof (VariablesCollection), null, ConfigurationPropertyOptions.None);

        [ConfigurationProperty("arrays", IsRequired = false)]
        public ArraysCollection Arrays
        {
            get { return (ArraysCollection) this[ArrayCollectionElement]; }
        }

        [ConfigurationProperty("calls", IsRequired = false)]
        public CallsCollection Calls
        {
            get { return (CallsCollection) this[CallCollectionElement]; }
        }

        [ConfigurationProperty("comment", IsRequired = false)]
        public CommentElement Comment
        {
            get { return (CommentElement) this[CommentElement]; }
        }

        [ConfigurationProperty("variables", IsRequired = false)]
        public VariablesCollection Variables
        {
            get { return (VariablesCollection) this[VariableCollectionElement]; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            throw new NotImplementedException();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            throw new NotImplementedException();
        }
    }
}