<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="TeacherHome.aspx.cs" Inherits="TeacherHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

<div class="ibox-title">
        <h5>
            <strong>Teacher Assigned Courses</strong></h5>           
          <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="assignedCourses">
                <thead>
                    <tr>
                        <th>
                            Teacher ID
                        </th>
                        <th>
                            Teacher Name
                        </th>
                        <th>
                            Course ID
                        </th> 
                        <th>
                            Course Name
                        </th> 
                        <th>
                           Semester
                        </th> 
                        <th>
                            Total Seats
                        </th> 
                          <th>
                            Total Enrollements
                        </th>                          
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal runat="server" ID="ltData"></asp:Literal>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>

