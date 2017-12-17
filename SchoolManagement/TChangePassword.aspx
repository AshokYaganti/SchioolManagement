<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="TChangePassword.aspx.cs" Inherits="TChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">

 <div class="ibox-title">
        <h5><strong>Change Password</strong></h5>
        <div class="ibox-content">
            <form id="Form1" class="form-horizontal" runat="server">

                <div class="form-group">
                    <label class="col-md-3 control-label">New Password</label>
                    <div class="col-md-5">
                        <input type="password" name="password" id="password"  class="form-control">
                    </div>
                </div>
               
                <div class="form-group">
                    <label class="col-md-3 control-label">Confirm Password</label>
                    <div class="col-md-5">
                        <input type="password" name="cpassword" id="cpassword" class="form-control">
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
       

</asp:Content>

