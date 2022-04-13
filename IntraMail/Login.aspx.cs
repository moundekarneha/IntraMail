using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntraMail.DatabaseOperations;

namespace IntraMail
{
    public partial class Login : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public Login()
        {
            globalClass = new GlobalClass();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

         //clear text
         private void ClearText()
        {
            txtEmail.Text = "";
            txtPass.Text = "";
            lblDisp.Text = "";

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(globalClass.CheckGmailLogin(txtEmail.Text,txtPass.Text))
                {
                    Session["uname"] = txtEmail.Text;
                    Response.Redirect("MainPage.aspx");
                    ClearText();
                }
                else
                {
                    lblDisp.Text = "Login Failed";
                }

            }
            catch (Exception ex)
            {
                lblDisp.Text = ex.Message;
                ClearText();
            }
        }
    }
}