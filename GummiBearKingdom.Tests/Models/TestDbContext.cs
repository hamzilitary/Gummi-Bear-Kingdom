using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Models
{
    public class TestDbContext : GummiBearKingdomDbContext
    {
        public override DbSet<Item> Items { get; set; }
        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        
          =>  options.UseMySql(@"Server=localhost;database=gummibearkingdom_test;uid=root;pwd=root;");
        
    }
}