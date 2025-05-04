using JawelsDiamond.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Controller
{
    public class JewelController
    {
        public string UpdateJewel(int id, string name, int categoryId, int brandId, string price, string year)
        {
            if (string.IsNullOrEmpty(name) || categoryId == 0 || brandId == 0 ||
                string.IsNullOrEmpty(price) || string.IsNullOrEmpty(year))
            {
                return "All fields must be filled";
            }

            if (name.Length < 3 || name.Length > 25)
            {
                return "Jewel name must be between 3 to 25 characters";
            }

            int jewelPrice;
            if (!int.TryParse(price, out jewelPrice) || jewelPrice <= 25)
            {
                return "Price must be a number and more than $25";
            }

            int releaseYear;
            if (!int.TryParse(year, out releaseYear) || releaseYear >= DateTime.Now.Year)
            {
                return "Release year must be a number and less than the current year";
            }

            JewelHandler.UpdateJewel(id, brandId, categoryId, name, jewelPrice, releaseYear);
            return "Success";
        }
    }
}