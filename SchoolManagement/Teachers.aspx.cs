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
public partial class Teachers : System.Web.UI.Page
{
     public string schoolidtxtValue = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string schoolid = Convert.ToString(Session["schoolid"]);

        DAL obj3 = new DAL();
        DataSet ds12 = obj3.getTeacherIDs(schoolid);

        List<string> teacherids = new List<string>();

        for (int i = 0; i < ds12.Tables[0].Rows.Count; i++)
        {
            teacherids.Add(ds12.Tables[0].Rows[i][0].ToString());
        }


        schoolidtxtValue = schoolid;
        DAL obj = new DAL();
        DataSet ds = obj.getTeacherDetails(schoolid);
        StringBuilder sb = new StringBuilder();
        DataTable dt = ds.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append((dr["teacherid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["name"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["email"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["created_at"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='#' class='btn btn-warning btn-xs updatecls' data-toggle='modal' data-target='#updateModel' style='text-decoration:none'>Update</a>");
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    if (teacherids.Contains(dr["teacherid"].ToString()))
                    {
                        sb.Append("<a href='#' class='btn btn-primary btn-xs' style='text-decoration:none'>Assigned to Course</a>");
                    }
                    else
                    {
                        sb.Append("<a href='#' class='btn btn-danger btn-xs deletecls' data-toggle='modal' data-target='#deleteModal' style='text-decoration:none'>Delete</a>");
                    }
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }

    [WebMethod]
    public static string addTeacher(string tname, string email, string schoolid)
    {
       string password = tname.Substring(0, 1) + tname.Substring(tname.Length - 1) + schoolid.Substring(schoolid.Length - 3);
        DAL obj = new DAL();
       int result = obj.addTeacher(tname,email,schoolid,password);
       string msg = string.Empty;
       if (result > 0)
       {
            msg = "success";
             string to123 = email;
             string from123 = "developertest109@gmail.com";
                string subject = "School Management System account";
           string body = "Your account has been created. Please use ID and Password to login. ID:"+result+" , " + "Password:"+password;
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
    public static string updateTeacher(string tname, string email, string schoolid, string teacherid)
    {
        DAL obj = new DAL();
        int result = obj.updateTeacher(tname, email, schoolid, teacherid);
        string msg = string.Empty;
        if (result > 0)
        {
            msg = "success";
      
        }
        else
        {
            msg = "failure";
        }
        return msg;
    }

    [WebMethod]
    public static string deleteTeacher(string schoolid, string teacherid)
    {
        DAL obj = new DAL();
        int result = obj.deleteTeacher(schoolid, teacherid);
        string msg = string.Empty;
        if (result > 0)
        {
            msg = "success";

        }
        else
        {
            msg = "failure";
        }
        return msg;
    }
}
 
