using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntraMail.DatabaseOperations;
using System.Data.SqlClient;
using System.Data;

namespace IntraMail
{
    public partial class SentMail : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public SentMail()
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
                string InboxId = Request.QueryString["InboxId"];
                if (InboxId != null)
                {
                    String strlSql = "delete from Inbox where InboxId='" + InboxId + "'";
                    DataSet dataSet = globalClass.GetSentMails(InboxId);

                    string UserId, MailTo, MailFrom, DateOfTran, Sub, Matter;
                    UserId= dataSet.Tables["dt"].Rows[0]["UserId"].ToString();
                    MailTo = dataSet.Tables["dt"].Rows[0]["MailTo"].ToString();
                    MailFrom = dataSet.Tables["dt"].Rows[0]["MailFrom"].ToString();
                    DateOfTran = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    Sub = dataSet.Tables["dt"].Rows[0]["Sub"].ToString();
                    Matter = dataSet.Tables["dt"].Rows[0]["Matter"].ToString();

                    string strSql1 = "insert into Trash values("+ UserId + ",'"+ MailTo + "','"+ MailFrom + "','"+ DateOfTran + "','"+ Sub + "', '"+ Matter + "')";
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

            DataSet dataSet = globalClass.ShowSentMail(Session["uname"].ToString());
            gridDispSentMail.DataSource = dataSet.Tables["dt"];
            gridDispSentMail.Visible = true;
            gridDispSentMail.DataBind();
            if (dataSet.Tables[0].Rows.Count == 0)
                lbl.Text = "Sent mails are empty";
            else
                lbl.Text = "Sent Mails";
        }
    }
}