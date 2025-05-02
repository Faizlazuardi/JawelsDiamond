using JawelsDiamond.Controller;
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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfLoggedIn(Session, Response);
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string userEmail = EmailInput.Text;
            string userPassword = PasswordInput.Text;
            bool rememberMe = RememberMeCheckbox.Checked;

            AuthController authController = new AuthController();
            string result = authController.Login(userEmail, userPassword, rememberMe);

            if (result == "Success")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                StatusMessage.Text = result;
            }
        }
    }
}