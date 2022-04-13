using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace IntraMail.DatabaseOperations
{
    public class GlobalClass
    {
        public static DataSet dset;

        //Opening connection with DB and return SqlCommand obj
        public SqlCommand OpenConnection(string strsql)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["cnstr"]);
            sqlConnection.Open();

            //checking connection to open
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Closed)
            {
                throw new Exception("Not connecting to database");
            }

            SqlCommand sqlCommand = new SqlCommand(strsql, sqlConnection);

            return sqlCommand;
        }

        //ExecuteNonQuery for insert, update, delete operation- OR- want no data 
        private bool RunNonQuery(string strsql)
        {
            SqlCommand sqlCommand = OpenConnection(strsql);
            int result = sqlCommand.ExecuteNonQuery(); //returns zero is not executed successfully

            if (result == 0)
                return false;
            else
                return true;
        }
        //Register- date in -YYYY-MM-DD
        public bool Register(string FirstName, string LastName, string UserName, string Pwd, string Dob, string Mobile, string AddressLocal, string SecurityQuestion, string SecurityAnswer)
        {
            int index = SecurityQuestion.IndexOf("?");
            string secQue = SecurityQuestion.Substring(0, index);
            string strsql = "insert into Registration values('" + FirstName + "', '" + LastName + "', '" + UserName + "', '" + Pwd + "', '" + Dob + "', '" + Mobile + "', '" + AddressLocal + "', '" + secQue + "','" + SecurityAnswer + "')";

            bool b = RunNonQuery(strsql);
            return b;
        }

        //Check already registered user
        public bool CheckWhileRegister(string userName)
        {
            bool flag = true;
            string strsql = "select * from Registration";
            SqlCommand cmd = OpenConnection(strsql);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                if (da[3].ToString() == userName)
                    flag = false;
            }
            return flag;
        }

        //function to check user login
        public bool CheckGmailLogin(string uname, string pass)
        {
            string sqlstr = "select * from Registration where UserName='" + uname + "'and Pwd='" + pass + "'";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            bool loginStatus = false;

            if (sqlDataReader.Read())
            {
                loginStatus = true;
            }

            return loginStatus;
        }

        //get user id from registration
        public string GetUserId(string uname)
        {
            string userId = "";
            string strsql = "select UserId from Registration where UserName='" + uname + "'";
            SqlCommand cmd = OpenConnection(strsql);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                userId = da[0].ToString();
            }
            return userId;
        }

        public bool ComposeMail(string uName, string mailTo, string date, string sub, string matter)
        {
            int userid = int.Parse(GetUserId(uName));
            int userid1 = int.Parse(GetUserId(mailTo));
            string strsql = "insert into Inbox values(" + userid + ",'" + uName + "','" + mailTo + "', '" + date + "', '" + sub + "','" + matter + "')"; //inbox 
            string strsql1 = "insert into SentMail values(" + userid1 + ",'" + uName + "', '" + date + "','" + sub + "','" + matter + "')"; //sent mail
            bool b1 = RunNonQuery(strsql1);
            bool b = RunNonQuery(strsql);

            if (b1 == true && b == true)
                return true;

            return false;

        }

        //draft
        public bool DraftMail(string uName, string mailTo, string date, string sub, string matter, string DraftId)
        {
            int userid = int.Parse(GetUserId(uName));
            int userid1 = int.Parse(GetUserId(mailTo));
            string strsql = "insert into Inbox values(" + userid + ",'" + uName + "','" + mailTo + "', '" + date + "', '" + sub + "','" + matter + "')"; //inbox 
            string strsql1 = "insert into SentMail values(" + userid1 + ",'" + uName + "', '" + date + "','" + sub + "','" + matter + "')"; //sent mail
            string strsql2 = "delete from Draft where DraftId='" + DraftId + "'";
            bool b1 = RunNonQuery(strsql1);
            bool b = RunNonQuery(strsql);
            bool b2= RunNonQuery(strsql2);

            if (b1 == true && b == true && b2==true)
                return true;

            return false;

        }


        //function to fill data for grid
        private DataSet FillDataInTable(SqlCommand sqlCommand)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataSet, "dt");
            return dataSet;
        }

        private DataSet FillDataInTable1(SqlCommand sqlCommand)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataSet, "dt");
            return dataSet;
        }

        //showing to sent mail
        public DataSet ShowSentMail(string username)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            int userid = UserId(username);
            sqlstr = "select MailTo, DateOfTran, Sub, Matter,InboxId from Inbox where UserId=" + userid + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }

        //get sent mail info to add it into trash//showing to sent mail
        public DataSet GetSentMails(string InboxId)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = "select * from Inbox where InboxId="+ InboxId + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }

        //get inbox mail info to add it into trash
        public DataSet GetInboxMails(string InboxId)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = "select * from SentMail where InboxId=" + InboxId + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }

        //get inbox mail info to add it into trash
        public DataSet GetDraftMails(string DraftId)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = "select * from Draft where DraftId=" + DraftId + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }

        //showing to draft mail
        public DataSet ShowDrafttMail(string username)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            int userid = UserId(username);
            sqlstr = "select Sub, DraftId, DateOfTran from Draft where UserId=" + userid + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }


        //showing to draft mail
        public DataSet ShowDraft(string draftid)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            sqlstr = "select MailTo, Sub, Matter from Draft where DraftId="+ draftid + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }

        //showing to trash mail
        public DataSet ShowTrashtMail(string username)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            int userid = UserId(username);
            sqlstr = "select Sub, TrashId, DateOfTran from Trash where UserId="+ userid + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }


        //showing to inbox mail
        public DataSet ShowInboxMail(string username)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            int userid = UserId(username);
            //sqlstr = "select MailFrom, DateOfTran, Sub, Matter from SentMail where UserId=" + userid + "";
            sqlstr = "select * from SentMail where UserId=" + userid + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }

        //showing to inbox mails
        public DataSet ShowInboxMails(string subject, string username, string date)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            int userid = UserId(username);
            sqlstr = "select MailFrom, DateOfTran, Sub, Matter from SentMail where Sub='" + subject + "' and UserId=" + userid + " and DateOfTran='"+ date + "'";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }

        //showing to sent mails
        public DataSet ShowSentMails(string subject, string username, string date)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            int userid = UserId(username);
            sqlstr = "select MailTo, DateOfTran, Sub, Matter from Inbox where Sub='" + subject + "' and UserId=" + userid + "and DateOfTran='" + date + "'";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable1(sqlCommand);
            return dataSet;
        }

        //showing to sent mails
        public DataSet ShowTrashMails(string username, string TrashId)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            int userid = UserId(username);
            sqlstr = "select MailTo, DateOfTran, Sub, Matter from Trash where TrashId="+ TrashId + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable1(sqlCommand);
            return dataSet;
        }

        //get user id
        public int UserId(string username)
        {
            int userid = 0;
            string sqlstr = "select UserId from Registration where UserName='" + username + "'";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                userid = int.Parse(dataReader[0].ToString());
            }

            return userid;
        }

        //fetch security question
        public string GetSecurityQue(string username)
        {
            string securityQue = "";
            string sqlstr = "select SecurityQuestion from Registration where UserName='" + username + "'";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                securityQue = dataReader[0].ToString();
            }

            return securityQue;

        }

        //forget password
        public bool ForgetPass(string username, string pass, string securityQue)
        {
            string sqlstr = "update Registration set Pwd='" + pass + "' where username='" + username + "' and SecurityQuestion='" + securityQue + "'";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            bool b = RunNonQuery(sqlstr);
            return b;
        }

        //Check already exist user
        public bool CheckUser(string username)
        {
            string strsql = "select UserName from Registration";
            SqlCommand cmd = OpenConnection(strsql);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                return true;
            }
            return false;
        }

        //check security ans
        public bool CheckSecAnw(string ans, string que, string uname)
        {
            bool status = false;
            string strsql = "select SecurityAnswer from Registration where username='" + uname + "' and SecurityQuestion='" + que + "'";
            SqlCommand cmd = OpenConnection(strsql);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                if (da[0].ToString() == ans)
                    status = true;
                else
                    status = false;

            }
            return status;
        }


        //get grid data for forwading data 
        public bool GetGridData(string loginuser,string date, string uname, string sub)
        {
            string matter="";

            int userid = int.Parse(GetUserId(uname));
            int userid1= int.Parse(GetUserId(loginuser));

            string strsql = "select * from SentMail where UserId="+ userid1 + " and Sub='"+ sub + "'";
            SqlCommand cmd = OpenConnection(strsql);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                matter = dr[4].ToString();
            }

            string strsql2 = "insert into Inbox values(" + userid + ",'" + loginuser + "','" + uname + "', '" + date + "', '" + sub + "','" + matter + "')"; //inbox 
            bool b = RunNonQuery(strsql2);

            string strsql1 = "insert into SentMail values(" + userid + ",'" + uname + "', '" + date + "','" + sub + "','" + matter + "')"; //sent mail
            bool b1 = RunNonQuery(strsql1);                                                                                                                      //    bool b1 = RunNonQuery(strsql1);

            if (b == true && b1==true)
                return true;

            return false;
        }

        //get fname and lname for welcome string

        public string GetWelcomeName(string username)
        {
            string name = "";
            string strsql = "select FirstName, LastName from Registration where UserName='" + username + "'";
            SqlCommand cmd = OpenConnection(strsql);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                name = "Welcome" + " " + dr[0] + " " + dr[1];
            }
            return name;
        }

        //delete grid row
        public bool DeleteRow( String strsql)
        {
            SqlCommand cmd = OpenConnection(strsql);
            bool b = RunNonQuery(strsql);
            return b;

        }

        //draft mail
        public bool DraftMail(string strsql)
        {
            SqlCommand cmd = OpenConnection(strsql);
            bool b = RunNonQuery(strsql);
            return b;
        }

        //showing to draft mails
        public DataSet ShowDraftMail(string username)
        {
            DataSet dataSet = new DataSet();
            string sqlstr = null;
            int userid = UserId(username);
            //sqlstr = "select MailFrom, DateOfTran, Sub, Matter from SentMail where UserId=" + userid + "";
            sqlstr = "select * from Draft where UserId=" + userid + "";
            SqlCommand sqlCommand = OpenConnection(sqlstr);
            dataSet = FillDataInTable(sqlCommand);
            return dataSet;
        }



    }
}