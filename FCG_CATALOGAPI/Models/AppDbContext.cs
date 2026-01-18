using FCG_CATALOGAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FCG_CATALOGAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesItens> SalesItens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasKey(g => g.IdGames);
            //modelBuilder.Entity<Library>().HasKey(g => g.IdGames);
            modelBuilder.Entity<Sales>().HasKey(s => s.IdSales);
            modelBuilder.Entity<SalesItens>().HasKey(s => s.IdSalesItem);

            base.OnModelCreating(modelBuilder);
        }
    }
}