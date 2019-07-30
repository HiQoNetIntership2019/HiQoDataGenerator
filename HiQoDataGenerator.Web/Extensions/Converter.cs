using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.Extensions
{
    public static class Converter
    {
        public static XDocument JsonToXml(string json, string rootName)
        {
            var xml = JsonConvert.DeserializeXNode(json, rootName, true);
            return xml;
        }

        public static string ObjectToXml(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            var xml = string.Empty;

            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writer, obj);
                    xml = stringWriter.ToString();
                }
            }
            return xml;
        }

        public static string ObjectToJson(IEnumerable<GeneratedObjectViewModel> objects)
        {
            JArray resultArray = new JArray();

            foreach (var obj in objects)
            {
                resultArray.Add(ObjectToJson(obj));
            }

            return resultArray.ToString();
        }

        private static JObject ObjectToJson(GeneratedObjectViewModel resultObject)
        {
            JObject result = new JObject();

            foreach (var f in resultObject.Fields)
            {
                result.Add(new JProperty(f.Name, f.Value));
            }

            return result;
        }
    }
}
