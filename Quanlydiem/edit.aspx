<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Quanlydiem.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #lbError {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Mã sinh viên</td>
                    <td><asp:TextBox ID="txtMaSV" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td> Họ và tên</td>
                    <td><asp:TextBox ID="txtHoTen" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Mã lớp</td>
                    <td><asp:TextBox ID="txtMalop" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td> Mã môn</td>
                    <td><asp:TextBox ID="txtMamon" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Điểm trung bình</td>
                    <td><asp:TextBox ID="txtdtb" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td> Điểm thi</td>
                    <td><asp:TextBox ID="txtdt" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td> Điểm tổng kết</td>
                    <td><asp:TextBox ID="txtdtk" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Học kỳ</td>
                    <td><asp:TextBox ID="txtHocky" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ghi chú</td>
                    <td><asp:TextBox ID="txtGhichu" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" /> </td>
                    <td><asp:Button ID="btnBack" runat="server" Text="Come Back" OnClick="btnBack_Click" /></td>
                </tr>
            </table>
            <br/>
            <br/>
            <asp:Label ID="lbError" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
