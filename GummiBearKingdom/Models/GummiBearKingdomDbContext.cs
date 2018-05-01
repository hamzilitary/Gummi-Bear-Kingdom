using System;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{
    public class GummiBearKingdomDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=gummibearkingdom;uid=root;pwd=root;");
        public GummiBearKingdomDbContext(DbContextOptions<GummiBearKingdomDbContext> options)
            : base(options)
        {
        }

        public GummiBearKingdomDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}