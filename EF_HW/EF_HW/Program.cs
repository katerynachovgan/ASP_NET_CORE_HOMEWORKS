using System;
using System.IO;
using System.Linq;
using EF_HW.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            var connectonString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectonString);


            /*  using (var db = new ApplicationContext(optionsBuilder.Options))
              {
                  var pfizer = new Vaccine { Name = "Pfizer" };
                  var moderna = new Vaccine { Name = "Moderna" };
                  var astrazeneca = new Vaccine { Name = "AstraZeneca" };
                  var coronavac = new Vaccine { Name = "CoronaVac" };

                  db.Vaccines.AddRange(pfizer, moderna, astrazeneca, coronavac);

                  db.SaveChanges();
              }*/


            /*   using (var db = new ApplicationContext(optionsBuilder.Options))
               {
                   var vacList = db.Vaccines.ToList();
                   foreach (var item in vacList)
                   {
                       db.Vaccines.Remove(item);
                   }

                   db.SaveChanges();
               }
            */

            /*using (var db = new ApplicationContext(optionsBuilder.Options))
             {
                  var pfizer = new Vaccine { Name = "Pfizer" };
                  var moderna = new Vaccine { Name = "Moderna" };
                  var astrazeneca = new Vaccine { Name = "AstraZeneca" };
                  var coronavac = new Vaccine { Name = "CoronaVac" };

                  db.Vaccines.AddRange(pfizer, moderna, astrazeneca, coronavac);

                 var pfizerProd = new ProducingCountry { Name = "Germany", Capital = "Berlin", Vaccine = pfizer};
                 var modernaProd = new ProducingCountry { Name = "USA", Capital = "Washington", Vaccine = moderna };
                 var azenecaProd = new ProducingCountry { Name = "Sweden", Capital = "Stokholm", Vaccine = astrazeneca };
                 var coronavacProd = new ProducingCountry { Name = "China", Capital = "Beijing", Vaccine = coronavac};

                 db.ProducingCountries.AddRange(pfizerProd, modernaProd, azenecaProd, coronavacProd);

                 db.SaveChanges();
             } */

            /* using (var db = new ApplicationContext(optionsBuilder.Options))
             {
                 var vacList = db.Vaccines.ToList();
                 foreach (var item in vacList)
                 {
                     db.Vaccines.Remove(item);
                 }

                 var countList = db.ProducingCountries.ToList();
                 foreach (var item in countList)
                 {
                     db.ProducingCountries.Remove(item);
                 }


                 db.SaveChanges();
             }*/

            /* using (var db = new ApplicationContext(optionsBuilder.Options))
             {
                 var disease = new Disease { Name = "Coronavirus_Disease" };
                 db.Diseases.Add(disease);

                 var pfizer = new Vaccine { Name = "Pfizer", Disease = disease };
                 var moderna = new Vaccine { Name = "Moderna", Disease = disease };
                 var astrazeneca = new Vaccine { Name = "AstraZeneca", Disease = disease };
                 var coronavac = new Vaccine { Name = "CoronaVac", Disease = disease };

                 db.Vaccines.AddRange(pfizer, moderna, astrazeneca, coronavac);

                 var pfizerProd = new ProducingCountry { Name = "Germany", Capital = "Berlin", Vaccine = pfizer };
                 var modernaProd = new ProducingCountry { Name = "USA", Capital = "Washington", Vaccine = moderna };
                 var azenecaProd = new ProducingCountry { Name = "Sweden", Capital = "Stokholm", Vaccine = astrazeneca };
                 var coronavacProd = new ProducingCountry { Name = "China", Capital = "Beijing", Vaccine = coronavac };

                 db.ProducingCountries.AddRange(pfizerProd, modernaProd, azenecaProd, coronavacProd);

                 var ukraine = new CountriesWithAllowed { Name = "Ukraine" };
                 var russia = new CountriesWithAllowed { Name = "Russia" };
                 var france = new CountriesWithAllowed { Name = "France" };
                 var poland = new CountriesWithAllowed { Name = "Poland" };
                 var greece = new CountriesWithAllowed { Name = "Greece" };
                 var canada = new CountriesWithAllowed { Name = "Canada" };
                 var mexico = new CountriesWithAllowed { Name = "Mexico" };
                 var australia = new CountriesWithAllowed { Name = "Australia" };

                 db.CountriesWithAlloweds.AddRange(ukraine, russia, france, poland, greece, canada, mexico, australia);

                 db.SaveChanges();
             } */

            using (var db = new ApplicationContext(optionsBuilder.Options))
            {
                var vac = db.Vaccines.FirstOrDefault();
                db.Vaccines.Remove(vac);

                var anotherCity = db.ProducingCountries.FirstOrDefault();
                anotherCity.Capital = "anotherCity";

                db.SaveChanges();
            }   
        }
    }
}
