using System;

namespace HiQoDataGenerator.Web.Exceptions
{public class HttpException : Exception
    {
        public int StatusCode { get; }

        public HttpException() : base() { }

        public HttpException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}

