using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Services;
public partial class EnrolledCourses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Convert.ToString(Session["username"]);
        DAL obj2 = new DAL();
        DataSet ds1 = new DataSet();
        ds1 = obj2.getEnrolledCourses(username);
        StringBuilder sb = new StringBuilder();
        DataTable dt = ds1.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append((dr["enrollmentid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["courseid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["coursename"]));
                    sb.Append("</td>");                   
                    sb.Append("<td>");
                    sb.Append((dr["name"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["strm"]));
                    sb.Append("</td>");                    
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='#' class='btn btn-danger btn-md dropcls' data-toggle='modal' data-target='#dropModal' style='text-decoration:none'>Drop</a>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }

    [WebMethod]
    public static string dropCourse(string eid, string cid)
    {
        DAL obj = new DAL();
        int result = obj.dropCourse(eid, cid);
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