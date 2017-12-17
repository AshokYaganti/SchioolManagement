using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class StudentHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Convert.ToString(Session["username"]);
        DataSet ds = new DataSet();
        DAL obj = new DAL();
        if (!IsPostBack)
        {
            ds = obj.getStrmbyStudent(username);

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
         DAL obj2 = new DAL();

        DataSet ds2 = obj2.getEnrolledCourseids(username);

        List<string> courseids = new List<string>();       

        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            courseids.Add(ds2.Tables[0].Rows[i][0].ToString());
        }



        tabledisplay.Visible = true;
        string strm = DropDownList1.SelectedValue;
       
        DataSet ds1 = new DataSet();
        DAL obj1 = new DAL();
        ds1 = obj1.getSearchCourses(strm,username);       
        StringBuilder sb = new StringBuilder();
        DataTable dt = ds1.Tables[0];
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
                    sb.Append("<td>");
                    sb.Append((dr["teacherid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["name"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["cost"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["seats"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["enrollments"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    if (courseids.Contains(dr["courseid"].ToString()))
                    {
                        sb.Append("<a href='#' class='btn btn-primary btn-xs' style='text-decoration:none'>Already Enrolled</a>");
                    }
                    else
                    {
                        sb.Append("<a href='Enroll.aspx?courseid=" + dr["courseid"].ToString() + "&teacherid=" + dr["teacherid"].ToString() + "&amount=" + dr["cost"].ToString() + "' class='btn btn-success btn-md courseucls' style='text-decoration:none'>Enroll</a>");
                    }
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }
}