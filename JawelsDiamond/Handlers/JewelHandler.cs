using JawelsDiamond.Factory;
using JawelsDiamond.Models;
using JawelsDiamond.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handlers
{
    public class JewelHandler
    {
        public static List<MsJewel> GetAllJewels()
        {
            return JewelRepository.GetAllJewels();
        }

        public static MsJewel GetJewelById(int id)
        {
            return JewelRepository.GetJewelById(id);
        }
        public static void DeleteJewel(int id)
        {
            JewelRepository.DeleteJewel(id);
        }

        public static void UpdateJewel(int id, int brandId, int categoryId, string name, int price, int year)
        {
            MsJewel jewel = JewelRepository.GetJewelById(id);
            if (jewel != null)
            {
                jewel.BrandID = brandId;
                jewel.CategoryID = categoryId;
                jewel.JewelName = name;
                jewel.JewelPrice = price;
                jewel.JewelReleaseYear = year;
                JewelRepository.UpdateJewel(jewel);
            }
        }

        public static void AddJewel(int brandId, int categoryId, string name, int price, int year)
        {
            MsJewel jewel = JewelFactory.CreateJewel(brandId, categoryId, name, price, year);
            JewelRepository.InsertJewel(jewel);
        }
    }
}