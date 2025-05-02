using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace JawelsDiamond.Repository
{
    public class CartRepository
    {
        private static DbEntities db = DatabaseSingleton.GetInstance();

        public static List<Cart> GetCartByUserId(int userId)
        {
            return db.Carts
                .Include(c => c.MsJewel)
                .Include(c => c.MsJewel.MsBrand)
                .Where(c => c.UserID == userId)
                .ToList();
        }

        public static void AddToCart(Cart cart)
        {
            Cart existingCart = db.Carts.FirstOrDefault(c => c.UserID == cart.UserID && c.JewelID == cart.JewelID);
            if (existingCart != null)
            {
                existingCart.Quantity += cart.Quantity;
            }
            else
            {
                db.Carts.Add(cart);
            }
            db.SaveChanges();
        }

        public static void UpdateCartQuantity(int userId, int jewelId, int quantity)
        {
            Cart cart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cart != null)
            {
                cart.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public static void RemoveFromCart(int userId, int jewelId)
        {
            Cart cart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
        }

        public static void ClearCart(int userId)
        {
            var carts = db.Carts.Where(c => c.UserID == userId);
            db.Carts.RemoveRange(carts);
            db.SaveChanges();
        }
    }
}