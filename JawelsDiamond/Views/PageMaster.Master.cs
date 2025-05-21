using JawelsDiamond.Handlers;
using JawelsDiamond.Models;
using JawelsDiamond.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class HeaderMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    int userId = (int)HttpContext.Current.Session["UserID"];
                    MsUser user = UserHandler.GetUserByID(userId);

                    if (user != null)
                    {
                        string userRole = user.UserRole;

                        HomeNavItem.Visible = true;
                        ProfileNavItem.Visible = true;
                        LogoutNavItem.Visible = true;

                        if (userRole == "Admin")
                        {
                            AddJewelNavItem.Visible = true;
                            ReportsNavItem.Visible = true;
                            HandleOrdersNavItem.Visible = true;

                            CartNavItem.Visible = false;
                            MyOrdersNavItem.Visible = false;
                        }
                        else
                        {
                            CartNavItem.Visible = true;
                            MyOrdersNavItem.Visible = true;

                            AddJewelNavItem.Visible = false;
                            ReportsNavItem.Visible = false;
                            HandleOrdersNavItem.Visible = false;
                        }

                        LoginNavItem.Visible = false;
                        RegisterNavItem.Visible = false;
                    }
                }
                else
                {

                    HomeNavItem.Visible = true;
                    LoginNavItem.Visible = true;
                    RegisterNavItem.Visible = true;

                    CartNavItem.Visible = false;
                    MyOrdersNavItem.Visible = false;
                    ProfileNavItem.Visible = false;
                    LogoutNavItem.Visible = false;
                    AddJewelNavItem.Visible = false;
                    ReportsNavItem.Visible = false;
                    HandleOrdersNavItem.Visible = false;
                }
            }
        }
    }
}