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

            modelBuilder.Entity<OwnerEntity>().HasData(
                    new OwnerEntity() { Id = 1, Name = "Darek", Surname = "Kowalski", Phone = "123456789" },
                    new OwnerEntity() { Id = 2, Name = "Mariusz", Surname = "Nowak", Phone = "987654321" }
                );

            modelBuilder.Entity<CarEntity>().HasData(
                    new CarEntity() { Id = 1, Maker = "Seat", Name = "Ibiza", Volume = 1200, Power = 130, EngineType = 1, Registration = "KRA123AB", OwnerId = 1 },
                    new CarEntity() { Id = 2, Maker = "Opel", Name = "Astra", Volume = 1800, Power = 180, EngineType = 2, Registration = "WW123AB", OwnerId = 2 }
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
