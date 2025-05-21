using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace JawelsDiamond.Repositories
{
    public class CartRepository
    {
        private static DbModel db = DatabaseSingleton.GetInstance();

        public static List<Cart> GetCartByUserId(int userId)
        {
            return db.Cart
                .Include(c => c.MsJewel)
                .Include(c => c.MsJewel.MsBrand)
                .Where(c => c.UserID == userId)
                .ToList();
        }

        public static void AddToCart(Cart cart)
        {
            Cart existingCart = db.Cart.FirstOrDefault(c => c.UserID == cart.UserID && c.JewelID == cart.JewelID);
            if (existingCart != null)
            {
                existingCart.Quantity += cart.Quantity;
            }
            else
            {
                db.Cart.Add(cart);
            }
            db.SaveChanges();
        }

        public static void UpdateCartQuantity(int userId, int jewelId, int quantity)
        {
            Cart cart = db.Cart.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cart != null)
            {
                cart.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public static void RemoveFromCart(int userId, int jewelId)
        {
            Cart cart = db.Cart.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cart != null)
            {
                db.Cart.Remove(cart);
                db.SaveChanges();
            }
        }

        public static void ClearCart(int userId)
        {
            var carts = db.Cart.Where(c => c.UserID == userId);
            db.Cart.RemoveRange(carts);
            db.SaveChanges();
        }
    }
}