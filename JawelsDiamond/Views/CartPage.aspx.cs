using JawelsDiamond.Controller;
using JawelsDiamond.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfNotLoggedIn(Session, Response);
                RefreshCartGridView();
            }
        }

        private void RefreshCartGridView()
        {
            int userId = UserHandler.GetUserIdFromSession();
            if (userId != -1)
            {
                GridViewCart.DataSource = CartHandler.GetUserCart(userId);
                GridViewCart.DataBind();
                TotalPriceLabel.Text = "Total Price: " + CartHandler.GetCartTotal(userId).ToString("C2");
            }
        }


        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            int userId = UserHandler.GetUserIdFromSession();
            string paymentMethod = PaymentList.SelectedValue;
            CartController cartController = new CartController();
            string result = cartController.Checkout(userId, paymentMethod);
            StatusMessage.Text = result;
            RefreshCartGridView();
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            Button removeButton = (Button)sender;

            GridViewRow row = (GridViewRow)removeButton.NamingContainer;

            int jewelId = Convert.ToInt32(removeButton.CommandArgument);

            int userId = UserHandler.GetUserIdFromSession();

            CartHandler.RemoveFromCart(userId, jewelId);

            RefreshCartGridView();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Button updateButton = (Button)sender;

            GridViewRow row = (GridViewRow)updateButton.NamingContainer;

            int jewelId = Convert.ToInt32(updateButton.CommandArgument);

            TextBox textBoxQuantity = (TextBox)row.FindControl("TextBoxQuantity");

            if (textBoxQuantity != null)
            {
                int userId = UserHandler.GetUserIdFromSession();
                CartController cartController = new CartController();
                string result = cartController.UpdateCartQuantity(userId, jewelId, textBoxQuantity.Text);

                if (result == "Success")
                {
                    StatusMessage.Text = result;
                    RefreshCartGridView();
                }
                else
                {
                    StatusMessage.Text = result;
                }
            }
        }

    }
}
