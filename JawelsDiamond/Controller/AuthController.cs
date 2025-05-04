using JawelsDiamond.Handler;
using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Controller
{
    public class AuthController
    {
        public string Register(string userName, string userPassword, string confirmPassword, string userEmail, string userDOBInput, string userGender)
        {
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(userPassword) ||
                string.IsNullOrEmpty(userGender))
            {
                return "All fields must be filled";
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(userEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return "Invalid User Email format";
            }

            if (userName.Length < 3 || userName.Length > 25)
            {
                return "Username must be between 3 to 25 characters";
            }

            if (userPassword.Length < 8 || userPassword.Length > 20 ||
                !System.Text.RegularExpressions.Regex.IsMatch(userPassword, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$"))
            {
                return "Password must be alphanumeric and 8 to 20 characters";
            }

            if (userPassword != confirmPassword)
            {
                return "Password and confirm password must match";
            }

            if (userGender != "Male" && userGender != "Female")
            {
                return "Gender must be Male or Female";
            }

            if (!DateTime.TryParse(userDOBInput, out DateTime userDOB))
            {
                return "Invalid date format. Please provide a valid date.";
            }

            if (userDOB >= new DateTime(2010, 1, 1))
            {
                return "Date of birth must be earlier than 01/01/2010";
            }

            bool result = UserHandler.RegisterUser(userName, userPassword, userEmail, userDOB, userGender);
            if (!result)
            {
                return "Email already exists";
            }

            return "Success";
        }

        public string Login(string email, string password, bool rememberMe)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "All fields must be filled";
            }

            MsUser user = UserHandler.Login(email, password);
            if (user == null)
            {
                return "Invalid email or password";
            }

            HttpContext.Current.Session["UserID"] = user.UserID;
            HttpContext.Current.Session["UserRole"] = user.UserRole;

            if (rememberMe)
            {
                HttpCookie cookie = new HttpCookie("user");
                cookie["email"] = user.UserEmail;
                cookie.Expires = DateTime.Now.AddDays(7);
                cookie.HttpOnly = true;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            return "Success";
        }

        public string ChangePassword(int userId, string oldPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                return "All fields must be filled";
            }

            if (newPassword.Length < 8 || newPassword.Length > 25 ||
                !System.Text.RegularExpressions.Regex.IsMatch(newPassword, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,25}$"))
            {
                return "New password must be alphanumeric and 8 to 25 characters";
            }

            if (newPassword != confirmPassword)
            {
                return "New password and confirm password must match";
            }

            bool result = UserHandler.ChangePassword(userId, oldPassword, newPassword);
            if (!result) 
            {
                return "Incorrect old password";
            }

            return "Success";
        }
    }
}