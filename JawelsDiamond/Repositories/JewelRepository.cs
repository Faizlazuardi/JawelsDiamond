using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repositories
{
    public class JewelRepository
    {
        private static DbModel db = DatabaseSingleton.GetInstance();
        public static List<MsJewel> GetAllJewels()
        {
            return db.MsJewel.Include("MsBrand").Include("MsCategory").ToList();
        }

        public static MsJewel GetJewelById(int id)
        {
            return db.MsJewel.Include("MsBrand").Include("MsCategory").FirstOrDefault(j => j.JewelID == id);
        }

        public static void DeleteJewel(int id)
        {
            MsJewel jewel = db.MsJewel.Find(id);
            if (jewel != null)
            {
                db.MsJewels.Remove(jewel);
                db.SaveChanges();
            }
        }
        public static void UpdateJewel(MsJewel jewel)
        {
            db.Entry(jewel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void InsertJewel(MsJewel jewel)
        {
            db.MsJewels.Add(jewel);
            db.SaveChanges();
        }
    }
}