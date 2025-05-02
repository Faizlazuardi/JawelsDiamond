using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repository
{
    public class UserRepository
    {
        private static DbEntities db = DatabaseSingleton.GetInstance();

        public static void InsertUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public static MsUser GetUserByEmail(string email)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserEmail == email);
        }

        public static MsUser GetUserByEmailAndPassword(string email, string password)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);
        }

        public static int GetIDByEmail(string email)
        {
            return db.MsUsers.Where(u => u.UserEmail == email).Select(u => u.UserID).FirstOrDefault();
        }
    }
}