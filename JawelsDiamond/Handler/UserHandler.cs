using JawelsDiamond.Factory;
using JawelsDiamond.Models;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
    public class UserHandler
    {
        public static bool RegisterUser(string userName, string userPassword, string userEmail, DateTime userDOB, string userGender)
        {
            if(UserRepository.GetUserByEmail(userEmail) != null)
            {
                return false;
            }

            MsUser newUser = UserFactory.CreateUser(userName, userPassword, userEmail, userDOB, userGender, "Customer");
            UserRepository.InsertUser(newUser);
            return true;
        }
    }
}