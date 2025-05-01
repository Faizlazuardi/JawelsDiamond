using JawelsDiamond.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string userName = UsernameInput.Text;
            string userPassword = PasswordInput.Text;
            string confirmPassword = ConfirmPasswordInput.Text;
            string userEmail = EmailInput.Text;
            string userDOB = DateInput.Text;
            string userGender = GenderList.SelectedValue;
            AuthController authController = new AuthController();
            string result = authController.Register(userName, userPassword, confirmPassword, userEmail, userDOB, userGender);

            StatusMessage.Text = result;
        }
    }
}