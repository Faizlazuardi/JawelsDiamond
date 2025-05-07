using JawelsDiamond.Controller;
using JawelsDiamond.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class AddJewelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfNotLoggedIn(Session, Response);
                SessionHandler.CheckAdmin(UserHandler.GetUserIdFromSession(), Response);
                RefreshFormView();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string jewelName = JewelNameInput.Text;
            int categoryId = int.TryParse(CategoryDropDownList.SelectedValue, out int parsedCategoryId) ? parsedCategoryId : 0;
            int brandId = int.TryParse(BrandDropDownList.SelectedValue, out int parsedBrandId) ? parsedBrandId : 0;
            string price = PriceInput.Text;
            string releaseYear = ReleaseInput.Text;


            JewelController jewelController = new JewelController();
            string result = jewelController.AddJewel(jewelName, parsedCategoryId, parsedBrandId, price, releaseYear);
            StatusMessage.Text = result;
        }

        private void RefreshFormView()
        {
            BindBrandDropDown();
            BindCategoryDropDown();
        }

        private void BindBrandDropDown()
        {
            var brands = BrandHandler.GetAllBrands();

            BrandDropDownList.DataSource = brands;
            BrandDropDownList.DataTextField = "BrandName";
            BrandDropDownList.DataValueField = "BrandID";
            BrandDropDownList.DataBind();

            BrandDropDownList.Items.Insert(0, new ListItem("-- Select Brand --", "0"));
        }

        private void BindCategoryDropDown()
        {
            var categories = CategoryHandler.GetAllCategories();
            CategoryDropDownList.DataSource = categories;
            CategoryDropDownList.DataTextField = "CategoryName";
            CategoryDropDownList.DataValueField = "CategoryID";
            CategoryDropDownList.DataBind();

            CategoryDropDownList.Items.Insert(0, new ListItem("-- Select Category --", "0"));
        }
    }
}