using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class AssignGrades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Convert.ToString(Session["username"]);
        DataSet ds = new DataSet();
        DAL obj = new DAL();
        string schoolid = Convert.ToString(Session["schoolid"]);
        if (!IsPostBack)
        {
            ds = obj.getAvailableterms(schoolid);

            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "strm";
            DropDownList1.DataValueField = "strm";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select Semester--", "0"));
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = Convert.ToString(Session["username"]);
        string strm = DropDownList1.SelectedValue;
        DAL obj2 = new DAL();

        DataSet ds2 = obj2.getTeacherCourses(username,strm);
       
        tabledisplay.Visible = true;
       
        StringBuilder sb = new StringBuilder();
        DataTable dt = ds2.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append((dr["courseid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["coursename"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["enrollments"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["strm"]));
                    sb.Append("</td>");                    
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='AddGrade.aspx?courseid=" + dr["courseid"].ToString() + "' class='btn btn-success btn-md' style='text-decoration:none'>Select</a>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }
}