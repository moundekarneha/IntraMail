using IntraMail.DatabaseOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntraMail
{
    public partial class SecurityQue : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public SecurityQue()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (globalClass.CheckUser(txtUsername.Text))
                {
                    Session["user"] = txtUsername.Text;
                    string securityQuestion = globalClass.GetSecurityQue(txtUsername.Text);
                    Session["SecQue"] = securityQuestion;
                    lblDisp.Text = "";
                    Response.Redirect("SecurityAns.aspx");
                }
                else
                {
                    Response.Redirect("SecurityQue.aspx");
                    lblDisp.Text = "Username is not exist";
                }
            }
            catch (Exception ex)
            {
                lblDisp.Text = "";
                lblDisp.Text = ex.Message;
            }

        }
    }
}

