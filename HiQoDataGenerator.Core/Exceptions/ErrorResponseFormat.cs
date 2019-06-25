using Newtonsoft.Json;

namespace HiQoDataGenerator.Core.Exceptions
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorResponse() { }
        public ErrorResponse(int statusCode, string errorMessage)
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
