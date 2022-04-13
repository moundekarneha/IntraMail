using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntraMail.DatabaseOperations;
namespace IntraMail
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public ForgetPassword()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("SecurityQue.aspx");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string secQue = Session["SecQue"].ToString();
                string user = Session["user"].ToString();
                bool status = globalClass.ForgetPass(user, txtPassword.Text, secQue);
                if (status)
                {
                    lblDisp.Text = "Password Changed";
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblDisp.Text = ex.Message;

            }

        }
    }
}