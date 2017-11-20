using System;
using System.Xml.Serialization;

namespace DogeKit_Pixel_2.Models
{
    class FactoryImage
    {
        /* Example URI: https://dl.google.com/dl/android/aosp/walleye-opd1.170816.010-factory-63083164.zip */

        public string Build { get; }
        public string ReleaseId { get; }

        public FactoryImage(string build, string releaseId)
        {
            this.Build = build;
            this.ReleaseId = releaseId;
        }
    }
}
