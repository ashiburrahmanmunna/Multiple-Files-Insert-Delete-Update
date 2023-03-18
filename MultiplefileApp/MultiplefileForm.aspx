<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiplefileForm.aspx.cs" Inherits="MultiplefileApp.MultiplefileForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
            <tr>
                <td>ID</td>
                <td><asp:TextBox id="ID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Name</td>
                <td><asp:TextBox id="Name" runat="server"></asp:TextBox></td>
            </tr>

             <tr>
                
                <td><asp:FileUpload id="FileUpload1" AllowMultiple="true" runat="server"/> </td>
            </tr>

            <tr>
                <td><asp:Button id="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" /></td>
                <td><asp:Button id="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /></td>
                <td><asp:Button id="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /></td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
