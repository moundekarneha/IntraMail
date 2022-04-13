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
    public partial class Draft : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public Draft()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string DraftId = Request.QueryString["DraftId"];
            if (Session["uname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (DraftId != null)
            {
                String strlSql = "delete from Draft where DraftId='" + DraftId + "'";

                DataSet dataSet = globalClass.GetDraftMails(DraftId);
                string UserId, MailTo, MailFrom, DateOfTran, Sub, Matter;
                UserId = dataSet.Tables["dt"].Rows[0]["UserId"].ToString();
                MailTo = dataSet.Tables["dt"].Rows[0]["MailTo"].ToString();
                MailFrom = dataSet.Tables["dt"].Rows[0]["MailFrom"].ToString();
                DateOfTran = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                Sub = dataSet.Tables["dt"].Rows[0]["Sub"].ToString();
                Matter = dataSet.Tables["dt"].Rows[0]["Matter"].ToString();

                string strSql1 = "insert into Trash values(" + UserId + ",'" + MailTo + "','" + MailFrom + "','" + DateOfTran + "','" + Sub + "', '" + Matter + "')";
                bool b1 = globalClass.DeleteRow(strSql1);//inserting

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
            try
            {
                string welcomeName = globalClass.GetWelcomeName(Session["uname"].ToString());
                lblWelcome.Text = welcomeName;

                DataSet dataSet = globalClass.ShowDrafttMail(Session["uname"].ToString());
                gridDispDraftMail.DataSource = dataSet.Tables["dt"];
                gridDispDraftMail.Visible = true;
                gridDispDraftMail.DataBind();
                if (dataSet.Tables[0].Rows.Count == 0)
                    lbl.Text = "Draft mails are empty";
                else
                    lbl.Text = "Draft Mails";
            }
            catch (Exception ex)
            {
                lblDisp.Text = ex.Message;
            }
            
        }
    }
}