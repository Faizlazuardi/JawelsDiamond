using JawelsDiamond.Handlers;
using JawelsDiamond.Models;
using JawelsDiamond.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Controllers
{
    public class TransactionController
    {
        public static List<TransactionHeader> GetAllTransactions()
        {
            return TransactionHandler.GetAllTransactions();
        }
    }
}