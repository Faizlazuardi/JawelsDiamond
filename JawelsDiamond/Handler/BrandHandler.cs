using JawelsDiamond.Models;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
    public class BrandHandler
    {
        public static List<MsBrand> GetAllBrands()
        {
            return BrandRepository.GetAllBrands();
        }
    }
}