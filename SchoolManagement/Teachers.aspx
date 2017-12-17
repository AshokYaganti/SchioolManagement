<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Teachers.aspx.cs" Inherits="Teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

 <div class="ibox-title">
        <h5>
            <strong>Term Table</strong></h5>
            <h4 style="text-align:right;"><a href="#" id="add" class="btn-success btn-sm" data-toggle="modal" data-target="#addModal" style="text-decoration:none">Add Teacher</a></h4>
            <input type="hidden" value="<% =schoolidtxtValue %>" id="schoolidtxt" name="schoolidtxt" />
          <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="teachertable">
                <thead>
                    <tr>
                        <th>
                            Teacher ID
                        </th>
                        <th>
                            Teacher Name
                        </th>
                        <th>
                            Email
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


   <div class="modal fade" id="addModal" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="closebtn2" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Teacher</h4>
        </div>       
        <div class="modal-body" id="addBody">
        <form id="Form1" class="form-horizontal">

                <div class="form-group">
                    <label class="col-md-3 control-label">Teacher Name</label>
                    <div class="col-md-8">
                        <input type="text"  name="tname" id="tname"  class="form-control col-md-3" required>
                         <label class="col-md-5 control-label hidden" style="color:Red;" id="namevalidation">Please enter name</label>
                    </div>
                </div>
               
                <div class="form-group">
                    <label class="col-md-3 control-label">Email Address</label>
                    <div class="col-md-8">
                        <input type="email" name="email" id="email" class="form-control col-md-3" required>
                        <label class="col-md-5 control-label hidden" style="color:Red;" id="emailvalidation">Please enter email</label>
                    </div>
                </div>            

            </form>
        
        </div>        
        <div class="modal-footer" id="addFooter">
            <a href="#" class="btn btn-success btn-sm" id="addTeacher">Add Teacher</a>     
           <button type="button" id="closebtn" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>




  <div class="modal fade" id="updateModel" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="updateclose2" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Update Teacher</h4>
        </div>       
        <div class="modal-body" id="Div2">
        <form id="Form2" class="form-horizontal">
           <input type="hidden" id="teacherid" name="teacherid" />
                <div class="form-group">
                    <label class="col-md-3 control-label">Teacher Name</label>
                    <div class="col-md-8">
                        <input type="text"  name="tname1" id="tname1"  class="form-control col-md-3" required>
                         <label class="col-md-5 control-label hidden" style="color:Red;" id="namevalidation1">Please enter name</label>
                    </div>
                </div>
               
                <div class="form-group">
                    <label class="col-md-3 control-label">Email Address</label>
                    <div class="col-md-8">
                        <input type="email" name="email1" id="email1" class="form-control col-md-3" required>
                        <label class="col-md-5 control-label hidden" style="color:Red;" id="emailvalidation1">Please enter email</label>
                    </div>
                </div>            

            </form>
        
        </div>        
        <div class="modal-footer" id="Div3" runat="server">
            <a href="#" class="btn btn-success btn-sm" id="updateTeacher">update Teacher</a>     
           <button type="button" id="updateclosebtn" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>




   <div class="modal fade" id="deleteModal" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="deleteclosebtn" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Delete Teacher</h4>
        </div>       
        <div class="modal-body" id="Div4">
        <form id="Form3" class="form-horizontal">
           <input type="hidden" id="teacherid1" name="teacherid1" />
                  Are you sure do you want to delete?

            </form>
        
        </div>        
        <div class="modal-footer" id="Div5" runat="server">
            <a href="#" class="btn btn-success btn-sm" id="deleteTeacher">Yes, Delete</a>     
           <button type="button" id="deleteclosebtn2" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>


</asp:Content>

