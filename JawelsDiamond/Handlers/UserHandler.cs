using JawelsDiamond.Factory;
using JawelsDiamond.Models;
using JawelsDiamond.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handlers
{
    public class UserHandler
    {
        public static bool RegisterUser(string userName, string userPassword, string userEmail, DateTime userDOB, string userGender)
        {
            if (UserRepository.GetUserByEmail(userEmail) != null)
            {
                return false;
            }

            MsUser newUser = UserFactory.CreateUser(userName, userPassword, userEmail, userDOB, userGender, "Customer");
            UserRepository.InsertUser(newUser);
            return true;
        }

        public static MsUser Login(string email, string password)
        {
            return UserRepository.GetUserByEmailAndPassword(email, password);
        }

        public static MsUser GetUserByID(int userId)
        {
            return UserRepository.GetUserById(userId);
        }

        public static int GetUserIDByEmail(string email)
        {
            return UserRepository.GetIDByEmail(email);
        }

        public static int GetUserIdFromSession()
        {
            if (HttpContext.Current.Session["UserID"] != null)
            {
                return (int)HttpContext.Current.Session["UserID"];
            }
            else
            {
                HttpContext.Current.Response.Redirect("HomePage.aspx");
                return -1;
            }
        }

        public static void RestoreSessionFromCookie()
        {
            HttpCookie userCookie = HttpContext.Current.Request.Cookies["user"];
            if (userCookie != null && !string.IsNullOrEmpty(userCookie["email"]))
            {
                string email = userCookie["email"];
                int userId = GetUserIDByEmail(email);

                HttpContext.Current.Session["UserID"] = userId;
            }
        }

        public static bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            MsUser user = UserRepository.GetUserById(userId);
            if (user != null && user.UserPassword == oldPassword)
            {
                user.UserPassword = newPassword;
                UserRepository.UpdateUser(user);
                return true;
            }
            return false;
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();

            HttpCookie userCookie = HttpContext.Current.Request.Cookies["user"];
            if (userCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(userCookie);
            }

            HttpContext.Current.Response.Redirect("LoginPage.aspx");
        }
    }
}