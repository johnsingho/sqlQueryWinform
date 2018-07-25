using System.Collections;
using System.Configuration;
using System.Linq.Expressions;
using System.Xml;

namespace sqlQuery
{
    public class HistoryConfSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public HistoryCollection Historys
        {
            get
            {
                return (HistoryCollection)base[""];
            }
        }

        [ConfigurationProperty("SaveInfo")]
        public bool SaveInfo
        {
            get
            {
                return (bool) (base["SaveInfo"]??false);
            }
            set
            {
                base["SaveInfo"] = value;
            }
        }
    }

    public class HistoryCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HistoryElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HistoryElement)element).Host;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override string ElementName
        {
            get
            {
                return "history";
            }
        }

        public HistoryElement this[int index]
        {
            get
            {
                return (HistoryElement)BaseGet(index);
            }
            set
            {
                try
                {
                    if (BaseGet(index) != null)
                    {
                        BaseRemoveAt(index);
                    }
                }
                catch (ConfigurationErrorsException ex)
                {
                    //没有此索引
                }
                BaseAdd(index, value);
            }
        }

        public void Clear()
        {
            BaseClear();
        }
    }

    public class HistoryElement : ConfigurationElement
    {
        [ConfigurationProperty("host", IsRequired = true)]
        public string Host
        {
            get
            {
                return (string)base["host"];
            }
            set
            {
                base["host"] = value;
            }
        }

        [ConfigurationProperty("user", IsRequired = true)]
        public string User
        {
            get
            {
                return (string)base["user"];
            }
            set
            {
                base["user"] = value;
            }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get
            {

                return MyCrypt.Decode((string)base["password"]);
            }
            set
            {
                base["password"] = MyCrypt.Encode(value);
            }
        }
    }

}

