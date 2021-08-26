using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FilterWithCookies.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> logger;
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionMessage = context.Exception.Message;
            if (!context.ExceptionHandled &&
                     context.Exception is ArgumentOutOfRangeException)
            {
                context.Result = new ContentResult
                {
                    Content = $"В методе {actionName} возникло исключение: \n {exceptionMessage}"
                };

                context.ExceptionHandled = true;
            }

            logger.LogError(context.Exception, "Exception handled");
                context.ExceptionHandled = true;
            

            logger.LogInformation("CustomExceptionFilter.OnException");
        }
    }
}

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}