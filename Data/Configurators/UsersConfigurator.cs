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
            var user = new IdentityUser
            {
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

            return modelBuilder;
        }
    }
}
