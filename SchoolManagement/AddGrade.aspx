<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="AddGrade.aspx.cs" Inherits="AddGrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

<div class="ibox-title" runat="server" id="tabledisplay">
        <h5>
            <strong>Enrolled Students</strong></h5>
        <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="enrolledStudents">
                <thead>
                    <tr>
                        <th>
                           Student ID
                        </th>
                        <th>
                            Student Name
                        </th>
                        <th>
                            Email
                        </th> 
                        <th>
                            Grade
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
          <button type="button" id="addgradeclose2" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add/Edit Grade</h4>
        </div>       
        <div class="modal-body" id="Div2">
        <form id="Form2" class="form-horizontal">
           <input type="hidden" id="eid" name="eid" />
                <div class="form-group">
                    <label class="col-md-3 control-label">Grade</label>
                    <div class="col-md-4">                        
                        <select class="form-control" id="grade">
                          <option value="NA">Not Available</option>
                          <option value="A">A</option>
                          <option value="A-">A-</option>
                          <option value="B+">B+</option>
                          <option value="B">B</option>
                          <option value="B-">B-</option>
                          <option value="C">C</option>
                          <option value="D">D</option>
                        </select>
                    </div>
                </div>           
               
            </form>
        
        </div>        
        <div class="modal-footer" id="Div3" runat="server">
            <a href="#" class="btn btn-success btn-sm" id="addGradeBtn">Add Grade</a>     
           <button type="button" id="addgradeclose" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>      
    </div>
  </div>
</asp:Content>

