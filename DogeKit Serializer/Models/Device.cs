using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace DogeKit_Serializer.Models
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

        public void AddFactoryImage(string build, string releaseId, string version)
        {
            FactoryImages.Add(new FactoryImage() { Build = build, ReleaseId = releaseId, Version = version });
        }

        public bool fiExists(string relId)
        {
            foreach (FactoryImage fi in FactoryImages)
            {
                if (fi.ReleaseId == relId)
                    return true;
            }
            return false;
        }

        public bool twrpExists(string ver)
        {
            foreach (TWRP twrp in RecoveryVersions)
            {
                if (twrp.Version == ver)
                    return true;
            }
            return false;
        }

        public void LoadFactoryImages()
        {
            FactoryImages.Clear();
            foreach (FactoryImage fi in FactoryImages)
            {
                FactoryImages.Add(fi);
            }
        }

        public override string ToString()
        {
            return Name + " (" + Codename + ")";
        }
    }
}
