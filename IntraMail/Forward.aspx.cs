using IntraMail.DatabaseOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntraMail
{
    public partial class Forward : System.Web.UI.Page
    {
        GlobalClass globalClass;
        public Forward()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string welcomeName = globalClass.GetWelcomeName(Session["uname"].ToString());
                lblWelcome.Text = welcomeName;
            }
        }

        protected void btnForwardMail_Click(object sender, EventArgs e)
        {

            lblDisp.Text = "";
            try
            {
                if (!globalClass.CheckWhileRegister(txtMailTo.Text))
                {
                    if (globalClass.GetGridData(Session["uname"].ToString(),DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), txtMailTo.Text,Session["subject"].ToString()))
                    {
                        lblDisp.Text = "Mail has been Sent";
                        txtMailTo.Text = "";
                    }
                    else
                    {
                        lblDisp.Text = "Not sent";
                        txtMailTo.Text = "";
                    }
                }
                else
                {
                    lblDisp.Text = "Mail id not exists";
                    txtMailTo.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblDisp.Text = ex.Message;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}