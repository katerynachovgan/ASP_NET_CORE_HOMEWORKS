using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EF_HW.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EF_HW
{
    class ApplicationCntextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            var connectonString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectonString);

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
