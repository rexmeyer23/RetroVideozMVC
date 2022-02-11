using Microsoft.AspNet.Identity;
using RetroVideoz.Models;
using RetroVideoz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetroVideoz.WebMVC.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Reviews
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            var model = service.GetReviews();
            return View(model);
        }

        //GET: Review/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateReviewService();
            if (service.CreateReview(model))
            {
                ViewBag.SaveResult = "Review has been successfully added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Review could not be added.");
            return View(model);
        }

        //GET: Review/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateReviewService();
            var model = service.GetReviewByID(id);
            return View(model);
        }

        //GET: Review/Edit/{id}
       public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetReviewByID(id);
            var model =
                new ReviewEdit
                {
                    ReviewHeader = detail.ReviewHeader,
                    ReviewText = detail.ReviewText,
                    StarRating = detail.StarRating,
                    WouldRecommend = detail.WouldRecommend,
                };
            return View(model);
        }
        //POST: Review/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.ReviewID != id)
            {
                ModelState.AddModelError("", "Review ID mismatch.");
                return View(model);
            }
            var service = CreateReviewService();
            if (service.UpdateReview(model))
            {
                TempData["Save Result"] = "Review has been updated!";
            }
            ModelState.AddModelError("", "Review was not updated.");
            return View(model);
        }
        //GET: Review/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = CreateReviewService();
            var review = service.GetReviewByID(id);
            return View(review);
        }
        //POST: Review/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateReviewService();
            service.DeleteReview(id);
            TempData["Save Result"] = "Review was not deleted.";
            return RedirectToAction("Index");
        }
        private ReviewService CreateReviewService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userID);
            return service;
        }
    }
}