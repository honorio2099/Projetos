<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


        .style2
        {
            width: 129px;
        }
        .auto-style1 {
            width: 147px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Escolha uma refeição:
        <asp:DropDownList ID="ddlRefeicao" runat="server" OnSelectedIndexChanged="ddlRefeicao_SelectedIndexChanged">
            <asp:ListItem>Arroz com Feijão</asp:ListItem>
            <asp:ListItem>Lasanha</asp:ListItem>
            <asp:ListItem>Arroz Sem Feijão</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:Button ID="btnRefeicaoOK" runat="server" Text="OK" OnClick="btnRefeicaoOK_Click" />
        <br />
        Mistura:
        <asp:Label ID="lblMistura" runat="server"></asp:Label>
        <br />
        Quantidade Disponível: <asp:Label ID="lblQtdDisponivel" runat="server"></asp:Label>
        <br />
        Preço de Venda R$:
        <asp:Label ID="lblPrecoVenda" runat="server"></asp:Label>
        <br />
        <br />
        Escolha a Forma de Entrega:
        <asp:DropDownList ID="ddlFormaEntrega" runat="server">
            <asp:ListItem>Entregar em Casa</asp:ListItem>
            <asp:ListItem>Comer no Local</asp:ListItem>
            <asp:ListItem>Retirar para Viagem</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<br />
        <br />
        Nome do Cliente: <asp:TextBox ID="txtNomeCli" runat="server"></asp:TextBox>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data da Compra:</td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" style="font-size: x-small"></asp:Calendar>
                </td>
            </tr>
        </table>
        Quantidade Desejada:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Favor digitar quantidade desejada!!!">***</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtQtdDesejada" runat="server" style="margin-left: 1px" Height="22px" Width="128px"></asp:TextBox>
        &nbsp;<asp:Button ID="btnCalcularTotal" runat="server" Text="Calcular Total a Pagar" CausesValidation="False" OnClick="btnCalcularTotal_Click" style="margin-left: 10px" Width="192px" />
        &nbsp;<asp:Label ID="lblErro" runat="server"></asp:Label>
        <br />
        Total a Pagar R$:
        <asp:Label ID="lblTotalPagar" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnComprar" runat="server" Text="Comprar" CausesValidation="False" OnClick="btnComprar_Click" />
        <asp:Label ID="lblComprar" runat="server"></asp:Label>
        &nbsp;</div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
</body>
</html>
