using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace DogeKit_Pixel_2.Models
{
    public class DeviceList
    {
        [XmlArray("List"), XmlArrayItem(typeof(Device), ElementName = "Device")]
        public ObservableCollection<Device> Devices { get; }

        public DeviceList()
        {
            Devices = new ObservableCollection<Device>();
        }
    }
}
