<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiangVien.aspx.cs" Inherits="Quanlydiem.GiaoVien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td> Mã giảng viên</td>
                    <td><asp:TextBox ID="txtMaGV" runat="server" Text=""></asp:TextBox></td>
                </tr>
                <%-- <tr> --%>
                <%--     <td>Khoa</td> --%>
                <%--     <td><asp:DropDownList AutoPostBack="true" ID="ddlKhoa" runat="server" OnSelectedIndexChanged="ddlKhoa_SelectedIndexChanged"> --%>
                <%--     </asp:DropDownList></td> --%>
                <%-- </tr> --%>
                <tr>
                    <td>Lớp</td>
                    <td><asp:DropDownList AutoPostBack="true" ID="ddlLop" runat="server" OnSelectedIndexChanged="ddLop_SelectedIndexChanged">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Môn</td>
                    <td><asp:DropDownList AutoPostBack="true" ID="ddlMon" runat="server" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged">
                    </asp:DropDownList></td>
                </tr>
            </table>
            <br/>
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" /> 
            <br/>
            <br/>
            <asp:GridView AutoGenerateColumns="false" EnableViewState="false" ID="tblDiemSV" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="MaSV" DataField="MaSV" />
                    <asp:BoundField HeaderText="HoTen" DataField="HoTen" />
                    <asp:BoundField HeaderText="MaLop" DataField="MaLop" />
                    <asp:BoundField HeaderText="MaMon" DataField="MaMon" />
                    <asp:BoundField HeaderText="DiemTB" DataField="DiemTB" />
                    <asp:BoundField HeaderText="DiemThi" DataField="DiemThi" />
                    <asp:BoundField HeaderText="DiemTongKet" DataField="DiemTongKet" />
                    <asp:BoundField HeaderText="HocKi" DataField="HocKi" />
                    <asp:BoundField HeaderText="GhiChu" DataField="GhiChu" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <div class="item" style="width: 80px">
                                <div style="width: 50%; float: left; color: red;">
                                    <a href="edit.aspx?masv=<%# DataBinder.Eval(Container.DataItem, "MaSV")%>&mamon=<%# DataBinder.Eval(Container.DataItem, "MaMon") %>" >Edit</a>
                                    
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
