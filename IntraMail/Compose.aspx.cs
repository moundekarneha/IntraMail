using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntraMail.DatabaseOperations;

namespace IntraMail
{
    public partial class Compose : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public Compose()
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
                
                lblWelcome.Text = Session["welcomeString"].ToString();
            }
        }

        //sign out
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //clear text
        private void ClearText()
        {
            txtMailTo.Text = "";
            txtMatter.Text = "";
            txtSubject.Text = "";
            //lblDisp.Text = "";
        }

        //send mail
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            lblDisp.Text = "";
            try
            {
                if (!globalClass.CheckWhileRegister(txtMailTo.Text))
                {
                    if (globalClass.ComposeMail(Session["uname"].ToString(), txtMailTo.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), txtSubject.Text, txtMatter.Text))
                    {
                        lblDisp.Text = "Mail has been Sent";
                        ClearText();
                    }
                    else
                    {
                        lblDisp.Text = "Not sent";
                    }
                }
                else
                {
                    lblDisp.Text = "Mail id not exists";
                    ClearText();
                }

            }
            catch (Exception ex)
            {
                ClearText();
                lblDisp.Text = ex.Message;
            }

        }

        protected void btnDraft_Click(object sender, EventArgs e)
        {
            if (!globalClass.CheckWhileRegister(txtMailTo.Text))
            {
                string userid = globalClass.GetUserId(Session["uname"].ToString()); 
                string strsql = "insert into Draft values("+ userid + ",'"+ txtMailTo.Text + "','"+ Session["uname"].ToString() + "', '"+ DateTime.Now.ToString("yyyy - MM - dd HH: mm: ss.fff") + "','" + txtSubject.Text +"', '"+ txtMatter.Text + "')";
                if (globalClass.DraftMail(strsql))
                {
                    lblDisp.Text = "Saved as draft";
                    ClearText();
                }
                else
                {
                    lblDisp.Text = "Not saved in draft";
                }
            }
            else
            {
                lblDisp.Text = "Mail id not exists";
                ClearText();
            }
        }
    }
}