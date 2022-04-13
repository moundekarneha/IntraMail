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
    public partial class Trash : System.Web.UI.Page
    {
        GlobalClass globalClass;

        public Trash()
        {
            globalClass = new GlobalClass();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string TrashId = Request.QueryString["TrashId"];
            if (Session["uname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (TrashId != null)
            {
                String strlSql = "delete from Trash where TrashId='" + TrashId + "'";
                bool b = globalClass.DeleteRow(strlSql);
                if (b)
                {
                    DisplayGrid();
                }

            }
            else
            {
                DisplayGrid();

            }
        }

        //Display on grid 
        private void DisplayGrid()
        {
            try
            {
                string welcomeName = globalClass.GetWelcomeName(Session["uname"].ToString());
                lblWelcome.Text = welcomeName;

                DataSet dataSet = globalClass.ShowTrashtMail(Session["uname"].ToString());
                gridDispTrash.DataSource = dataSet.Tables["dt"];
                gridDispTrash.Visible = true;
                gridDispTrash.DataBind();
                if (dataSet.Tables[0].Rows.Count == 0)
                    lbl.Text = "Trash mails are empty";
                else
                    lbl.Text = "Trash Mails";
            }
            catch (Exception ex)
            {
                lblDisp.Text = ex.Message;
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}