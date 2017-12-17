<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DirectorHome.aspx.cs" Inherits="DirectorHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

<div class="ibox-title">
        <h5>
            <strong>Student Applications</strong></h5>            
          <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="studentApplications">
                <thead>
                    <tr>
                        <th>
                           Application ID
                        </th>
                        <th>
                           Username
                        </th>
                        <th>
                            Student Name
                        </th>
                         <th>
                          Semester
                        </th> 
                         <th>
                          Status
                        </th>  
                         <th>
                          Created Date
                        </th>  
                        <th>
                            Email
                        </th> 
                        <th>
                          Phone
                        </th>
                         <th>
                          Address
                        </th>
                          <th>
                          State
                        </th>
                          <th>
                          City
                        </th> 
                         <th>
                          Zip
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


    <div class="modal fade" id="approveModal" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="approveclosebtn" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Approve Application</h4>
        </div>       
        <div class="modal-body" id="Div4">
        <form id="Form3" class="form-horizontal">
           <input type="hidden" id="applicationid" name="applicationid" />
           <input type="hidden" id="email" name="email" />
                  Are you sure do you want to approve the application?

            </form>
        
        </div>        
        <div class="modal-footer" id="Div5" runat="server">
            <a href="#" class="btn btn-success btn-sm" id="approvebtn">Yes, Approve</a>     
           <button type="button" id="approveclosebtn2" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>


   <div class="modal fade" id="rejectModal" role="dialog">
    <div class="modal-dialog">    
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" id="rejectclosebtn" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Reject Application</h4>
        </div>       
        <div class="modal-body" id="Div2">
        <form id="Form1" class="form-horizontal">
           <input type="hidden" id="applicationid1" name="applicationid1" />
            <input type="hidden" id="email1" name="email1" />
                  Are you sure do you want to reject the application?

            </form>
        
        </div>        
        <div class="modal-footer" id="Div3" runat="server">
            <a href="#" class="btn btn-danger btn-sm" id="rejectbtn">Yes, Reject</a>     
           <button type="button" id="rejectclosebtn2" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>

</asp:Content>

