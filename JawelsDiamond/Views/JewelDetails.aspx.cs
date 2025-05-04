using JawelsDiamond.Handler;
using JawelsDiamond.Models;
using JawelsDiamond.Repository;
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
                ShowButtonForAdmin();
                ShowJewelDetails();
            }
        }

        private void ShowButtonForAdmin()
        {
            MsUser currentUser = UserHandler.GetUserByID(UserHandler.GetUserIdFromSession());
            if (currentUser.UserRole == "Admin")
            {
                AddToCartButton.Visible = false;
                DeleteButton.Visible = true;
                EditButton.Visible = true;
            }
        }

        private void ShowJewelDetails()
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
                if (Session["UserID"] == null)
                {
                    UserHandler.RestoreSessionFromCookie();
                }

                if (Session["UserID"] != null)
                {
                    int userId = (int)Session["UserID"];
                    CartHandler.AddToCart(userId, id);

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

        // TODO : Add user checking for admin
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            JewelHandler.DeleteJewel(id);
            Response.Redirect("HomePage.aspx");
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect($"UpdateJewelPage.aspx?id={id}");
        }
    }
}