using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using FilterWithCookies.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterWithCookies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
           Configuration = configuration;

            
        }

        public IConfiguration Configuration { get; set; }
        public IConfigurationRoot AppConfiguration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            

            //services.AddSingleton<IConfiguration>(newConfiguration);

            //var key1 = newConfiguration["key1"];
            //var key2 = newConfiguration["key2"];

            //Console.WriteLine(key1, key2);

            services.AddSingleton<CustomAuthFilter>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json");

            var AppConfiguration = builder.Build();

            string key1 = AppConfiguration["key1"];
            string key2 = AppConfiguration["key2"];
            string keyHeader = AppConfiguration["headerKey"];

            app.Use(async (context, next) =>
            {
                if(context.Request.Cookies.ContainsKey(key1) && !context.Request.Cookies.ContainsKey(key2))
                {
                    context.Response.Cookies.Append(key1, "87");
                    context.Response.Cookies.Append(key2, "66");
                };
                if(!context.Request.Headers.ContainsKey(keyHeader))
                {
                    context.Response.Headers.Add(keyHeader, "100");

                }

                await next.Invoke();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
