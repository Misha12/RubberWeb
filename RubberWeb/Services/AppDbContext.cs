using Microsoft.EntityFrameworkCore;
using RubberWeb.Entity;

namespace RubberWeb.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<KarmaItem> Karma { get; set; }
    }
}
