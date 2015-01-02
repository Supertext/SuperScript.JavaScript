using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;

namespace SuperScript.JavaScript.Configuration
{
    public class ArrayElement : DeclarationElement
    {
        //private static readonly ConfigurationProperty ArrayItemCollectionElement = new ConfigurationProperty("arrayElements", typeof (ArrayElementsCollection), null, ConfigurationPropertyOptions.None);

        /// <summary>
        /// This property represents the 'elements' attribute.
        /// </summary>
        [ConfigurationProperty("elements", IsRequired = true)]
        [TypeConverter(typeof (CommaDelimitedStringCollectionConverter))]
        public StringCollection Elements
        {
            get { return (CommaDelimitedStringCollection) this["elements"]; }
        }

        [ConfigurationProperty("comment", IsRequired = false)]
        public string Comment
        {
            get { return (string) this["comment"]; }
        }

        /// <summary>
        /// This property represents the &lt;arrayElements&gt; node collection.
        /// </summary>
        //[ConfigurationProperty("arrayElements", IsRequired = false)]
        //public ArrayElementsCollection ArrayElements
        //{
        //    get { return (ArrayElementsCollection) this[ArrayItemCollectionElement]; }
        //}

        [ConfigurationProperty("emitterKey", IsRequired = false)]
        public string EmitterKey
        {
            get { return (string) this["emitterKey"]; }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string) this["name"]; }
        }

        [ConfigurationProperty("type", IsRequired = false, DefaultValue = "System.String, mscorlib")]
        [TypeConverter(typeof (TypeNameConverter))]
        public Type Type
        {
            get { return (Type) this["type"]; }
        }
    }
}