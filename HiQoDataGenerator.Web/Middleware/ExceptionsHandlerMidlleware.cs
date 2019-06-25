using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Logging;
using HiQoDataGenerator.Core.Exceptions;

namespace HiQoDataGenerator.Web.Middleware
{
    public class ExceptionsHandlerMidlleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly string _contentType = "application/json";

        public ExceptionsHandlerMidlleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;        
            _logger = loggerFactory.CreateLogger(GetType().Name);
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: {0} | Message: {1} | StackTrace: {2}", ex.GetType().Name, ex.Message, ex.StackTrace);

                await HandleExceptionsAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionsAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = _contentType;

            return httpContext.Response.WriteAsync(new ErrorResponse() { Message = ex.Message }.ToString());
        }
    }
}
