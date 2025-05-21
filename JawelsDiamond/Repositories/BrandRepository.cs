using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repositories
{
    public class BrandRepository
    {
        private static DbModel db = DatabaseSingleton.GetInstance();
        public static List<MsBrand> GetAllBrands()
        {
            return db.MsBrand.ToList();
        }
    }
}