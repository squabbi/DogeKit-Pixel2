using System;
using System.Xml.Serialization;

namespace DogeKit_Serializer.Models
{
    public class FactoryImage
    {
        /* Example URI: https://dl.google.com/dl/android/aosp/walleye-opd1.170816.010-factory-63083164.zip */
        public string Version { get; set; }
        public string Build { get; set; }
        [XmlAttribute]
        public string ReleaseId { get; set; }
    }
}
