using JawelsDiamond.Models;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Remoting.Messaging;
using System.Data.Entity.Infrastructure;

namespace JawelsDiamond.Repositories
{
    public class TransactionRepository
    {
        private static DbModel db = DatabaseSingleton.GetInstance();

        public static List<TransactionHeader> GetAllTransactions()
        {
            return db.TransactionHeader.ToList();
        }

        public static void InsertTransactionHeader(TransactionHeader header)
        {
            db.TransactionHeader.Add(header);
            db.SaveChanges();
        }

        public static void InsertTransactionDetail(TransactionDetail detail)
        {
            db.TransactionDetail.Add(detail);
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetTransactionsByUserId(int userId)
        {
            return db.TransactionHeader
                .Where(t => t.UserID == userId)
                .ToList();
        }

        public static List<TransactionDetail> GetDetailedTransactionsById(int transactionId)
        {
            return db.TransactionDetail
                .Include(td => td.MsJewel)
                .Include(td => td.TransactionHeader)
                .Where(td => td.TransactionHeader.TransactionID == transactionId)
                .ToList();
        }

        public static void UpdateTransactionStatus(int id, string status)
        {
            TransactionHeader transaction = db.TransactionHeader.Find(id);
            if (transaction != null)
            {
                transaction.TransactionStatus = status;
                db.SaveChanges();
            }
        }

        public static List<TransactionHeader> GetUnfinishedTransactions()
        {
            return db.TransactionHeader
                .Where(t => t.TransactionStatus != "Done" && t.TransactionStatus != "Rejected")
                .Include("MsUser")
                .ToList();
        }
    }
}