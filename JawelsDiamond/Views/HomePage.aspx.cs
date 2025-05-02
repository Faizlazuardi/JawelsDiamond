using JawelsDiamond.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshJewelGridView();
        }

        private void RefreshJewelGridView()
        {
            GridViewJewel.DataSource = JewelHandler.GetAllJewels();
            GridViewJewel.DataBind();
        }
    }
}