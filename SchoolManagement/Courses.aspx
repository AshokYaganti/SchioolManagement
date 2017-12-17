<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

<div class="ibox-title">
        <h5>
            <strong>Term Table</strong></h5>
            <h4 style="text-align:right;"><a href="#" id="add" class="btn-success btn-sm" data-toggle="modal" data-target="#addCourseModal" style="text-decoration:none">Add Course</a></h4>
            <input type="hidden" value="<% =schoolidtxtValue %>" id="schoolidtxt" name="schoolidtxt" />
          <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="teachertable">
                <thead>
                    <tr>
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
                           Enrollments 
                        </th> 
                         <th>
                           Cost 
                        </th> 
                         <th>
                           Status 
                        </th> 
                         <th>
                           Created Date 
                        </th> 
                        <th>
                           &nbsp;
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


   <div class="modal fade" id="addCourseModal" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="courseclosebtn2" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Course</h4>
        </div>       
        <div class="modal-body" id="addBody">
        <form id="Form1" class="form-horizontal" runat="server">

                <div class="form-group">
                    <label class="col-md-3 control-label">Course Name</label>
                    <div class="col-md-8">
                        <input type="text"  name="cname" id="cname"  class="form-control col-md-3" required>
                         <label class="col-md-5 control-label hidden" style="color:Red;" id="cnamevalidation">Please enter course name</label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Semester Term</label>
                    <div class="col-md-8">                        
                        <asp:DropDownList ID="DropDownList1" ClientIDMode="Static" name="DropDownList1" runat="server" class="form-control col-md-3">
                        </asp:DropDownList>                        
                    </div>
                </div>
               
                <div class="form-group">
                    <label class="col-md-3 control-label">Seats</label>
                    <div class="col-md-8">
                        <input type="number" name="seats" id="seats" class="form-control col-md-3" required>
                        <label class="col-md-5 control-label hidden" style="color:Red;" id="seatsvalidation">Please enter seats</label>
                    </div>
                </div>            
                <div class="form-group">
                    <label class="col-md-3 control-label">Cost ($)</label>
                    <div class="col-md-8">
                        <input type="number" name="cost" id="cost" class="form-control col-md-3" required>
                        <label class="col-md-5 control-label hidden" style="color:Red;" id="costvalidation">Please enter cost</label>
                    </div>
                </div>   
            </form>
        
        </div>        
        <div class="modal-footer" id="addFooter">
            <a href="#" class="btn btn-success btn-sm" id="addCourse">Add Course</a>     
           <button type="button" id="courseclosebtn" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>




  <div class="modal fade" id="courseupdateModel" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="updatecourseclosebtn2" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Update Course</h4>
        </div>       
        <div class="modal-body" id="Div2">
        <form id="Form2" class="form-horizontal">
           <input type="hidden" id="courseid" name="courseid" />
                <div class="form-group">
                    <label class="col-md-3 control-label">Course Name</label>
                    <div class="col-md-8">
                        <input type="text"  name="cname1" id="cname1"  class="form-control col-md-3" required>
                         <label class="col-md-5 control-label hidden" style="color:Red;" id="cnamevalidation1">Please enter course name</label>
                    </div>
                </div>               
               
                <div class="form-group">
                    <label class="col-md-3 control-label">Seats</label>
                    <div class="col-md-8">
                        <input type="number" name="seats1" id="seats1" class="form-control col-md-3" required>
                        <label class="col-md-5 control-label hidden" style="color:Red;" id="seatsvalidation1">Please enter seats</label>
                    </div>
                </div>                
                 <div class="form-group">
                    <label class="col-md-3 control-label">Cost ($)</label>
                    <div class="col-md-8">
                        <input type="number" name="cost1" id="cost1" class="form-control col-md-3" required>
                        <label class="col-md-5 control-label hidden" style="color:Red;" id="costvalidation1">Please enter cost</label>
                    </div>
                </div> 
            </form>
        
        </div>        
        <div class="modal-footer" id="Div3" runat="server">
            <a href="#" class="btn btn-success btn-sm" id="updateCourse">update Teacher</a>     
           <button type="button" id="updateCourseclosebtn" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>




   <div class="modal fade" id="coursedeleteModal" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="deleteCourseclosebtn" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Delete Teacher</h4>
        </div>       
        <div class="modal-body" id="Div4">
        <form id="Form3" class="form-horizontal">
           <input type="hidden" id="courseid1" name="courseid1" />
                  Are you sure do you want to delete?

            </form>
        
        </div>        
        <div class="modal-footer" id="Div5" runat="server">
            <a href="#" class="btn btn-success btn-sm" id="deleteCourse">Yes, Delete</a>     
           <button type="button" id="deleteCourseclosebtn2" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>

</asp:Content>

