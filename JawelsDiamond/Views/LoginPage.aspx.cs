using JawelsDiamond.Controller;
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

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string userEmail = EmailInput.Text;
            string userPassword = PasswordInput.Text;
            AuthController authController = new AuthController();
            string result = authController.Login(userEmail, userPassword);

            StatusMessage.Text = result;
        }
    }
}