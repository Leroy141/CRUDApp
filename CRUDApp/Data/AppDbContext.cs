using CRUDApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
