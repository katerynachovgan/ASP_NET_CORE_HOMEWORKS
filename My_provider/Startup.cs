using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace My_provider
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("conf.json");
            AppConfiguration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SchoolClass myClass = AppConfiguration.Get<SchoolClass>();

            app.Run(async context =>
            {
                string city = $"<div>City: {myClass.City}</div>";
                string schoolNumber = $"<div>Number of school: {myClass.SchoolNumber}</div>";
                string address = $"<div>School address: {myClass.Address}</div>";
                string schClass = $"<div>Class: {myClass.SchClass}</div>";
                string teacher = $"<div>Teacher: {myClass.Teacher?.FirstName }{myClass.Teacher?.LastName}</div>" +
                    $"<div>Teacher's work experience: {myClass.Teacher?.WorkExperience} years</div>" +
                    $"<div>Birthday: {myClass.Teacher?.Birthday}</div>";

                string students = $"<div>Students: </div><ul>";
                foreach (var student in myClass.StudentsList)
                {
                    students += $"<li>{student}</li>";
                }
                students += "</ul>";

                await context.Response.WriteAsync($"{city}{schoolNumber}{address}{schClass}{teacher} {students}");
            });
        }
    }
}
