<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Web2.aspx.cs" Inherits="L2.Web2" %>
<link href="Styles/StyleOne.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2" runat="server" Text="Darbuotojų failas:" CssClass="text"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="background" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Detalių failas:" CssClass="text"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="background" />
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Įveskite pagamintų vienetų skaičių S:" CssClass="text"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="background"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="S reikšmė privaloma" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Įveskite įkainį K:" CssClass="text"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" CssClass="background"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="K reikšmė privaloma" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" CssClass="text" />
            <asp:Label ID="Label11" runat="server" CssClass="text" Text="Pagal nurodytus kriterijus duomenų nėra."></asp:Label>
            <br />
            <asp:Label ID="Label12" runat="server" CssClass="text" Text="Darbuotojų, gaminusių tik vieno tipo detales, nėra."></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" CssClass="button" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Pradiniai duomenys:" CssClass="text"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Darbuotojai:" CssClass="text"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Detalės:" CssClass="text"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Daugiausiai uždirbę (-s) darbuotojai (-as):" CssClass="text"></asp:Label>
            <asp:Table ID="Table3" runat="server" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Darbuotojai, gaminę tik vieno pavadinimo detales:" CssClass="text"></asp:Label>
            <asp:Table ID="Table4" runat="server" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Naujas duomenų rinkinys, kai pagamintų vienetų skaičius &gt; S ir įkainis &lt; K:" CssClass="text"></asp:Label>
            <asp:Table ID="Table5" runat="server" GridLines="Both" CssClass="table">
            </asp:Table>
            <br />
        </div>
    </form>
</body>
</html>
