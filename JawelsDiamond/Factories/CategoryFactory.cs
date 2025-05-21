using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Factory
{
    public class CategoryFactory
    {
        public static MsCategory CreateCategory(string categoryName)
        {
            MsCategory category = new MsCategory();
            category.CategoryName = categoryName;
            return category;
        }
    }
}