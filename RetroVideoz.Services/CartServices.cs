using RetroVideoz.Data;
using RetroVideoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Services
{
    public class CartServices
    {
        public string CartID { get; set; }
        private VideoService _db;
        private CartServices _ds;
        public bool CreateCart(CartCreate model)
        {
            var entity =
                new Cart()
                {
                    CartID = model.CartID,
                    UserID = model.ApplicationUser.Username,
                    TransactionID = model.TransactionID,
                    VideosInCart = model.VideosInCart,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Carts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CartListItem> GetCarts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Carts.ToList();
                List<CartListItem> list = new List<CartListItem>();
                foreach (Cart cart in query)
                {
                    CartListItem carts = new CartListItem
                    {
                        CartID = cart.CartID,
                        TransactionID = cart.TransactionID,
                        VideosInCart = cart.VideosInCart,
                    };
                    list.Add(carts);
                }
                return list;
            }
        }
        public IEnumerable<CartListItem> GetCartsByID(int cartID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Carts
                    .Where(e => e.CartID == cartID)
                    .Select(e => new CartListItem
                    {
                        CartID = e.CartID,
                        TransactionID = e.TransactionID,
                        VideosInCart = e.VideosInCart,
                    });
                return query.ToArray();
            }
        }
        public IEnumerable<CartListItem> GetCartsByUser(string userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Carts
                    .Where(e => e.UserID == userID)
                    .Select(e => new CartListItem
                    {
                        CartID = e.CartID,
                        TransactionID = e.TransactionID,
                        VideosInCart = e.VideosInCart
                    });
                return query.ToArray();
            }
        }
        //add following method to controller
        public bool AddVideoToCart(int videoID)
        {
            var cartItem = _db.GetVideoByID(videoID);
            if (cartItem != null)
            {
                cartItem.Quantity
            }
            else
            {
                _ds.
            }

            //recall video database
            //select video
            //call cart
            //add item to cart

        }
        
        
        //public bool DeleteCart(int cartID)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            .ctx
        //            .Carts
        //            .Single
        //    }
        //}
    }
}

