using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class UsersConfigurator
    {
        public static ModelBuilder OnModelCreating(ModelBuilder modelBuilder)
        {
            var admin = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "adam",
                NormalizedUserName = "ADAM",
                Email = "adam@gmail.com",
                NormalizedEmail = "ADAM@GMAIL.COM",
                EmailConfirmed = true,
            };            
            
            var user = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "marek",
                NormalizedUserName = "MAREK",
                Email = "marek@gmail.com",
                NormalizedEmail = "MAREK@GMAIL.COM",
                EmailConfirmed = true,
            };
            
            var user2 = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "michal",
                NormalizedUserName = "MICHAL",
                Email = "michal@gmail.com",
                NormalizedEmail = "MICHAL@GMAIL.COM",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "zaq1@WSX");
            user.PasswordHash = passwordHasher.HashPassword(user, "zaq1@WSX");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "zaq1@WSX");

            modelBuilder.Entity<IdentityUser>()
                .HasData(admin, user, user2);

            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var userRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "user",
                NormalizedName = "USER"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;
            userRole.ConcurrencyStamp = userRole.Id;

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId = admin.Id,
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = userRole.Id,
                        UserId = user.Id,
                    }
                );

            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole, userRole);

            return modelBuilder;
        }
    }
}
