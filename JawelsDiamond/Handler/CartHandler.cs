using JawelsDiamond.Factory;
using JawelsDiamond.Models;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
    public class CartHandler
    {
        public static List<Cart> GetUserCart(int userId)
        {
            return CartRepository.GetCartByUserId(userId);
        }
        public static void AddToCart(int userId, int jewelId)
        {
            Cart cart = CartFactory.CreateCart(userId, jewelId, 1);
            CartRepository.AddToCart(cart);
        }

        public static void UpdateCartQuantity(int userId, int jewelId, int quantity)
        {
            CartRepository.UpdateCartQuantity(userId, jewelId, quantity);
        }

        public static void RemoveFromCart(int userId, int jewelId)
        {
            CartRepository.RemoveFromCart(userId, jewelId);
        }

        public static void ClearCart(int userId)
        {
            CartRepository.ClearCart(userId);
        }

        public static decimal GetCartTotal(int userId)
        {
            List<Cart> cartItems = CartRepository.GetCartByUserId(userId);
            return (decimal)cartItems.Sum(c => c.MsJewel.JewelPrice * c.Quantity);
        }
    }
}