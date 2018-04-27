using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Models
{
    public class EFItemRepository : IItemRepository
    {
        GummiBearKingdomDbContext db = new GummiBearKingdomDbContext();
        public EFItemRepository()
        {
            db = new GummiBearKingdomDbContext();
        }


        public EFItemRepository(GummiBearKingdomDbContext thisDb)
    {
        db = thisDb;
    }

    public IQueryable<Item> Items
    { get { return db.Items; } }

    public Item Save(Item item)
    {
        db.Items.Add(item);
        db.SaveChanges();
        return item;
    }

    public Item Edit(Item item)
    {
        db.Entry(item).State = EntityState.Modified;
        db.SaveChanges();
        return item;
    }

    public void Remove(Item item)
    {
        db.Items.Remove(item);
        db.SaveChanges();
    }
}

}
