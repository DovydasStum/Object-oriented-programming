<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Web.aspx.cs" Inherits="L4.Web" %>
<link href="Styles/CSS.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Prietaisų failai:" CssClass="text"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="background" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Skaičiuoti" OnClick="Button1_Click1" CssClass="button" />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Išimtys:" CssClass="text"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="110px" Width="341px" TextMode="MultiLine" CssClass="background"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Pradiniai duomenys:" CssClass="text"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" BorderWidth="1px" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Skirtingų „Siemens“ įrenginių kiekiai parduotuvėse:" CssClass="text"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server" BorderWidth="1px" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Pigiausi šaldytuvai (bent 80L talpos):" CssClass="text"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server" BorderWidth="1px" GridLines="Both" CssClass="table">
            </asp:Table>
            <asp:Label ID="Label6" runat="server" Text="Duomenų nėra." CssClass="text"></asp:Label>
            <br />
            <br />
            <br />
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
