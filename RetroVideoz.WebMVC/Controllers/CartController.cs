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
    public class CartController : Controller
    {
        //private readonly VideoService _videoService;
        //private readonly ShoppingCart _shoppingCart;
        //public async ActionResult AddVideoItemToCart(int id)
        //{
        //    Video item =  _videoService.GetVideoByID(id);
        //    if(item != null)
        //    {
        //        _shoppingCart.AddVideoToCart(item);
        //    }
        //    return RedirectToAction(nameof(Cart));
        //} 
        // GET: Cart
        public ActionResult Index()
        {
            var service = new CartServices();
            var model = service.GetCarts();
            return View(model);
        }

        //GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Cart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = new CartServices();
            if (service.CreateCart(model))
            {
                TempData["SaveResult"] = "New cart created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cart could not be created.");
            return View(model);
        }
        //GET: Cart/Details/{id}
        public ActionResult Details(int id)
        {
            var service = new CartServices();
            var model = service.GetCartByID(id);
            return View(model);
        }
        //GET: Cart/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = new CartServices();
            var detail = service.GetCartByID(id);
            var model =
                new CartEdit
                {

                };
            return View(model);
        }

        //POST: Cart/Edit/{id}
        public ActionResult Edit(int id, CartEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.CartID != id)
            {
                ModelState.AddModelError("", "Cart ID mismatch.");
                return View(model);
            }
            var service = new CartServices();
            if (service.UpdateCart(model))
            {
                TempData["Save Result"] = "Cart has been updated.";
            }
            ModelState.AddModelError("", "Cart was not updated.");
            return View(model);
        }

        //GET: Cart/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = new CartServices();
            var cart = service.GetCartByID(id);
            return View(cart);
        }
        //POST: Cart/Delete/{id}
        public ActionResult DeletePost(int id)
        {
            var service = new CartServices();
            service.DeleteCart(id);
            TempData["Save Result"] = "Cart was not deleted.";
            return RedirectToAction("Index");
        }

        
    }
}