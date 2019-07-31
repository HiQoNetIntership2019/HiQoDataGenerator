using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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

        public static string ObjectToXml(IEnumerable<GeneratedObjectViewModel> objects)
        {
            var xDoc = new XDocument();
            var xCollection = new XElement("ObjectsCollection", objects.Select(obj =>
                new XElement("Item", obj.Fields.Select(field => 
                    new XElement(field.Name, field.Value)))));

            xDoc.Add(xCollection);
            return xDoc.ToString();
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
