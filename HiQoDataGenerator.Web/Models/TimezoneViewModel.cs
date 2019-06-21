using System.Web.Helpers;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class TimezoneViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public string ToJson() => Json.Encode(this);

        public static TimezoneViewModel FromJson(string json) => Json.Decode<TimezoneViewModel>(json);
    }
}
