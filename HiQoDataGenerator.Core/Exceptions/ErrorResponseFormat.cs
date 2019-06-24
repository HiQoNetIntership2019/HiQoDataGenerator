using Newtonsoft.Json;

namespace HiQoDataGenerator.Core.Exceptions
{
    public class ErrorResponseFormat
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorResponseFormat(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            Message = errorMessage;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
