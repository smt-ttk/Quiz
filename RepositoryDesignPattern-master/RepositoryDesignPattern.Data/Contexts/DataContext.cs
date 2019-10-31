using System;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Data.Models;

namespace RepositoryDesignPattern.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { Id = 1, CreateDate = DateTime.UtcNow, EMail = "e.dedeoglu@gmail.com", Name = "Erçin", Surname = "Dedeoğlu", Password = "1q2w3e4r", Username = "Phantasm"});
            modelBuilder.Entity<User>().HasData(new User { Id = 2, CreateDate = DateTime.UtcNow, EMail = "ata.dedeoglu@unknown.com", Name = "Ata", Surname = "Dedeoğlu", Password = "123456", Username = "Atiş"});
            modelBuilder.Entity<User>().HasData(new User { Id = 3, CreateDate = DateTime.UtcNow, EMail = "dedeco@yahoo.com", Name = "İmdat Ercan", Surname = "Dedeoğlu", Password = "1234", Username = "Eco"});
            modelBuilder.Entity<User>().HasData(new User { Id = 4, CreateDate = DateTime.UtcNow, EMail = "yusuf.dedeoglu@unknown.com", Name = "Yusuf", Surname = "Dedeoğlu", Password = "654321", Username = "Dedeler"});
        }

        public DbSet<User> Users { get; set; }
    }
}