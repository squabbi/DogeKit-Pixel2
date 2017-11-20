using System;
using System.Xml.Serialization;

namespace DogeKit_Pixel_2.Models
{
    public class FactoryImage
    {
        /* Example URI: https://dl.google.com/dl/android/aosp/walleye-opd1.170816.010-factory-63083164.zip */

        public string Version { get; }
        public string Build { get; }
        [XmlAttribute]
        public string ReleaseId { get; }
    }
}
