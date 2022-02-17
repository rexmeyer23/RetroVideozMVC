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
        public bool CreateCart(CartCreate model)
        {
            var entity =
                new Cart()
                {
                  CartID = model.CartID,
                 UserID = model.UserID,
                TotalPrice = model.TotalPrice,

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
                        TotalPrice = cart.TotalPrice
                    };
                    list.Add(carts);
                }
                return list;
            }
        }
        public IEnumerable<VideoCartItems> GetCartByID(int cartID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CartLineItems
                    .Where(e => e.CartID == cartID)
                    .OrderBy(x => x.Video.Title)
                    .Select(v => new VideoCartItems
                    {
                        Title = v.Video.Title,
                        Price = v.Video.Price,
                        Quantity = v.Video.Quantity
                    });
                return query.ToArray();
            }
        }
        public IEnumerable<VideoCartItems> GetCartsByUser(string userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CartLineItems
                    .Where(e => e.Cart.UserID == userID)
                    .OrderBy(x => x.Video.Title)
                    .Select(v => new VideoCartItems
                    {
                        Title = v.Video.Title,
                        Price = v.Video.Price,
                        Quantity = v.Video.Quantity
                    });
                return query.ToArray();
            }
        }
        public bool UpdateCart(CartEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Carts
                    .Single(e => e.CartID.Equals(model.CartID));

                entity.UserID = model.UserID;
               
                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteCart(int cartID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Carts
                    .Single(e => e.CartID == cartID);
                ctx.Carts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

