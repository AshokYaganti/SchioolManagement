<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.master" Debug="true" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" Runat="Server">
 <div class="ibox-title">
 <h5>Logn Form</h5>       
    </div>
    <div class="ibox-content">
        <div class="row">
            <div class="col-sm-6 b-r">
                <h3 class="m-t-none m-b">Sign in</h3>              
                <form role="form" runat="server">
                    <div class="form-group">
                        <label>Username/ID</label>
                        <input type="text" name="username" id="username" placeholder="Enter username/ID" class="form-control"></div>
                    <div class="form-group">
                        <label>Password</label>
                        <input type="password" name="password" id="password" placeholder="Password" class="form-control"></div>
                    <div>
                        <asp:Button class="btn btn-sm btn-success pull-right" ID="Button1" 
                            runat="server" Text="Log in" onclick="Button1_Click" />                                            
                    </div>
                </form>
            </div>
            <div class="col-sm-3 b-r">
                <h4>School Registration</h4>                
                <p class="text-center">
                    <a href="Registration.aspx"><i class="fa fa-sign-in big-icon" style="color:#1c84c6"></i></a>
                </p>
            </div>
            <div class="col-sm-3">
                <h4>Student Application</h4>               
                <p class="text-center">
                    <a href="StudentApplication.aspx"><i class="fa fa-sign-in big-icon" style="color:#1c84c6"></i></a>
                </p>
            </div>
        </div>
    </div>
</asp:Content>

