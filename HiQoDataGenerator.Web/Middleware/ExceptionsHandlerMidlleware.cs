using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using HiQoDataGenerator.Web.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HiQoDataGenerator.Web.Middleware
{
    public class ExceptionsHandlerMidlleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly string _contentType = "application/json";
        private readonly string _message = "Internal Server Error";

        private readonly int[] _supportedStatuses;

        public ExceptionsHandlerMidlleware(RequestDelegate next, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _next = next;        
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _supportedStatuses = configuration.GetSection("Elmah")?.GetSection("HttpStatusesForLogging")?.Get<int[]>() ?? new int[]{ };
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

                var responseStatusCode = httpContext.Response.StatusCode;
                if (_supportedStatuses.Contains(responseStatusCode))
                    ElmahCore.ElmahExtensions.RiseError(httpContext, new HttpException(responseStatusCode, ((HttpStatusCode)responseStatusCode).ToString()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: {0} | Message: {1} | StackTrace: {2}", ex.GetType().Name, ex.Message, ex.StackTrace);

                await HandleExceptionsAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionsAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = _contentType;

            if (_supportedStatuses.Contains(httpContext.Response.StatusCode))
                ElmahCore.ElmahExtensions.RiseError(httpContext, ex); 
            await httpContext.Response.WriteAsync(_message);
        }
    }
}
