using Microsoft.EntityFrameworkCore;
using CivicTransportSystem.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CivicTransportSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<CivicCard> CivicCards { get; set; }
        public DbSet<CivicDiscountedCard> CivicDiscountedCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CivicTransportSystem.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasDiscriminator<string>("CardType")
                .HasValue<CivicCard>("CivicCard")
                .HasValue<CivicDiscountedCard>("CivicDiscountedCard");
        }
    }
}
