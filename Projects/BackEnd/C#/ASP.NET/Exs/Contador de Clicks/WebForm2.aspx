<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Contador_de_Clicks.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="LabelEX" runat="server" Text="Exemplo ViewState &amp; SESSION"></asp:Label>
        <p>
            <asp:Label ID="LabelSESS" runat="server" Text="SESSION:"></asp:Label>
            <asp:Label ID="LabelSESSresp" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Labelview" runat="server" Text="ViewState:"></asp:Label>
            <asp:Label ID="LabelViewresp" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
