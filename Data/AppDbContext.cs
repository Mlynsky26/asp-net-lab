using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext: DbContext
    {
        private string Path { get; set; }
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
            modelBuilder.Entity<ContactEntity>().HasData(
                    new ContactEntity() { ContactId = 1, Name = "Adam", Email = "adam@gmail.com", Phone = "123456789", Birth = DateTime.Parse("2000-10-23") },
                    new ContactEntity() { ContactId = 2, Name = "jarek", Email = "jarek@gmail.com", Phone = "12345789", Birth = DateTime.Parse("2000-11-23") },
                    new ContactEntity() { ContactId = 3, Name = "marek", Email = "marek@gmail.com", Phone = "1234569", Birth = DateTime.Parse("1990-11-23") }
                );
        }

        public DbSet<ContactEntity> Contacts { get; set; }
    }
}
