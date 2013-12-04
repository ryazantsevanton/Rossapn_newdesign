using System;
using System.Xml.Serialization;


namespace LuchDataLoadService
{
    [Serializable]
    public class MapSettings
    {
        public MappingLine[] Lines { get; set; }
    }

    [Serializable]
    public class MappingLine
    {
        [XmlAttribute("object")]
        public string ObjectName { get; set; }

        [XmlAttribute("branch")]
        public string BranchName { get; set; }

        [XmlAttribute("group")]
        public string GroupName { get; set; }

        [XmlAttribute("parameter")]
        public string ParameterName { get; set; }

        [XmlText]
        public string Tag { get; set; }
    }
}
