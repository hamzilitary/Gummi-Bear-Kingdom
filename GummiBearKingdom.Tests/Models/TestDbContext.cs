using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{
    public class TestDbContext : GummiBearKingdomDbContext
    {
        public override DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;database=gummibearkingdom_test;uid=root;pwd=root;");
        }
    }
}