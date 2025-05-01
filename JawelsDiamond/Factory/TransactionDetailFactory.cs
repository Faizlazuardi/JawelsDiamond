using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail(int transactionID, int jewelID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = transactionID;
            transactionDetail.JewelID = jewelID;
            transactionDetail.Quantity = quantity;
            return transactionDetail;
        }
    }
}