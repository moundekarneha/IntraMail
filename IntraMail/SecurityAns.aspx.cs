using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntraMail.DatabaseOperations;

namespace IntraMail
{
    public partial class SecurityAns : System.Web.UI.Page
    {
        GlobalClass globalClass;
        public SecurityAns()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
                txtSecQues.Text = Session["SecQue"].ToString();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Session["secAns"] = txtSecAnw.Text;
            if (Session["secAns"] != null)
            {
                if (globalClass.CheckSecAnw(Session["secAns"].ToString(), Session["SecQue"].ToString(), Session["user"].ToString()))
                {
                    Response.Redirect("ForgetPassword.aspx");
                }
                else
                {
                    lblDisp.Text = "Invalid security answer";
                }
            }
            else
            {
                Response.Redirect("SecurityQue.aspx");
            }

        }
    }
}