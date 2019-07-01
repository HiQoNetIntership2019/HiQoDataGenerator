using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace HiQoDataGenerator.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class LoggingAttribute : Attribute, IActionFilter
    {
        private readonly ILogger _logger;
        public LoggingAttribute(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("LoggingAttribute");
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var arguments = new List<String>();
            if (context.ActionArguments.Keys.Count != 0)
            {
                foreach (var key in context.ActionArguments.Keys)
                {
                    arguments.Add(key + ": " + context.ActionArguments[key]);
                }

                var argumentsInfo = arguments.Aggregate((current, next) => current + "," + next);
                _logger.LogInformation("Executing {0} with arguments: {1}.", context.ActionDescriptor.DisplayName, argumentsInfo);
            }
            else
            {
                _logger.LogInformation("Executing {0} with no arguments.", context.ActionDescriptor.DisplayName);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("{0} finished with status code {1}", context.ActionDescriptor.DisplayName, context.HttpContext.Response.StatusCode);
        }
    }
}
