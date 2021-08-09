using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HW2_ChovhanK
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                
                endpoints.MapGet("/publish", async context =>
                {
                    await context.Response.WriteAsync("Publish");
                });

                endpoints.MapGet("/articleinfo", async context =>
                {
                    await context.Response.WriteAsync("Information about the article");
                });
                 
                endpoints.MapGet("/addcontent", async context =>
                {
                    await context.Response.WriteAsync("Add some content");
                });
                
                endpoints.MapGet("/checkarticle", async context =>
                {
                    await context.Response.WriteAsync("Check the article with some parameters");
                });
            });
            
        }
    }
}
