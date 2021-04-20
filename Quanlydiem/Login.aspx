<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quanlydiem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            padding-top: 5rem;
            padding-left: 30rem;
        }
        #lbError {
            color: red
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>

        <h1 style="color: blue">Login form</h1>
        <div>
            Đăng nhập: &nbsp <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </div>
        <br/>
        <div>
            Mật khẩu : &nbsp&nbsp <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <br/>
        <div>
            <asp:Button  ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="Login" />
        </div>
        <br/>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa nhập tên đăng nhập" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn chưa nhập mật khẩu" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        </div>
            <asp:Label ID="lbError" runat="server"></asp:Label>
    </div>
</form>
</body>
</html>
