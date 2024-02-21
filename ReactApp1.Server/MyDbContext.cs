using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Models;
using ReactApp1.Server.Models.ViewModels;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ReactApp1.Server
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<TemperatureData> TemperatureData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Populate database with some test data on create.
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name  =  "Latvia" },
                new Country { Id = 2, Name = "Morocco" }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Latitude = 56.9677, Longitude = 24.105078, Name = "Riga", CountryId = 1 },
                new City { Id = 2, Latitude = 56.9077, Longitude = 24.106078, Name = "Somewhere around Riga", CountryId = 1 },
                new City { Id = 3, Latitude = 33.0084, Longitude = 25.105078, Name = "Rabat", CountryId = 2 },
                new City { Id = 4, Latitude = 34.0084, Longitude = 6.8539, Name = "Somewhere around Rabat", CountryId = 2 }
            );
        }
    }
}
