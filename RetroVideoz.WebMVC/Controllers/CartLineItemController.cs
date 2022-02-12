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
        private ApplicationDbContext _context;
        // GET: CartLineItem
        public ActionResult Index()
        {
            var service = new CartServices();
            var model = service.GetCarts();
            return View(model);
        }

        //GET: CartLineItem/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: CartLineItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartLineItemCreate model)
        {
            if(!ModelState.IsValid) return View(model);
            var service = new CartLineItemService();
            Video video = _context.Videos.Find(model.VideoID);
            if (model.TotalQuantity <= video.Quantity)
            {
                video.Quantity -= model.TotalQuantity;
                if (service.CreateCartLineItem(model))
                {
                    TempData["Save Result"] = "Item has been added to your cart.";
                    return RedirectToAction("Index");
                }
              
            }
            ModelState.AddModelError("", "Item was not added to your cart.");
            return View(model);
        }
      
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
    }
}