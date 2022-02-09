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


    public class VideoController : Controller
    {
        // GET: Video -- list videos in admin database
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VideoService(userId);
            var model = service.GetVideos();

            return View(model);
        }

        // GET: Video Details
        public ActionResult Details(int id)
        {
            var service = CreateVideoService();
            var model = service.GetVideoByID(id);

            return View(model);
        }

        //GET: Create Video 
        public ActionResult Create()
        {
            return View();
        }
        //POST: Create Video
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateVideoService();
            if (service.CreateVideo(model))
            {
                ViewBag.SaveResult = "Video has been successfuly added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Video could not be added.");
            return View(model);
        }

        //GET: Update Video
        public ActionResult Edit(int id)
        {
            var service = CreateVideoService();
            var detail = service.GetVideoByID(id);
            var model =
                new VideoEdit
                {
                    VideoID = detail.VideoID,
                    Title = detail.Title,
                    Description = detail.Description,
                    Year = detail.Year,
                    Rating = detail.Rating,
                    Genre = detail.Genre,
                    Format = detail.Format,
                    Price = detail.Price,

                };
            return View(model);
        }

        //POST: Update Video
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VideoEdit model)
        {
            if(!ModelState.IsValid) return View(model);
            if(model.VideoID != id)
            {
                ModelState.AddModelError("", "Video ID mismatch");
                return View(model);
            }
            var service = CreateVideoService();
            if (service.UpdateVideo(model))
            {
                TempData["Save Result"] = "The Video was updated!";
            }
            ModelState.AddModelError("", "Video was not updated.");
            return View(model);
        }
        //GET: Delete Video
        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var svc = CreateVideoService();
            var model = svc.GetVideoByID(id);
            return View(model);
        }
        //POST: Delete Video
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVideoService(); 
            service.DeleteVideo(id);
            TempData["Save Result"] = "Video was not deleted";
            return RedirectToAction("Index");
        }
        private VideoService CreateVideoService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VideoService(userID);
            return service;
        }
    }
}