using System.Xml.Serialization;

namespace DogeKit_Pixel_2.Models
{
    public class TWRP
    {
        [XmlElement]
        public string Version { get; set; }
    }
}
