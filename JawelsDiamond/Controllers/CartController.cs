using JawelsDiamond.Handlers;
using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Controller
{
    public class CartController
    {
        public string UpdateCartQuantity(int userId, int jewelId, string quantity)
        {
            if (string.IsNullOrEmpty(quantity))
            {
                return "Quantity must be filled";
            }

            int qty;
            if (!int.TryParse(quantity, out qty) || qty <= 0)
            {
                return "Quantity must be numeric and more than 0";
            }

            CartHandler.UpdateCartQuantity(userId, jewelId, qty);
            return "Success";
        }

        public string Checkout(int userId, string paymentMethod)
        {
            if (string.IsNullOrEmpty(paymentMethod))
            {
                return "Payment method must be selected";
            }

            List<Cart> cartItems = CartHandler.GetUserCart(userId);
            if (cartItems.Count == 0)
            {
                return "Cart is empty";
            }

            CartHandler.CheckoutCart(userId, paymentMethod);
            return "Success";
        }
    }
}