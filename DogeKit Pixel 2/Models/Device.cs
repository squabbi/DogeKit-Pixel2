using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace DogeKit_Pixel_2.Models
{
    public class Device
    {
        [XmlElement]
        public string Name { get; set; }
        [XmlAttribute]
        public string Codename { get; set; }
        [XmlElement]
        public ObservableCollection<FactoryImage> FactoryImages = new ObservableCollection<FactoryImage>();
        [XmlElement]
        public ObservableCollection<TWRP> RecoveryVersions = new ObservableCollection<TWRP>();

        public override string ToString()
        {
            return Name + " (" + Codename + ")";
        }
    }
}
