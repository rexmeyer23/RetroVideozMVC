using RetroVideoz.Data;
using RetroVideoz.Models;
using RetroVideoz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetroVideoz.WebMVC.Controllers
{
    public class CartLineItemController : Controller
    {

        // GET: CartLineItem
        public ActionResult Index()
        {
            var service = new CartLineItemService();
            var model = service.GetCartLineItems();
            return View(model);
        }

        //GET: CartLineItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartLineItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int videoID, CartLineItemCreate model)
        {
            var service = new CartLineItemService();
            if (service.CreateCartLineItem(model,videoID))
            {
                ViewBag.SaveResult = "Item has been added to your cart.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Item was not added to your cart.");
            return View(model);
        }

        //html action link need to pass in video id to url

        //GET: CartLineItem/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = new CartLineItemService();
            var cartItem = service.GetCartLineItemByID(id);
            return View(cartItem);
        }
        //POST: CartLineItem/Delete/{id}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new CartLineItemService();
            service.DeleteCartLineItem(id);
            TempData["Save Result"] = "Cart Item was not deleted.";
            return RedirectToAction("Index");

        }
        //public ActionResult BuyVideo(int id)
        //{
        //    var service = new VideoService();
        //    var videoItem = service.GetVideoByID(id);
        //    var video = _context.Videos.Find(id);
        //    VideoDetail videoListItem = new VideoDetail();
        //    if (Session["cart"] == null)
        //    {
        //        List<CartLineItem> cart = new List<CartLineItem>();
        //        cart.Add(new CartLineItem { Video = service.GetVideoByID(id), TotalQuantity = 1 });
        //    }
        //}
        //    public ActionResult RemoveFromCart(int id)
        //    {
        //        List<CartLineItem> service =  (List<CartLineItem>) Session["cart"];
        //    }
        //}
        //private int isExist(int id)
        //{
        //    List<CartLineItem> cartLine = (List<CartLineItem>)Session["cart"];
        //}
    }
}
