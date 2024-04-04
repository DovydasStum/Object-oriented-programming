<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Web.aspx.cs" Inherits="L5.Web" %>
<link href="Style/CSS.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Duomenų failai (prenumeratoriai):" CssClass="text"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="background" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Įvesti duomenis" CssClass="button" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text" />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Išimtys:" CssClass="text"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="background"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Prenumeratorių duomenys:" CssClass="text"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" BorderWidth="1px" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Leidinių duomenys:" CssClass="text"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server" BorderWidth="1px" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Įveskite, kurio mėnesio (skaičiumi 1-12) pajamas skaičiuoti:  " CssClass="text"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="background" Width="128px"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" BackColor="White" ControlToValidate="TextBox1" ErrorMessage="Mėnesis turi priklausyti intervalui [1;12]" ForeColor="Red" MaximumValue="12" MinimumValue="1">*</asp:RangeValidator>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Skaičiuoti" CssClass="button" />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Leidėjų informacija:" CssClass="text"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server" BorderWidth="1px" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
        </div>
    </form>
</body>
</html>
