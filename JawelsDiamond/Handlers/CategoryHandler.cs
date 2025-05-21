using JawelsDiamond.Models;
using JawelsDiamond.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handlers
{
    public class CategoryHandler
    {
        public static List<MsCategory> GetAllCategories()
        {
            return CategoryRepository.GetAllCategories();
        }
    }
}