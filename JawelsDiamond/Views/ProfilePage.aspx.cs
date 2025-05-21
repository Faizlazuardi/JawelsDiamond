using JawelsDiamond.Controller;
using JawelsDiamond.Handlers;
using JawelsDiamond.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfNotLoggedIn(Session, Response);
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string oldPassword = OldPasswordInput.Text;
            string newPassword = NewPasswordInput.Text;
            string confirmPassword = ConfirmPasswordInput.Text;

            AuthController authController = new AuthController();
            string result = authController.ChangePassword(UserHandler.GetUserIdFromSession(),oldPassword, newPassword, confirmPassword);
            
            StatusMessage.Text = result;
        }
    }
}