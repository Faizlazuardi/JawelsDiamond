using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repositories
{
    public class UserRepository
    {
        private static DbModel db = DatabaseSingleton.GetInstance();

        public static void InsertUser(MsUser user)
        {
            db.MsUser.Add(user);
            db.SaveChanges();
        }

        public static MsUser GetUserByEmail(string email)
        {
            return db.MsUser.FirstOrDefault(u => u.UserEmail == email);
        }

        public static MsUser GetUserByEmailAndPassword(string email, string password)
        {
            return db.MsUser.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);
        }

        public static int GetIDByEmail(string email)
        {
            return db.MsUser.Where(u => u.UserEmail == email).Select(u => u.UserID).FirstOrDefault();
        }

        public static MsUser GetUserById(int id)
        {
            return db.MsUser.Find(id);
        }

        public static void UpdateUser(MsUser user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}