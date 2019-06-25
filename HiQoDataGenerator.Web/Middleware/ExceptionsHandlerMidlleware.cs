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
        private readonly string _defaultErrorMessage = "undefined error";
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

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
                _logger.LogError("Exception: {0}; Message: {1}", ex.GetType().Name, ex.Message);

                await HandleExceptionsAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionsAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = _defaultErrorMessage;

            if (ex is NotImplementedException)
            {
                message = "Request type not implemented";
                status = HttpStatusCode.NotImplemented;
            }else if (ex is ElementNotFoundException)
            {
                status = HttpStatusCode.NotFound;
                message = "Requested element not found";
            }else if (ex is ElementIsAlreadyExistException)
            {
                status = HttpStatusCode.BadRequest;
                message = "Element is already exist";
            }

            httpContext.Response.StatusCode = (int)status;
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(new ErrorResponse()
            {
                StatusCode = (int)status,
                Message = message
            }.ToString());
        }
    }
}
