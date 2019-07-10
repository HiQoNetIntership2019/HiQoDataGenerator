using Newtonsoft.Json;
using System.Xml.Serialization;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class GeneratedFieldViewModel
    {
        [XmlAttribute]
        public string Name { get; set; }
        public dynamic Value { get; set; }
    }
}