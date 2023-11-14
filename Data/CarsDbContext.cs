using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CarsDbContext: DbContext
    {
        private string Path { get; set; }
        public CarsDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "cars.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>().HasData(
                    new CarEntity() { Id = 1,Maker = "Seat", Name = "Ibiza", Volume = 1200, Power = 130, EngineType = "Benzyna", Registration = "KRA123AB", Owner = "Jarek" },
                    new CarEntity() { Id = 2,Maker = "Opel", Name = "Astra", Volume = 1800, Power = 180, EngineType = "Diesel", Registration = "WW123AB", Owner = "Darek" }
                );
        }
        public DbSet<CarEntity> Cars { get; set; }
    }
}
