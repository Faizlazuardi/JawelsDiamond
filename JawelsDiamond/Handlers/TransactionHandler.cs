using JawelsDiamond.Models;
using JawelsDiamond.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handlers
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetAllTransactions()
        {
            return TransactionRepository.GetAllTransactions();
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

        public static List<TransactionHeader> GetUnfinishedTransactions()
        {
            return TransactionRepository.GetUnfinishedTransactions();
        }
    }
}