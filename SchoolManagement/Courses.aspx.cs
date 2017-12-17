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
public partial class Courses : System.Web.UI.Page
{
    public string schoolidtxtValue = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string schoolid = Convert.ToString(Session["schoolid"]);
        schoolidtxtValue = schoolid;
        DAL obj = new DAL();
        DAL obj1 = new DAL();
        DataSet ds1 = obj.getStrm(schoolid);
        DropDownList1.DataSource = ds1.Tables[0];
        DropDownList1.DataTextField = "strm";
        DropDownList1.DataValueField = "strm";
        DropDownList1.DataBind();

        DataSet ds=new DataSet();
        ds.Clear();
        ds= obj1.getCourses(schoolid);
        StringBuilder sb = new StringBuilder();
        DataTable dt = new DataTable();
        dt.Clear();
         dt=ds.Tables[0];
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
                    sb.Append((dr["strm"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["seats"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["enrollments"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["cost"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["status"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["created_at"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='#' class='btn btn-warning btn-xs courseupdatecls' data-toggle='modal' data-target='#courseupdateModel' style='text-decoration:none'>Update</a>");
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='#' class='btn btn-danger btn-xs coursedeleteecls' data-toggle='modal' data-target='#coursedeleteModal' style='text-decoration:none'>Delete</a>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }

    [WebMethod]
    public static string addCourse(string cname, string term,int seats,string cost, string schoolid)
    {
        
        DAL obj = new DAL();
        int result = obj.addCourse(cname, term,seats, cost,schoolid);
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
    public static string updateCourse(string cname, int seats, string cost, string courseid)
    {
        DAL obj = new DAL();
        int result = obj.updateCourse(cname, seats,cost, courseid);
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
     public static string deleteCourse(string courseid)
    {
        DAL obj = new DAL();
        int result = obj.deleteCourse(courseid);
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

