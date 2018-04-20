using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBearKingdom.Controllers
{
    public class ItemsController : Controller
    {
        private GummiBearKingdomContext db = new GummiBearKingdomContext();
        public IActionResult Index()
        {
            List<Item> model = db.Items.ToList();
            return View(model);
            
        }

        public IActionResult Details(int id)
        {
            Item thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }
    }
}