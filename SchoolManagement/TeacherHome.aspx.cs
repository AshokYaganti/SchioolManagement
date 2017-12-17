using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class TeacherHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string teacherid = Convert.ToString(Session["username"]);        
        DAL obj = new DAL();
        DataSet ds = obj.getCourseAssignedTeacherDetails(teacherid);
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
                    sb.Append((dr["courseid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["coursename"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["strm"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["seats"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["enrollments"]));
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }
}