<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" Debug="true"
    AutoEventWireup="true" CodeFile="Terms.aspx.cs" Inherits="Terms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right" runat="Server">
    <div class="ibox-title">
        <h5>
            <strong>School Registration Form</strong></h5>
        <div class="ibox-content">
            <form id="Form1" class="form-horizontal" runat="server">
            <div class="form-group">
                <label class="col-md-3 control-label">
                    Term</label>
                <div class="col-md-2">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="0">---Select term ---</asp:ListItem>
                        <asp:ListItem>Fall</asp:ListItem>
                        <asp:ListItem>Spring</asp:ListItem>
                        <asp:ListItem>Summer</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <label class="col-md-1 control-label">
                    Year</label>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem Value="0">---Select year--</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2020</asp:ListItem>
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                        <asp:ListItem>2025</asp:ListItem>
                        <asp:ListItem>2026</asp:ListItem>
                        <asp:ListItem>2027</asp:ListItem>
                        <asp:ListItem>2028</asp:ListItem>
                        <asp:ListItem>2029</asp:ListItem>
                        <asp:ListItem>2030</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">
                    Start Date</label>
                <div class="input-group col-md-3 date">
                    <input type="text" id='sdate' name="sdate" class="form-control" />
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">
                    End Date</label>
                <div class="input-group col-md-3 date">
                    <input type="text" id="edate" name="edate" class="form-control" />
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4 col-sm-offset-3">
                    <asp:Button ID="Button1" class="btn btn-sm btn-success" runat="server" Text="Submit"
                        OnClick="Button1_Click" />
                </div>
            </div>
            </form>
        </div>
    </div>
    <div class="ibox-title">
        <h5>
            <strong>Term Table</strong></h5>
        <div class="ibox-content">
            <table class="table table-condensed table-striped table-hover" id="termstable">
                <thead>
                    <tr>
                        <th>
                            Semester Term
                        </th>
                        <th>
                            Start Date
                        </th>
                        <th>
                            End Date
                        </th> 
                        <th>
                            Created Date
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
