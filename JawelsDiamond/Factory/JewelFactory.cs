using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Factory
{
    public class JewelFactory
    {
        public static MsJewel CreateJewel(int brandID, int categoryID, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            MsJewel jewel = new MsJewel();
            jewel.BrandID = brandID;
            jewel.CategoryID = categoryID;
            jewel.JewelName = jewelName;
            jewel.JewelPrice = jewelPrice;
            jewel.JewelReleaseYear = jewelReleaseYear;
            return jewel;
        }
    }
}