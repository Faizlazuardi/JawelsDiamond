using JawelsDiamond.Handler;
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
            TransactionHandlers.CheckoutCart(userId, paymentMethod);
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

            if (int.TryParse(textBoxQuantity.Text, out int newQuantity) && newQuantity > 0)
            {
                int userId = UserHandler.GetUserIdFromSession();
                CartHandler.UpdateCartQuantity(userId, jewelId, newQuantity);
                RefreshCartGridView();
            }
        }

    }
}
