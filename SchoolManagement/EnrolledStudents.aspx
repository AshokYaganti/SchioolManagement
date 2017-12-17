<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="EnrolledStudents.aspx.cs" Inherits="EnrolledStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

       <div class="ibox-title">
       <h5> <strong>Student Enrollments</strong></h5>           
          <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="studentenrollments">
                <thead>
                    <tr>
                        <th>
                            Student ID
                        </th>
                        <th>
                            Student Name
                        </th>
                        <th>
                            Student Email
                        </th>
                        <th>
                            Student Phone
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
                                               
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal runat="server" ID="ltData"></asp:Literal>
                </tbody>
            </table>
        </div>
    </div>



</asp:Content>

