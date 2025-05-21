using JawelsDiamond.Models;
using JawelsDiamond.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handlers
{
    public class BrandHandler
    {
        public static List<MsBrand> GetAllBrands()
        {
            return BrandRepository.GetAllBrands();
        }
    }
}