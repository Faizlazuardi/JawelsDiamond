using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Factory
{
    public class UserFactory
    {
        public static MsUser CreateUser(string userName, string userPassword, string userEmail, DateTime userDOB, string userGender, string userRole)
        {
            MsUser user = new MsUser();
            user.UserName = userName;
            user.UserPassword = userPassword;
            user.UserEmail = userEmail;
            user.UserDOB = userDOB;
            user.UserGender = userGender;
            user.UserRole = userRole;
            return user;
        }
    }
}