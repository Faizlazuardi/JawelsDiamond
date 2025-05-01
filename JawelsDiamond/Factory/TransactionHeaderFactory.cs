using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransactionHeader(int userID, DateTime transactionDate, string paymentMethod, string transactionStatus)
        {
            TransactionHeader transactionHeader = new TransactionHeader();
            transactionHeader.UserID = userID;
            transactionHeader.TransactionDate = transactionDate;
            transactionHeader.PaymentMethod = paymentMethod;
            transactionHeader.TransactionStatus = transactionStatus;
            return transactionHeader;
        }
    }
}