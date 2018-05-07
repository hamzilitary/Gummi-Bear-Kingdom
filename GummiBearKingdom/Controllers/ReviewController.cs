using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;

        public ReviewsController(IReviewRepository repo = null)
        {
            if (repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        public ViewResult Index()
        {
            return View(reviewRepo.Reviews.ToList());
        }

        public IActionResult Create(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            reviewRepo.Save(review);
            return RedirectToAction("Details", "Products", new { id = review.ItemId });
        }
        public IActionResult Delete(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            reviewRepo.Remove(thisReview);
            return RedirectToAction("Details", "Products", new { id = thisReview.ItemId });
        }
    }
}