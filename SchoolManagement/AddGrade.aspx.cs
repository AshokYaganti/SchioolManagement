using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Services;
public partial class AddGrade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string courseid = Request.QueryString["courseid"];
        string username = Convert.ToString(Session["username"]);
        DAL obj=new DAL();
        DataSet ds = obj.getStudents(courseid,username);

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
                    sb.Append((dr["name"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["email"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["grade"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='#' class='btn btn-success btn-md addgrade' data-toggle='modal' data-target='#addModal' data-eid=" + dr["enrollmentid"].ToString() + " style='text-decoration:none'>Add/Edit Grade</a>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }

    [WebMethod]
    public static string assignStudentGrade(string eid, string grade)
    {
        DAL obj = new DAL();
        int result = obj.addGrade(eid, grade);
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