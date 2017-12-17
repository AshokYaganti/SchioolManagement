using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Net;
using System.Net.Mail;
public partial class DirectorHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string schoolid = Convert.ToString(Session["schoolid"]);       
        DAL obj = new DAL();
        DataSet ds = obj.getStudentApplications(schoolid);
        StringBuilder sb = new StringBuilder();
        DataTable dt = ds.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append((dr["applicationid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["username"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["name"]));
                    sb.Append("</td>");                   
                    sb.Append("<td>");
                    sb.Append((dr["term"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["status"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["created_at"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["email"]));
                    sb.Append("<td>");
                    sb.Append((dr["phone"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["address"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["state"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["city"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["zip"]));
                    sb.Append("</td>");
                    if (dr["status"].ToString() == "OPEN")
                    {
                        sb.Append("<td align='center'>");
                        sb.Append("<a href='#' class='btn btn-success btn-xs approvecls' data-toggle='modal' data-target='#approveModal' style='text-decoration:none'>Approve</a>");
                        sb.Append("</td>");
                        sb.Append("<td align='center'>");
                        sb.Append("<a href='#' class='btn btn-danger btn-xs rejectcls' data-toggle='modal' data-target='#rejectModal' style='text-decoration:none'>Reject</a>");
                        sb.Append("</td>");
                    }
                    else
                    {
                        sb.Append("<td>");
                        sb.Append("&nbsp;");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("&nbsp;");
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }


    [WebMethod]
    public static string approveApplication(string applicationid, string email)
    {
        DAL obj1 = new DAL();
        int result = obj1.approveApplication(applicationid);
        string msg = string.Empty;
        if (result > 0)
        {
            msg = "success";

            string to123 = email;
            string from123 = "developertest109@gmail.com";
            string subject = "Application Status:School Management System";
            string body = "Your School has been Approved.You can login and enroll for the courses by using your username and password. Application ID:" + applicationid;
            using (MailMessage mm = new MailMessage(from123, to123))
            {
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(from123, "test@1234");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }

        }
        else
        {
            msg = "failure";
        }
        return msg;
    }

    [WebMethod]
    public static string rejectApplication(string applicationid, string email)
    {
        DAL obj2 = new DAL();
        int result = obj2.rejectApplication(applicationid);
        string msg = string.Empty;
        if (result > 0)
        {
            msg = "success";

            string to123 = email;
            string from123 = "developertest109@gmail.com";
            string subject = "Application Status:School Management System";
            string body = "Your School has been Rejected. Application ID:" + applicationid;
            using (MailMessage mm = new MailMessage(from123, to123))
            {
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(from123, "test@1234");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }

        }
        else
        {
            msg = "failure";
        }
        return msg;
    }
}