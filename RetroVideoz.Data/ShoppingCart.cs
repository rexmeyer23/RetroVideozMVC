using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public  class ShoppingCart
    {
        
            public ApplicationDbContext _context { get; set; }
            public string ShoppingCartID { get; set; }
            public List<CartItem> CartItems { get; set; }
         public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }
      
        public void AddVideoToCart(Video video)
        {
            var cartItem = _context.CartItems.FirstOrDefault(n => n.Video.VideoID == video.VideoID && n.ShoppingCartID == ShoppingCartID);
            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    ShoppingCartID = ShoppingCartID,
                    Video = video,
                    Amount = 1
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveVideoFromCart(Video video)
        {
            var cartItem = _context.CartItems.FirstOrDefault(n => n.Video.VideoID == video.VideoID && n.ShoppingCartID == ShoppingCartID);
            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                }
                _context.CartItems.Add(cartItem);
            }
            else
            {
                _context.CartItems.Remove(cartItem);
            }
            _context.SaveChanges();
        }

    }
}
