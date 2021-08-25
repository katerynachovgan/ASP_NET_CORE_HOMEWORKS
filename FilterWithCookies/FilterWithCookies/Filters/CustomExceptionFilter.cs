using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

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
            context.Result = new ContentResult
            {
                Content = $"In method {actionName} there is exeption: {exceptionMessage}"
            };

                logger.LogError(context.Exception, "Exception handled");
                context.ExceptionHandled = true;
            

            logger.LogInformation("CustomExceptionFilter.OnException");
        }
    }
}
