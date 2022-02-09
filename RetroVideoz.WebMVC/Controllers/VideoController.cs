using Microsoft.AspNet.Identity;
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
        // GET: Video
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VideoService(userId);
            var model = service.GetVideos();

            return View(model);
        }
    }
}