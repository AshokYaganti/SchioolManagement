using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["schoolConnection"].ConnectionString);
    DataSet ds = new DataSet();

    public DataSet getUsename()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_username", con);
        cmd.CommandText = "sp_username";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public int registrationDetails(string dname, string username, string password, string emailid, string phone, string sname, string saddress, string state, string city, string zip)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_schoolreg", con);
        cmd.CommandText = "sp_schoolreg";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@schoolid", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.AddWithValue("@dname", dname);       
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@email", emailid);
        cmd.Parameters.AddWithValue("@role", "D");
        cmd.Parameters.AddWithValue("@phone", phone);
        cmd.Parameters.AddWithValue("@sname", sname);
        cmd.Parameters.AddWithValue("@saddress", saddress);
        cmd.Parameters.AddWithValue("@state", state);
        cmd.Parameters.AddWithValue("@city", city);
        cmd.Parameters.AddWithValue("@zip", zip);        
        cmd.ExecuteNonQuery();
        string schoolid = cmd.Parameters["@schoolid"].Value.ToString();
        int schoolid1 = Convert.ToInt32(schoolid);
        con.Close();
        return schoolid1;

    }

    public DataSet getLoginDetails(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_logindetails", con);
        cmd.CommandText = "sp_logindetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public int termDetails(string strm, string sdate, string edate, string schoolid)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_term", con);
        cmd.CommandText = "sp_term";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@strm", strm);
        cmd.Parameters.AddWithValue("@sdate", sdate);
        cmd.Parameters.AddWithValue("@edate", edate);
        cmd.Parameters.AddWithValue("@schoolid", schoolid);
     
        int result=cmd.ExecuteNonQuery();       
        con.Close();
        return result;
    }

    public DataSet getStrm(string schoolid)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getstrm", con);
        cmd.CommandText = "sp_getstrm";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@schoolid", schoolid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }
    public DataSet getTermDetails(string schoolid)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_gettermdetails", con);
        cmd.CommandText = "sp_gettermdetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@schoolid", schoolid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getSchoolDetails(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_schooldetails", con);
        cmd.CommandText = "sp_schooldetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

   public DataSet getTeacherDetails(string schoolid)
   {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getteacherdetails", con);
        cmd.CommandText = "sp_getteacherdetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@schoolid", schoolid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
   }

   public int addTeacher(string tname, string email, string schoolid,string password)
   {
       con.Open();

       SqlCommand cmd = new SqlCommand("sp_addteacher", con);
       cmd.CommandText = "sp_addteacher";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add("@teacherid", SqlDbType.Int).Direction = ParameterDirection.Output;
       cmd.Parameters.AddWithValue("@schoolid", schoolid);      
       cmd.Parameters.AddWithValue("@password", password);
       cmd.Parameters.AddWithValue("@name", tname);
       cmd.Parameters.AddWithValue("@role", "T");
       cmd.Parameters.AddWithValue("@email", email);
       cmd.Parameters.AddWithValue("@status", "ACTIVE");       
       cmd.ExecuteNonQuery();
       string teacherid = cmd.Parameters["@teacherid"].Value.ToString();
       int teacherid1 = Convert.ToInt32(teacherid);
       con.Close();
       return teacherid1;
   }

   public int updateTeacher(string tname, string email, string schoolid, string teacherid)
   {
       con.Open();

       SqlCommand cmd = new SqlCommand("sp_updateteacher", con);
       cmd.CommandText = "sp_updateteacher";
       cmd.CommandType = CommandType.StoredProcedure;      
       cmd.Parameters.AddWithValue("@schoolid", schoolid);
       cmd.Parameters.AddWithValue("@teacherid", teacherid);
       cmd.Parameters.AddWithValue("@name", tname);      
       cmd.Parameters.AddWithValue("@email", email);      
       int res=cmd.ExecuteNonQuery();           
       con.Close();
       return res;
   }

   public int deleteTeacher(string schoolid, string teacherid)
   {
       con.Open();

       SqlCommand cmd = new SqlCommand("sp_deleteteacher", con);
       cmd.CommandText = "sp_deleteteacher";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@schoolid", schoolid);
       cmd.Parameters.AddWithValue("@teacherid", teacherid);      
       int res = cmd.ExecuteNonQuery();
       con.Close();
       return res;
   }

   public DataSet getCourses(string schoolid)
   {
       con.Open();
       SqlCommand cmd = new SqlCommand("sp_getCourses", con);
       cmd.CommandText = "sp_getCourses";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@schoolid", schoolid);
       SqlDataAdapter da = new SqlDataAdapter(cmd);
       da.Fill(ds);
       con.Close();
       return ds;
   }

   public int addCourse(string cname, string term,int seats,string cost, string schoolid)
   {
       con.Open();

       SqlCommand cmd = new SqlCommand("sp_addcourse", con);
       cmd.CommandText = "sp_addcourse";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add("@courseid", SqlDbType.Int).Direction = ParameterDirection.Output;
       cmd.Parameters.AddWithValue("@coursename", cname);
       cmd.Parameters.AddWithValue("@strm", term);
       cmd.Parameters.AddWithValue("@seats", seats);
       cmd.Parameters.AddWithValue("@cost", cost);
       cmd.Parameters.AddWithValue("@status", "ACTIVE");
       cmd.Parameters.AddWithValue("@schoolid", schoolid);       
       cmd.ExecuteNonQuery();
       string courseid = cmd.Parameters["@courseid"].Value.ToString();
       int courseid1 = Convert.ToInt32(courseid);
       con.Close();
       return courseid1;
   }

   public int updateCourse(string cname, int seats,string cost, string courseid)
   {
       con.Open();

       SqlCommand cmd = new SqlCommand("sp_updatecourse", con);
       cmd.CommandText = "sp_updatecourse";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@courseid", courseid);
       cmd.Parameters.AddWithValue("@coursename", cname);
       cmd.Parameters.AddWithValue("@seats", seats);
       cmd.Parameters.AddWithValue("@cost", cost);   
       int res = cmd.ExecuteNonQuery();
       con.Close();
       return res;
   }

   public int deleteCourse(string courseid)
   {
       con.Open();

       SqlCommand cmd = new SqlCommand("sp_deletecourse", con);
       cmd.CommandText = "sp_deletecourse";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@courseid", courseid);      
       int res = cmd.ExecuteNonQuery();
       con.Close();
       return res;
   }

   public DataSet getCoursesByTerm(string strm, string schoolid)
   {
       con.Open();
       SqlCommand cmd = new SqlCommand("sp_getcoursesbyterm", con);
       cmd.CommandText = "sp_getcoursesbyterm";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@strm", strm);
       cmd.Parameters.AddWithValue("@schoolid", schoolid);
       SqlDataAdapter da = new SqlDataAdapter(cmd);
       da.Fill(ds);
       con.Close();
       return ds;
   }

   public int assignTeacher(string teacherid, string strm, string courseid, string schoolid)
   {
       con.Open();

       SqlCommand cmd = new SqlCommand("sp_assignteacher", con);
       cmd.CommandText = "sp_assignteacher";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@teacherid", teacherid);
       cmd.Parameters.AddWithValue("@strm", strm);
       cmd.Parameters.AddWithValue("@courseid", courseid);
       cmd.Parameters.AddWithValue("@schoolid", schoolid);      
       int res= cmd.ExecuteNonQuery();     
       con.Close();
       return res;
   }

   public DataSet getAssignedTeachers(string schoolid)
   {
       con.Open();
       SqlCommand cmd = new SqlCommand("sp_getassignedteachers", con);
       cmd.CommandText = "sp_getassignedteachers";
       cmd.CommandType = CommandType.StoredProcedure;     
       cmd.Parameters.AddWithValue("@schoolid", schoolid);
       SqlDataAdapter da = new SqlDataAdapter(cmd);
       da.Fill(ds);
       con.Close();
       return ds;
   }

   public int studentApplication(string name, string username, string password, string emailid, string phone, string address, string state, string city, string zip, string schoolid, string strm)
   {
       con.Open();

       SqlCommand cmd = new SqlCommand("sp_studentapplication", con);
       cmd.CommandText = "sp_studentapplication";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add("@applicationid ", SqlDbType.Int).Direction = ParameterDirection.Output;      
       cmd.Parameters.AddWithValue("@username", username);
       cmd.Parameters.AddWithValue("@name", name);
       cmd.Parameters.AddWithValue("@password", password);
       cmd.Parameters.AddWithValue("@email", emailid);       
       cmd.Parameters.AddWithValue("@phone", phone);       
       cmd.Parameters.AddWithValue("@address", address);
       cmd.Parameters.AddWithValue("@state", state);
       cmd.Parameters.AddWithValue("@city", city);
       cmd.Parameters.AddWithValue("@zip", zip);
       cmd.Parameters.AddWithValue("@schoolid", schoolid);
       cmd.Parameters.AddWithValue("@term", strm);
       cmd.ExecuteNonQuery();
       //string applicationid = cmd.Parameters["@applicationid"].Value.ToString();
       //int applicationid1 = Convert.ToInt32(applicationid);
       con.Close();
       return 1;
   }

   public DataSet getschoolNames()
   {
       con.Open();
       SqlCommand cmd = new SqlCommand("sp_getschoolnames", con);
       cmd.CommandText = "sp_getschoolnames";
       cmd.CommandType = CommandType.StoredProcedure;     
       SqlDataAdapter da = new SqlDataAdapter(cmd);
       da.Fill(ds);
       con.Close();
       return ds;
   }

   public DataSet getStudentApplications(string schoolid)
   {
       con.Open();
       SqlCommand cmd = new SqlCommand("sp_getstudentapplications", con);
       cmd.CommandText = "sp_getstudentapplications";
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@schoolid", schoolid);
       SqlDataAdapter da = new SqlDataAdapter(cmd);
       da.Fill(ds);
       con.Close();
       return ds;
   }

    public int approveApplication(string applicationid)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_approveapplication", con);
        cmd.CommandText = "sp_approveapplication";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@applicationid", applicationid);       
        int res = cmd.ExecuteNonQuery();
        con.Close();
        return res;
    }

    public int rejectApplication(string applicationid)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_rejectapplication", con);
        cmd.CommandText = "sp_rejectapplication";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@applicationid", applicationid);
        int res = cmd.ExecuteNonQuery();
        con.Close();
        return res;
    }

    public DataSet getCourseAssignedTeacherDetails(string teacherid)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getCourseassignedteachers", con);
        cmd.CommandText = "sp_getCourseassignedteachers";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@teacherid", teacherid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getStrmbyStudent(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getstrmbystudent", con);
        cmd.CommandText = "sp_getstrmbystudent";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getSearchCourses(string strm, string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getsearchedcourses", con);
        cmd.CommandText = "sp_getsearchedcourses";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@strm", strm);
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public int enrollment(string username, string courseid, string teacherid, string amount)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_enrollments", con);
        cmd.CommandText = "sp_enrollments";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@enrollmentid", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@courseid", courseid);
        cmd.Parameters.AddWithValue("@teacherid", teacherid);
        cmd.Parameters.AddWithValue("@amount", amount);       
        cmd.ExecuteNonQuery();
        string enrollmentid = cmd.Parameters["@enrollmentid"].Value.ToString();
        int enrollmentid1 = Convert.ToInt32(enrollmentid);
        con.Close();
        return enrollmentid1;
    }

    public DataSet getEnrolledCourseids(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getenrolledcourseids", con);
        cmd.CommandText = "sp_getenrolledcourseids";
        cmd.CommandType = CommandType.StoredProcedure;      
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getEnrolledCourses(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getenrolledcourses", con);
        cmd.CommandText = "sp_getenrolledcourses";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public int dropCourse(string eid, string cid)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_dropcourse", con);
        cmd.CommandText = "sp_dropcourse";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@eid", eid);
        cmd.Parameters.AddWithValue("@cid", cid);
        int res = cmd.ExecuteNonQuery();
        con.Close();
        return res;
    }

    public DataSet getStudentPayHistory(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_studentpayhistory", con);
        cmd.CommandText = "sp_studentpayhistory";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getEnrolledStudents(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_enrolledstudents", con);
        cmd.CommandText = "sp_enrolledstudents";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@teacherid", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public int changePassword(string teacherid, string password)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_chagepassword", con);
        cmd.CommandText = "sp_chagepassword";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@teacherid", teacherid);
        cmd.Parameters.AddWithValue("@password", password);
        int res = cmd.ExecuteNonQuery();
        con.Close();
        return res;
    }

    public DataSet studentPayments(string schoolid)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_studentpayments", con);
        cmd.CommandText = "sp_studentpayments";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@schoolid", schoolid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getSchoolDetailsbyTeacher(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_schooldetailsbyteacher", con);
        cmd.CommandText = "sp_schooldetailsbyteacher";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getAvailableterms(string schoolid)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getavailableterms", con);
        cmd.CommandText = "sp_getavailableterms";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@schoolid", schoolid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getTeacherCourses(string username, string strm)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getteacherCourses", con);
        cmd.CommandText = "sp_getteacherCourses";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@strm", strm);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet getStudents(string courseid, string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getstudents", con);
        cmd.CommandText = "sp_getstudents";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@courseid", courseid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public int addGrade(string eid, string grade)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_addgrade", con);
        cmd.CommandText = "sp_addgrade";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@eid", eid);
        cmd.Parameters.AddWithValue("@grade", grade);
        int res = cmd.ExecuteNonQuery();
        con.Close();
        return res;
    }

    public DataSet getTeacherIDs(string schoolid)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getteacherids", con);
        cmd.CommandText = "sp_getteacherids";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@schoolid", schoolid);       
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

}