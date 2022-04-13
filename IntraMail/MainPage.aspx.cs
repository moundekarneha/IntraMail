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
    public partial class MainPage : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public MainPage()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string InboxId = Request.QueryString["InboxId"];
            if (Session["uname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if(InboxId != null)
            {
                String strlSql = "delete from SentMail where InboxId='" + InboxId + "'";
                
                DataSet dataSet = globalClass.GetInboxMails(InboxId);

                string UserId, MailTo, MailFrom, DateOfTran, Sub, Matter;
                UserId = dataSet.Tables["dt"].Rows[0]["UserId"].ToString();
                MailTo = Session["uname"].ToString();
                MailFrom = dataSet.Tables["dt"].Rows[0]["MailFrom"].ToString();
                DateOfTran = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                Sub = dataSet.Tables["dt"].Rows[0]["Sub"].ToString();
                Matter = dataSet.Tables["dt"].Rows[0]["Matter"].ToString();

                string strSql1 = "insert into Trash values(" + UserId + ",'" + MailTo + "','" + MailFrom + "','" + DateOfTran + "','" + Sub + "', '" + Matter + "')";
                bool b1 = globalClass.DeleteRow(strSql1);
                bool b = globalClass.DeleteRow(strlSql);

                if (b && b1)
                {
                    DisplayGrid();
                }
                
            }
            else
            {
                DisplayGrid();

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //Display on grid 
        private void DisplayGrid()
        {
            string welcomeName = globalClass.GetWelcomeName(Session["uname"].ToString());
            lblWelcome.Text = welcomeName;
            Session["welcomeString"] = welcomeName;

            DataSet dataSet = globalClass.ShowInboxMail(Session["uname"].ToString());
            gridDispInbox.DataSource = dataSet.Tables["dt"];
            gridDispInbox.Visible = true;
            gridDispInbox.DataBind();
            if (dataSet.Tables[0].Rows.Count == 0)
                lbl.Text = "Inbox is empty";
            else
                lbl.Text = "Inbox";
        }
    }
}