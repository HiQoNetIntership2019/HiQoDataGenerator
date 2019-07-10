using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HiQoDataGenerator.Web.ViewModels
{
    [XmlRoot("GeneratedObject")]
    public class GeneratedObjectViewModel
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        [XmlElement("Field")]
        public List<GeneratedFieldViewModel> Fields { get; set; }
    }
}
