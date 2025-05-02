using JawelsDiamond.Controller;
using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace JawelsDiamond.Handler
{
    public class SessionHandler
    {
        public static bool IsUserLoggedIn(HttpSessionState session)
        {
            AuthController authController = new AuthController();
            MsUser user = authController.ValidateRememberMeCookie();

            return session["user"] != null || user != null;
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
    }
}