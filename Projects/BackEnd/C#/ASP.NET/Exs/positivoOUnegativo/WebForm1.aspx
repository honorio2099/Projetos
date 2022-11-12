<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Exemplo positivo e Negativo</p>
        <p>
            Digite Um Número:<asp:TextBox ID="TextBox1" runat="server" Height="17px" OnTextChanged="TextBox1_TextChanged" style="margin-left: 16px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 20px" Text="IF Simples" Width="79px" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 27px" Text="IF Encadeado" Width="97px" />
        </p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
