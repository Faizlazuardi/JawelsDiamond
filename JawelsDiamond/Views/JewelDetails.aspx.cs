using JawelsDiamond.Handler;
using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class JewelDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfNotLoggedIn(Session, Response);
                ShowJewelDetails();
            }
        }

        public void ShowJewelDetails()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            MsJewel jewel = JewelHandler.GetJewelById(id);

            if (jewel != null)
            {
                JewelNameLabel.Text = jewel.JewelName;
                JewelCategoryLabel.Text = jewel.MsCategory.CategoryName;
                JewelBrandLabel.Text = jewel.MsBrand.BrandName;
                OriginLabel.Text = jewel.MsBrand.BrandCountry;
                ClassLabel.Text = jewel.MsBrand.BrandClass;
                PriceLabel.Text = jewel.JewelPrice.ToString();
                ReleaseLabel.Text = jewel.JewelReleaseYear.ToString();
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["id"], out int id))
            {
                MsUser currentUser = Session["user"] as MsUser;

                if (currentUser == null)
                {
                    HttpCookie userCookie = Request.Cookies["user"];
                    if (userCookie != null && !string.IsNullOrEmpty(userCookie["email"]))
                    {
                        string email = userCookie["email"];
                        currentUser = UserHandler.GetUserByEmail(email);

                        if (currentUser != null)
                        {
                            Session["user"] = currentUser;
                        }
                    }
                }

                if (currentUser != null)
                {
                    CartHandler.AddToCart(currentUser.UserID, id);

                    Response.Redirect("CartPage.aspx");
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}