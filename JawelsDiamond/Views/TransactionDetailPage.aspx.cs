using JawelsDiamond.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfNotLoggedIn(Session, Response);
                RefreshTransactionGridView();
            }
        }

        private void RefreshTransactionGridView()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (id != -1)
            {
                GridViewTransactionDetails.DataSource = TransactionHandler.GetUserTransactionsDetailed(id);
                GridViewTransactionDetails.DataBind();
            }
        }
    }
}