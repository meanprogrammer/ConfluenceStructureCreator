<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="ConfluenceAutomator.WebForms.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Space Information</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">Space Name</div>
                    <div class="col-md-6">
                        <asp:TextBox ID="SpaceNameTextBox" CssClass="form-control" runat="server"></asp:TextBox></div>
                </div>
                <div class="row">
                    <div class="col-md-6">Space Key</div>
                    <div class="col-md-6">
                        <asp:TextBox ID="SpaceKeyTextBox" CssClass="form-control" runat="server"></asp:TextBox></div>
                </div>
                <div class="row">
                    <div class="col-md-6">Description</div>
                    <div class="col-md-6">
                        <asp:TextBox ID="DescriptionTextBox" CssClass="form-control" runat="server"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Parent Space</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">

                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Target Space</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:TreeView ID="ParentSpaceTreeView" runat="server" ShowCheckBoxes="All">
                        </asp:TreeView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
