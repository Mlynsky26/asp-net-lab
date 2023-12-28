using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ContactConfigurator
    {
        public static ModelBuilder OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>()
               .HasOne(c => c.Organization)
               .WithMany(o => o.Contacts)
               .HasForeignKey(c => c.OrganizationId);
            modelBuilder.Entity<OrganizationEntity>().HasData(
                    new OrganizationEntity() { Id = 1, Name = "Organizacja", Description = "Bardzo fajny opis" },
                    new OrganizationEntity() { Id = 2, Name = "Firma", Description = "Nie fajny opis" }
                );

            modelBuilder.Entity<ContactEntity>().HasData(
                    new ContactEntity() { ContactId = 1, Name = "Adam", Email = "adam@gmail.com", Phone = "123456789", Birth = DateTime.Parse("2000-10-23"), OrganizationId = 1 },
                    new ContactEntity() { ContactId = 2, Name = "jarek", Email = "jarek@gmail.com", Phone = "12345789", Birth = DateTime.Parse("2000-11-23"), OrganizationId = 1 },
                    new ContactEntity() { ContactId = 3, Name = "marek", Email = "marek@gmail.com", Phone = "1234569", Birth = DateTime.Parse("1990-11-23"), OrganizationId = 2 }
                );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Address)
                .HasData(
                    new
                    {
                        OrganizationEntityId = 1,
                        City = "Krakow",
                        Street = "Filpa",
                        PostalCode = "31-200"
                    },
                    new
                    {
                        OrganizationEntityId = 2,
                        City = "Warszawa",
                        Street = "Fiolkowa",
                        PostalCode = "54-120"
                    }
                );

            return modelBuilder;
        }
    }
}
