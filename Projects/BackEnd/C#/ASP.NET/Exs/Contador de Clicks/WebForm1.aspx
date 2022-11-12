<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Contador_de_Clicks.WebForm1" %>

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
        <asp:Label ID="LabelClickTitle" runat="server" Text="Contador de Clicks!!!"></asp:Label>
        <p>
            <asp:Label ID="Labelqtd" runat="server" Text="Quantidade de Clicks (SESSION):"></asp:Label>
            <asp:Label ID="LabelrespSESSClicks" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Quantidade de Clicks (ViewState):"></asp:Label>
            <asp:Label ID="LabelrespViewClicks" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="ButtonClick" runat="server" OnClick="ButtonClick_Click" Text="ClickMe!" Width="238px" />
        </p>
        <p style="height: 19px">
            Abrir outra janela no navegador</p>
        <p style="height: 19px">
            <asp:Button ID="ButtonTela" runat="server" OnClick="ButtonTela_Click" style="margin-left: 34px" Text="Outra Tela" Width="124px" />
        </p>
    </form>
</body>
</html>
