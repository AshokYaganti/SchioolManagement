<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="EnrolledCourses.aspx.cs" Inherits="EnrolledCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

<div class="ibox-title" runat="server" id="tabledisplay">
        <h5>
            <strong>Student Enrolled Courses</strong></h5>
        <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="enrolledcourses">
                <thead>
                    <tr>  
                     <th>
                            Enrollment ID
                        </th>                     
                         <th>
                            Course ID
                        </th>   
                        <th>
                            Course Name
                        </th>                       
                        <th>
                            Teacher Name
                        </th>  
                        <th>
                           Semester Term
                        </th>                        
                         <th>
                            &nbsp;
                        </th>                      
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal runat="server" ID="ltData"></asp:Literal>
                </tbody>
            </table>
        </div>
    </div>


    <div class="modal fade" id="dropModal" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="dropclosebtn" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Drop Course</h4>
        </div>       
        <div class="modal-body" id="Div4">
        <form id="Form3" class="form-horizontal">
           <input type="hidden" id="eid" name="eid" />
           <input type="hidden" id="cid" name="cid" />
                  Are you sure do you want to drop the course?
            </form>
        
        </div>        
        <div class="modal-footer" id="Div5" runat="server">
            <a href="#" class="btn btn-danger btn-sm" id="dropCourse">Yes, Drop</a>     
           <button type="button" id="dropclosebtn2" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>

</asp:Content>

