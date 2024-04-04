<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="L1.aspx.cs" Inherits="WebApplication1.L1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Pradiniai duomenys:"></asp:Label>
            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Height="16px" Width="23px">
            </asp:Table>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Rezultatai:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Kurmių kiekis: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Urvų dydžiai (cm2) mažėjimo tvarka:"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" />
        </div>
    </form>
</body>
</html>
