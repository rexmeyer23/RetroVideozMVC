using RetroVideoz.Data;
using RetroVideoz.Models;
using RetroVideoz.Models.CartLineItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Services
{
    //private ApplicationDBContext context = new ApplicationDBContext();
    
    public class CartLineItemService
    {
        public bool CreateCartLineItem(CartLineItemCreate model, int videoID)
        {
            Video video;
            using (var ctx = new ApplicationDbContext())
            {
                video = ctx.Videos.Find(videoID);
                video.Quantity -= model.TotalQuantity;
                ctx.SaveChanges();
            }
         
                var entity =
                new CartLineItem()
                {
                    CartItemID = model.CartItemID,
                    TotalQuantity = model.TotalQuantity,
                    Video = video,
                };
            using (var ctx = new ApplicationDbContext())
            {
             
                ctx.CartLineItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CartLineItemListed> GetCartLineItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CartLineItems.ToList();
                List<CartLineItemListed> result = new List<CartLineItemListed>();
                foreach (CartLineItem v in query)
                {
                    CartLineItemListed cartItem = new CartLineItemListed
                    {
                        Title = v.Video.Title,
                        TotalPrice = v.CartLineItemPrice,
                        TotalQuantity = v.TotalQuantity
                    };
                    result.Add(cartItem);
            }
                return result;
            }
        }
        public IEnumerable<CartLineItemListed> GetCartLineItemByID(int cartLineID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CartLineItems
                    .Where(e => e.CartItemID == cartLineID)
                    .Select(v => new CartLineItemListed
                    {
                        Title = v.Video.Title,
                        TotalPrice = v.CartLineItemPrice,
                        TotalQuantity = v.TotalQuantity
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
