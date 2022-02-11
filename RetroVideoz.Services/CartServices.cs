﻿using RetroVideoz.Data;
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
                        //TransactionID = cart.TransactionID,
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
                    .Videos
                    .Where(e => e.CartID == cartID)
                    .OrderBy(x => x.Title)
                    .Select(v => new VideoCartItems
                    {
                        Title = v.Title,
                        Price = v.Price,
                        Quantity = v.Quantity
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
                    .Videos
                    .Where(e => e.Cart.UserID == userID)
                    .OrderBy(x => x.Title)
                    .Select(v => new VideoCartItems
                    {
                        Title = v.Title,
                        Price = v.Price,
                        Quantity = v.Quantity
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

                entity.CartID = model.CartID;
                //entity.TransactionID = model.TransactionID;
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

