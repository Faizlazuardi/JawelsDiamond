using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repositories
{
    public class CategoryRepository
    {
        private static DbModel db = DatabaseSingleton.GetInstance();
        public static List<MsCategory> GetAllCategories()
        {
            return db.MsCategory.ToList();
        }
    }
}