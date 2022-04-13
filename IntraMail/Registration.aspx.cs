using IntraMail.DatabaseOperations;
using System;

namespace IntraMail
{
    public partial class Registration : System.Web.UI.Page
    {
        GlobalClass globalClass;
        public Registration()
        {
            globalClass = new GlobalClass();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //clearing data
        private void ClearInfo()
        {
            txtAddress.Text = "";
            txtDob.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMobileNum.Text = "";
            txtSecAnswer.Text = "";
            txtUserName.Text = "";
            dropDownSecQuestions.SelectedItem.Text = "Please select";
            lblDisp.Text = "";
        }

        //Register user
        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                if (globalClass.CheckWhileRegister(txtUserName.Text))
                {
                    if (globalClass.Register(txtFirstName.Text, txtLastName.Text, txtUserName.Text, txtPassword.Text, txtDob.Text, txtMobileNum.Text, txtAddress.Text, dropDownSecQuestions.SelectedItem.Text.TrimStart(), txtSecAnswer.Text))
                    {
                        Response.Redirect("Login.aspx");
                        ClearInfo();
                    }
                    else
                    {
                        lblDisp.Text = "Registration Failed";
                        ClearInfo();
                    }
                }
                else
                {
                    lblDisp.Text = "User already exists";
                    ClearInfo();
                }
            }
            catch (Exception ex)
            {
                lblDisp.Text = ex.Message;
                ClearInfo();
            }


        }
    }
}