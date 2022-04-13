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
    public partial class DispTrash : System.Web.UI.Page
    {
        GlobalClass globalClass;
        public DispTrash()
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

                
                string TrashId = Request.QueryString["TrashId"];

                DataSet dataSet = globalClass.ShowTrashMails(Session["uname"].ToString(), TrashId);
                gridDispTrash.DataSource = dataSet.Tables["dt"];
                gridDispTrash.Visible = true;
                gridDispTrash.DataBind();
                if (dataSet.Tables[0].Rows.Count == 0)
                    lbl.Text = "Trash is empty";
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