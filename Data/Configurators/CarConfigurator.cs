using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class CarConfigurator
    {
        public static ModelBuilder OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>()
               .HasOne(c => c.Owner)
               .WithMany(o => o.Cars)
               .HasForeignKey(c => c.OwnerId);
            
            modelBuilder.Entity<CarEntity>()
               .HasOne(c => c.Maker)
               .WithMany(o => o.Cars)
               .HasForeignKey(c => c.MakerId);

            modelBuilder.Entity<OwnerEntity>().HasData(
                    new OwnerEntity() { Id = 1, Name = "Darek", Surname = "Kowalski", Phone = "123456789" },
                    new OwnerEntity() { Id = 2, Name = "Mariusz", Surname = "Nowak", Phone = "987654321" }
                );
            
            modelBuilder.Entity<MakerEntity>().HasData(
                    new MakerEntity() { Id = 1, Name = "Seat" },
                    new MakerEntity() { Id = 2, Name = "Opel" },
                    new MakerEntity() { Id = 3, Name = "BMW" },
                    new MakerEntity() { Id = 4, Name = "Mazada" },
                    new MakerEntity() { Id = 5, Name = "Audi" },
                    new MakerEntity() { Id = 6, Name = "Ford" },
                    new MakerEntity() { Id = 7, Name = "VolksWagen" },
                    new MakerEntity() { Id = 8, Name = "Mercedes" },
                    new MakerEntity() { Id = 9, Name = "Ferrari" },
                    new MakerEntity() { Id = 10, Name = "Renault" }
                );

            modelBuilder.Entity<CarEntity>().HasData(
                    new CarEntity() { Id = 1, MakerId = 1, Name = "Ibiza", Volume = 1200, Power = 130, EngineType = 1, Registration = "KRA123AB", OwnerId = 1 },
                    new CarEntity() { Id = 2, MakerId = 2, Name = "Astra", Volume = 1800, Power = 180, EngineType = 2, Registration = "WW123AB", OwnerId = 2 },
                    new CarEntity() { Id = 3, MakerId = 2, Name = "Vectra", Volume = 1400, Power = 100, EngineType = 2, Registration = "KK1237B", OwnerId = 1 }
                );

            modelBuilder.Entity<OwnerEntity>()
              .OwnsOne(o => o.Address)
              .HasData(
                  new
                  {
                      OwnerEntityId = 1,
                      City = "Krakow",
                      Street = "Filpa",
                      PostalCode = "31-200"
                  },
                  new
                  {
                      OwnerEntityId = 2,
                      City = "Warszawa",
                      Street = "Fiolkowa",
                      PostalCode = "54-120"
                  }
              );

            return modelBuilder;
        }
    }
}
