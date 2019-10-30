using FinalApi.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FinalApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {
        }

       public DbSet<User> Users { get; set; }
    }
}
