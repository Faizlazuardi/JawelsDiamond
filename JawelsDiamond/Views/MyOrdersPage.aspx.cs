using JawelsDiamond.Handlers;
using JawelsDiamond.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace JawelsDiamond.Views
{
    public partial class MyOrdersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfNotLoggedIn(Session, Response);
                RefreshOrderGridView();
            }
        }

        private void RefreshOrderGridView()
        {
            int userId = UserHandler.GetUserIdFromSession();
            if (userId != -1)
            {
                GridViewOrders.DataSource = Handlers.TransactionHandler.GetUserTransactions(userId);
                GridViewOrders.DataBind();
            }
        }

        protected void GridViewOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TransactionHeader transaction = (TransactionHeader)e.Row.DataItem;

                HyperLink LinkViewDetails = (HyperLink)e.Row.FindControl("LinkViewDetails");
                LinkViewDetails.NavigateUrl = $"TransactionDetailPage.aspx?id={transaction.TransactionID}";

                Button btnConfirm = (Button)e.Row.FindControl("ConfirmButton");
                Button btnReject = (Button)e.Row.FindControl("RejectButton");

                if (transaction.TransactionStatus == "Arrived")
                {
                    btnConfirm.Visible = true;
                    btnReject.Visible = true;
                }
                else
                {
                    btnConfirm.Visible = false;
                    btnReject.Visible = false;
                }
            }
        }

        protected void GridViewOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm" || e.CommandName == "Reject")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                int transactionId = Convert.ToInt32(GridViewOrders.DataKeys[rowIndex].Value);

                string newStatus = e.CommandName == "Confirm" ? "Done" : "Rejected";

                Handlers.TransactionHandler.UpdateTransactionStatus(transactionId, newStatus);

                RefreshOrderGridView();
            }
        }
    }
}