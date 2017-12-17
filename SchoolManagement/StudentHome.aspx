<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="StudentHome.aspx.cs" Inherits="StudentHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

 <div class="ibox-title">
        <h5><strong>Enroll Courses</strong></h5>
        <div class="ibox-content">
            <form id="Form1" class="form-horizontal" runat="server">

                <div class="form-group">
                    <label class="col-md-3 control-label">Select Term</label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
               <div class="form-group">
                    <div class="col-sm-4 col-sm-offset-3">
                       <asp:Button ID="Button1" class="btn btn-sm btn-success" runat="server" 
                            Text="Search Courses" onclick="Button1_Click"/>                   
                    </div>
                </div>
            </form>
        </div>
    </div>

 <div class="ibox-title" runat="server" visible="false" id="tabledisplay">
        <h5>
            <strong>Search Results</strong></h5>
        <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="searchedcourses">
                <thead>
                    <tr>
                        <th>
                            Course ID
                        </th>
                        <th>
                            Course Name
                        </th>
                        <th>
                            Teacher ID
                        </th> 
                        <th>
                            Teacher Name
                        </th>  
                        <th>
                            cost
                        </th> 
                        <th>
                            total Seats
                        </th> 
                          <th>
                            Available Seats
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

</asp:Content>

