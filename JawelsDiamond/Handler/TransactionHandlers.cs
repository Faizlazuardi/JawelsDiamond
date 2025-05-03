using JawelsDiamond.Factory;
using JawelsDiamond.Models;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
    public class TransactionHandlers
    {
        public static void CheckoutCart(int userId, string paymentMethod)
        {
            List<Cart> cartItems = CartRepository.GetCartByUserId(userId);
            if (cartItems.Count > 0)
            {
                TransactionHeader header = TransactionHeaderFactory.CreateTransactionHeader(
                    userId, DateTime.Now, paymentMethod, "Payment Pending");
                TransactionRepository.InsertTransactionHeader(header);

                foreach (Cart item in cartItems)
                {
                    TransactionDetail detail = TransactionDetailFactory.CreateTransactionDetail(
                        header.TransactionID, item.JewelID, (int)item.Quantity);
                    TransactionRepository.InsertTransactionDetail(detail);
                }

                CartRepository.ClearCart(userId);
            }
        }

        public static List<TransactionHeader> GetUserTransactions(int userId)
        {
            return TransactionRepository.GetTransactionsByUserId(userId);
        }

        public static List<TransactionDetail> GetUserTransactionsDetailed(int transactionId)
        {
            return TransactionRepository.GetDetailedTransactionsById(transactionId);
        }

        public static void UpdateTransactionStatus(int id, string status)
        {
            TransactionRepository.UpdateTransactionStatus(id, status);
        }
    }
}