using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows;

namespace DogeKit_Pixel_2.Models
{
    class DeviceList
    {
        public List<Device> Devices;

        public DeviceList()
        {
            Devices = new List<Device>();
            try
            {
                ReadDeviceList();
            }
            catch (IOException ioEx)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageBox.Show("Fatal error. Unable to read 'devices.xml'.");
                Application.Current.Shutdown(1);
            }
        }

        protected void ReadDeviceList()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceList));
            FileStream fs = new FileStream(@"devices.xml", FileMode.Open);
            DeviceList dl;
            dl = (DeviceList)serializer.Deserialize(fs);

        }
    }
}
