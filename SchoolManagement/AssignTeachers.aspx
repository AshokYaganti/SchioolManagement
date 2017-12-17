<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignTeachers.aspx.cs" Inherits="AssignTeachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

<div class="ibox-title">
        <h5><strong>Assign Teachers to Courses</strong></h5>
        <div class="ibox-content">
            <form id="Form1" class="form-horizontal" runat="server">

                <div class="form-group">
                    <label class="col-md-3 control-label">Teacher Name (Teacher ID)</label>
                    <div class="col-md-5">
                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                      </asp:DropDownList>
                    </div>
                </div>
               
                <div class="form-group">
                    <label class="col-md-3 control-label">Term</label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="DropDownList3" class="form-control" runat="server" AutoPostBack="true"
                            onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                      </asp:DropDownList>
                    </div>
                </div>              
              
                <div class="form-group">
                    <label class="col-md-3 control-label">Course</label>
                    <div class="col-md-5">
                         <asp:DropDownList ID="DropDownList4" class="form-control" runat="server">
                      </asp:DropDownList>
                    </div>
                </div>                
                <div class="form-group">
                    <div class="col-sm-4 col-sm-offset-3">
                       <asp:Button ID="Button1" class="btn btn-sm btn-success" runat="server" 
                            Text="Submit" onclick="Button1_Click" />                   
                    </div>
                </div>
            </form>
        </div>
    </div>


     <div class="ibox-title">
        <h5>
            <strong>Assigned Teachers</strong></h5>           
          <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="assignTeachers">
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
                           Semester Term
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

