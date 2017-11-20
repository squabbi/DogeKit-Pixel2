using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace DogeKit_Serializer.Models
{
    public class DeviceList
    {
        [XmlArray("List"), XmlArrayItem(typeof(Device), ElementName = "Device")]
        public ObservableCollection<Device> Devices { get; set; }

        public DeviceList()
        {
            Devices = new ObservableCollection<Device>();
        }
    }
}
