using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class AssignTeachers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string schoolid = Convert.ToString(Session["schoolid"]);
            DAL obj = new DAL();
            DAL obj1 = new DAL();

            if (!IsPostBack)
            {
                ds = obj.getTeacherDetails(schoolid);
                ds1 = obj1.getStrm(schoolid);


                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "nameid";
                DropDownList1.DataValueField = "teacherid";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("--Select Teacher--", "0"));

                DropDownList3.DataSource = ds1.Tables[0];
                DropDownList3.DataTextField = "strm";
                DropDownList3.DataValueField = "strm";
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, new ListItem("--Select Semester--", "0"));
            }

            DAL obj4 = new DAL();
            DataSet ds4 = obj4.getAssignedTeachers(schoolid);
            StringBuilder sb = new StringBuilder();
            DataTable dt1 = ds4.Tables[0];
            if (dt1 != null)
                if (dt1.Rows.Count > 0)
                    foreach (DataRow dr in dt1.Rows)
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
                        sb.Append(dr["strm"]);
                        sb.Append("</td>");                       
                        sb.Append("</tr>");

                    }

            ltData.Text = sb.ToString();
       


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DAL obj3 = new DAL();
        string teacherid = DropDownList1.SelectedValue;
        string strm = DropDownList3.SelectedValue;
        string courseid = DropDownList4.SelectedValue;
        string schoolid=Convert.ToString(Session["schoolid"]);

        int res = obj3.assignTeacher(teacherid,strm,courseid,schoolid);

        if (res > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Teacher has been assigned to a course');window.location='AssignTeachers.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
            Response.Redirect(ResolveUrl("AssignTeachers.aspx"));
        }



    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds2 = new DataSet();
        DAL obj2 = new DAL();
        string schoolid = Convert.ToString(Session["schoolid"]);
        string strm = DropDownList3.SelectedValue;

        ds2 = obj2.getCoursesByTerm(strm,schoolid);  

        DropDownList4.DataSource = ds2.Tables[0];
        DropDownList4.DataTextField = "coursenameid";
        DropDownList4.DataValueField = "courseid";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("--Select Course--", "0"));       

    }
}