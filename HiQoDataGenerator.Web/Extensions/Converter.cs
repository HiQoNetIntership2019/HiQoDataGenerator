using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HiQoDataGenerator.Web.Extensions
{
    public static class Converter
    {
        public static XDocument JsonToXml(string json, string rootName)
        {
            var xml = JsonConvert.DeserializeXNode(json,rootName,true);
            return xml;
        }

        public static string ObjectToXml(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            var xml = "";

            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writer, obj);
                    xml = stringWriter.ToString();
                }
            }
            return xml;
            //var json = ObjectToJson(obj);
            //return JsonToXml(json, "rootName").ToString();
        }

        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
