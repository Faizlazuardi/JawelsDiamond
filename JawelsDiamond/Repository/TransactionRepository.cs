using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repository
{
    public class TransactionRepository
    {
        private static DbEntities db = DatabaseSingleton.GetInstance();

        public static void InsertTransactionHeader(TransactionHeader header)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public static void InsertTransactionDetail(TransactionDetail detail)
        {
            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }
    }
}