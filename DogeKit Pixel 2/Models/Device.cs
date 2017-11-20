using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeKit_Pixel_2.Models
{
    class Device
    {
        private string Name { get; } 
        public string Codename { get; }
        [XmlElement]
        public List<FactoryImage> FactoryImages = new List<FactoryImage>();

        public void LoadFactoryImages()
        {
            FactoryImages.Clear();
            foreach (FactoryImage fi in )
            FactoryImages.Add(new FactoryImage())
        }
    }
}
