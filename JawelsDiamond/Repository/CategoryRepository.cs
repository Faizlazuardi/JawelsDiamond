using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repository
{
    public class CategoryRepository
    {
        private static DbEntities db = DatabaseSingleton.GetInstance();
        public static List<MsCategory> GetAllCategories()
        {
            return db.MsCategories.ToList();
        }
    }
}