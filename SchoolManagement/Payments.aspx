<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payments.aspx.cs" Inherits="Payments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

 <div class="ibox-title">
       <h5> <strong>Student Enrollments</strong></h5>           
          <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="studentpayments">
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
                        <th>
                           Amount
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

