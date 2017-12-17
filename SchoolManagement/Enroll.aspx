<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="Enroll.aspx.cs" Inherits="Enroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">
    
<div class="ibox-title">
        <h5><strong>Make Payment</strong></h5>
        <div class="ibox-content">
            <form id="Form1" class="form-horizontal" runat="server">
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" Visible="false"></asp:TextBox>
                <div class="form-group">
                    <label class="col-md-3 control-label">Amount</label>
                    <div class="col-md-5">                        
                        <asp:TextBox ID="Amounttxt" name="Amounttxt" runat="server" class="form-control disabled"></asp:TextBox>
                    </div>
                </div>
               
                <div class="form-group">
                    <label class="col-md-3 control-label">Card Number</label>
                    <div class="col-md-5">
                        <input type="text" name="cardnumber" id="cardnumber" class="form-control">
                    </div>
                </div>              
              
                <div class="form-group">
                    <label class="col-md-3 control-label">Expiry Date</label>
                    <div class="col-md-6">
                    <label class="col-md-2 control-label">Month:</label>
                      <div class="col-md-3">
                       <input type="number" name="month" id="month" class="form-control col-md-3" />
                       </div>
                        <label class="col-md-2 control-label">Year:</label>
                         <div class="col-md-3">
                        <input type="number" name="year" id="year" class="form-control col-md-3"/>
                        </div>
                    </div>
                </div>
                
                <div class="form-group">
                    <label class="col-md-3 control-label">Card Type</label>
                    <div class="col-md-5">
                       <asp:DropDownList ID="DropDownList5" runat="server" class="form-control">
                         <asp:ListItem Value="0">-- Select Card Type --</asp:ListItem>
                         <asp:ListItem>Visa</asp:ListItem>
                       <asp:ListItem>Master</asp:ListItem>
                       </asp:DropDownList>
                    </div>
                </div>
                
                <div class="form-group">
                    <label class="col-md-3 control-label">Security Code</label>
                    <div class="col-md-5">
                        <input type="text" name="code" id="code"  class="form-control" />
                    </div>
                </div>               
                <div class="form-group">
                    <div class="col-sm-4 col-sm-offset-3">
                       <asp:Button ID="Button1" class="btn btn-sm btn-success" runat="server" 
                            Text="Pay" onclick="Button1_Click"/>                   
                    </div>
                </div>
            </form>
        </div>
    </div>

</asp:Content>

