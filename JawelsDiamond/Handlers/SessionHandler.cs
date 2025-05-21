using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace JawelsDiamond.Handlers
{
    public class SessionHandler
    {
        public static bool IsUserLoggedIn(HttpSessionState session)
        {
            if (session["UserID"] != null)
            {
                return true;
            }

            UserHandler.RestoreSessionFromCookie();

            return session["UserID"] != null;
        }

        public static void RedirectIfLoggedIn(HttpSessionState session, HttpResponse response)
        {
            if (IsUserLoggedIn(session))
            {
                response.Redirect("HomePage.aspx");
            }
        }

        public static void RedirectIfNotLoggedIn(HttpSessionState session, HttpResponse response)
        {
            if (!IsUserLoggedIn(session))
            {
                response.Redirect("HomePage.aspx");
            }
        }

        public static void CheckAdmin(int userId, HttpResponse response)
        {
            MsUser currentUser = UserHandler.GetUserByID(userId);
            if (currentUser.UserRole != "Admin")
            {
                response.Redirect("AccessDeniedPage.aspx");
            }
        }
    }
}