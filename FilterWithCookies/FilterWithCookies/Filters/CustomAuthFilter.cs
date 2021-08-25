using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace FilterWithCookies.Filters
{
    public class CustomAuthFilter : Attribute, IAuthorizationFilter
    {
       
        public CustomAuthFilter()
        {
           
        }
       
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var builder = new ConfigurationBuilder()
              .AddJsonFile("config.json");

            var AppConfiguration = builder.Build();

            var key1 = AppConfiguration["key1"];
            var key2 = AppConfiguration["key2"];
            string headerKey = AppConfiguration["headerKey"];

            int k1 = Convert.ToInt32( context.HttpContext.Request.Cookies[key1] );
            int k2 = Convert.ToInt32( context.HttpContext.Request.Cookies[key2] );

            int hKey = Convert.ToInt32 ( context.HttpContext.Response.Headers[headerKey] );

            if( (k1 + k2) > hKey ) Console.WriteLine("OnAuthorization");
            else context.Result = new ContentResult { Content = "You cant use this URL." };
        }
    }
}
