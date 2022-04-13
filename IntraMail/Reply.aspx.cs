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
    public partial class Reply : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public Reply()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnDraft_Click(object sender, EventArgs e)
        {
            try
            {
                lblDisp.Text = "";
                string InboxId = Session["InboxId"].ToString();
                string MailFromm = Session["MailFrom"].ToString();


                DataSet dataSet = globalClass.GetInboxMails(InboxId);

                string UserId, MailTo, MailFrom, DateOfTran, Sub, Matter;
                UserId = dataSet.Tables["dt"].Rows[0]["UserId"].ToString();
                MailTo = Session["uname"].ToString();
                MailFrom = dataSet.Tables["dt"].Rows[0]["MailFrom"].ToString();
                DateOfTran = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                Sub = txtSubject.Text;
                Matter = txtMatter.Text;

                string strsql = "insert into Draft values(" + UserId + ",'" + MailTo + "','" + MailFrom + "', '" + DateOfTran + "','" + Sub + "', '" + Matter + "')";
                if (globalClass.DraftMail(strsql))
                {
                    lblDisp.Text = "Saved as draft";
                    txtMatter.Text = "";
                    txtSubject.Text = "";
                }
                else
                {
                    lblDisp.Text = "Not saved in draft";
                    txtMatter.Text = "";
                    txtSubject.Text = "";
                }
            }
            catch (Exception ex)
            {

                lblDisp.Text = ex.Message;
            }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            lblDisp.Text = "";
            try
            {
                string InboxId = Session["InboxId"].ToString();
                string MailFromm = Session["MailFrom"].ToString();


                DataSet dataSet = globalClass.GetInboxMails(InboxId);

                string UserId, MailTo, MailFrom, DateOfTran, Sub, Matter;
                UserId = dataSet.Tables["dt"].Rows[0]["UserId"].ToString();
                MailFrom = Session["uname"].ToString();
                MailTo = dataSet.Tables["dt"].Rows[0]["MailFrom"].ToString();
                DateOfTran = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                Sub = txtSubject.Text;
                Matter = txtMatter.Text;

                if (globalClass.ComposeMail(MailFrom, MailTo, DateOfTran, Sub, Matter))
                    {
                        lblDisp.Text = "Mail has been Sent";
                        txtMatter.Text = "";
                        txtSubject.Text = "";

                    }
                    else
                    {
                        lblDisp.Text = "Not sent";
                        txtMatter.Text = "";
                        txtSubject.Text = "";
                }
              
            }
            catch (Exception ex)
            {
                lblDisp.Text = ex.Message;
            }
        }
    }
}