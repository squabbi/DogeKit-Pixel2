using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DogeKit_Serializer.Models
{
    public class TWRP
    {
        [XmlElement]
        public string Version { get; set; }
    }
}
