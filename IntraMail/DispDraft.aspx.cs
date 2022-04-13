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
    public partial class DispDraft : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public DispDraft()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDisp.Text = "";
            string DraftId = Request.QueryString["DraftId"];
            if (Session["uname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (DraftId != null)
            {
                DataSet dataSet = globalClass.ShowDraft(DraftId);
                txtMailTo.Text = dataSet.Tables["dt"].Rows[0]["MailTo"].ToString();
                txtSubject.Text = dataSet.Tables["dt"].Rows[0]["Sub"].ToString();
                txtMatter.Text = dataSet.Tables["dt"].Rows[0]["Matter"].ToString();

            }
            else
            {
                lblDisp.Text = "Not Drafted";

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            lblDisp.Text = "";
            try
            {
                if (!globalClass.CheckWhileRegister(txtMailTo.Text))
                {
                    string DraftId = Request.QueryString["DraftId"];
                    if (globalClass.DraftMail(Session["uname"].ToString(), txtMailTo.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), txtSubject.Text, txtMatter.Text, DraftId))
                    {
                        lblDisp.Text = "Mail has been Sent";
                        txtMailTo.Text = "";
                        txtMatter.Text = "";
                        txtSubject.Text = "";
                        
                    }
                    else
                    {
                        lblDisp.Text = "Not sent";
                        txtMailTo.Text = "";
                        txtMatter.Text = "";
                        txtSubject.Text = "";
                    }
                }
                else
                {
                    lblDisp.Text = "Mail id not exists";
                    txtMailTo.Text = "";
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