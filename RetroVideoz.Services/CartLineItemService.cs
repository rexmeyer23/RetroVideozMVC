using RetroVideoz.Data;
using RetroVideoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Services
{
    public class CartLineItemService
    {
        public bool CreateCartLineItem(CartLineItemCreate model)
        {
            var entity =
                new CartLineItem()
                {
                    CartItemID = model.CartItemID,
                    TotalQuantity = model.TotalQuantity,
                    Cart = model.Cart,
                    Video = model.Video,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CartLineItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<VideoCartItems> GetCartLineItemByID(int cartLineItemID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CartLineItems
                    .Where(e => e.CartItemID == cartLineItemID)
                    .Select(v => new VideoCartItems
                    {
                        Title = v.Video.Title,
                        Price = v.Video.Price,
                        Quantity = v.Video.Quantity
                    });
                return query.ToArray();
            }
        }
        public bool DeleteCartLineItem(int cartLineItemID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CartLineItems
                    .Single(e => e.CartItemID == cartLineItemID);
                ctx.CartLineItems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
