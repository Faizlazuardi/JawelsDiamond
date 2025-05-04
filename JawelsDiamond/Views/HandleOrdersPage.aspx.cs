using JawelsDiamond.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class HandleOrdersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfNotLoggedIn(Session, Response);
                SessionHandler.CheckAdmin(UserHandler.GetUserIdFromSession(), Response);
                RefreshGridView();
            }
        }

        private void RefreshGridView()
        {
            GridViewHandlerOrders.DataSource = TransactionHandlers.GetUnfinishedTransactions();
            GridViewHandlerOrders.DataBind();
        }

        protected void ConfirmPaymentButton_Command(object sender, CommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int transactionId = Convert.ToInt32(GridViewHandlerOrders.DataKeys[rowIndex].Value);

            TransactionHandlers.UpdateTransactionStatus(transactionId, "Shipment Pending");
            RefreshGridView();
        }

        protected void ShipPackageButton_Command(object sender, CommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int transactionId = Convert.ToInt32(GridViewHandlerOrders.DataKeys[rowIndex].Value);

            TransactionHandlers.UpdateTransactionStatus(transactionId, "Arrived");
            RefreshGridView();
        }

        protected void GridViewHandlerOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();
                Button confirmPaymentButton = (Button)e.Row.FindControl("ConfirmPaymentButton");
                Button shipPackageButton = (Button)e.Row.FindControl("ShipPackageButton");
                Label statusMessageLabel = (Label)e.Row.FindControl("StatusMessageLabel");

                if (status == "Payment Pending")
                {
                    confirmPaymentButton.Visible = true;
                }
                else if (status == "Shipment Pending")
                {
                    shipPackageButton.Visible = true;
                }
                else if (status == "Arrived")
                {
                    statusMessageLabel.Text = "Waiting for user confirmation…";
                }
            }
        }
    }
}