using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntraMail.DatabaseOperations;

namespace IntraMail
{
    public partial class DisplayMail : System.Web.UI.Page
    {
        GlobalClass globalClass;
        public DisplayMail()
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

                string subject,date;
                subject = Request.QueryString["Sub"];
                date = Request.QueryString["Date"];
                Session["InboxId"] = Request.QueryString["InboxId"];
                Session["MailFrom"] = Request.QueryString["MailFrom"];

                Session["subject"] = subject;

                DataSet dataSet = globalClass.ShowInboxMails(subject, Session["uname"].ToString(), date);
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