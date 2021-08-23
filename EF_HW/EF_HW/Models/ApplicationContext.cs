using Microsoft.EntityFrameworkCore;

namespace EF_HW.Models
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<CountriesWithAllowed> CountriesWithAlloweds { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }
        public virtual DbSet<ProducingCountry> ProducingCountries { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public ApplicationContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaccine>()
                .HasOne(i => i.Country)
                .WithOne(i => i.Vaccine)
                .HasForeignKey<ProducingCountry>(i => i.VaccineId);

           modelBuilder.Entity<Disease>()
                .HasMany(i => i.Vaccines)
                .WithOne(i => i.Disease)
                .HasForeignKey(i => i.DiseaseId);

            modelBuilder.Entity<Vaccine>()
                .HasMany(i => i.AllCountries)
                .WithMany(i => i.Vaccines)
                .UsingEntity(i => i.ToTable("VaccineInCountries"));
        }

       
    }
}
