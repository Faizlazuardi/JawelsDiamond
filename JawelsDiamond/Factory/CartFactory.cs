using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(int userID, int jewelID, int cartQuantity)
        {
            Cart cart = new Cart();
            cart.UserID = userID;
            cart.JewelID = jewelID;
            cart.Quantity = cartQuantity;
            return cart;
        }
    }
}