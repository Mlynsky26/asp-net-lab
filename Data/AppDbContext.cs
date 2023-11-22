using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        private string Path { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var user = new IdentityUser { 
                Id = Guid.NewGuid().ToString(),
                UserName = "adam",
                NormalizedUserName = "ADAM",
                Email = "adam@gmail.com",
                NormalizedEmail = "ADAM@GMAIL.COM",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "zaq1@WSX");
            modelBuilder.Entity<IdentityUser>()
                .HasData(user);

            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id,
                    }
                );

            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole);

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
        }
    }
}
