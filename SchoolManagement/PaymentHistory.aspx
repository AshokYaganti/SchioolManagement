<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="PaymentHistory.aspx.cs" Inherits="PaymentHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

<div class="ibox-title" runat="server" id="tabledisplay">
        <h5>
            <strong>Payment History</strong></h5>
        <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="payhistory">
                <thead>
                    <tr> 
                                    
                         <th>
                            Course ID
                        </th>   
                        <th>
                            Course Name
                        </th>                       
                        <th>
                            Amount
                        </th>  
                        <th>
                           Transaction Date
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

