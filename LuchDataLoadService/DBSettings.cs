using System;
using System.Xml.Serialization;

namespace LuchDataLoadService
{
    [Serializable]
    public class DBSettings
    {
        public DBConnectionString TargetDBConnectionString { get; set; }
        public DBConnectionString[] SourceDBConnections { get; set; }
    }

    [Serializable]
    public class DBConnectionString
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
