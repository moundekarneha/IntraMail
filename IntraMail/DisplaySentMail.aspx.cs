using IntraMail.DatabaseOperations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntraMail
{
    public partial class DisplaySentMail : System.Web.UI.Page
    {
        GlobalClass globalClass;
        public DisplaySentMail()
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

                string subject, date;
                subject = Request.QueryString["Sub"];
                date = Request.QueryString["Date"];
                Session["MailTo"] = Request.QueryString["MailTo"];
                Session["InboxID"] = Request.QueryString["InboxId"];

                Session["subject"] = subject;

                DataSet dataSet = globalClass.ShowSentMails(subject, Session["uname"].ToString(), date);
                gridDispInbox.DataSource = dataSet.Tables["dt"];
                gridDispInbox.Visible = true;
                gridDispInbox.DataBind();
                if (dataSet.Tables[0].Rows.Count == 0)
                    lbl.Text = "Inbox is empty";
                else
                    lbl.Text = "";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}