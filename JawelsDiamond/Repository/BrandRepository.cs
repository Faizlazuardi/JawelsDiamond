using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repository
{
    public class BrandRepository
    {
        private static DbEntities db = DatabaseSingleton.GetInstance();
        public static List<MsBrand> GetAllBrands()
        {
            return db.MsBrands.ToList();
        }
    }
}