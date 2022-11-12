<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 18px;
        }
        .auto-style2 {
            margin-left: 8px;
        }
        .auto-style4 {
            width: 124px;
        }
        .auto-style5 {
            width: 124px;
            height: 48px;
        }
        .auto-style6 {
            height: 48px;
        }
        .auto-style7 {
            width: 124px;
            height: 23px;
        }
        .auto-style8 {
            height: 23px;
        }
        .auto-style9 {
            height: 21px;
            background-color: #99FFCC;
        }
        .auto-style10 {
            width: 100%;
            margin-top: 36px;
            color: #000000;
            background-color: #FFFF99;
        }
        .auto-style11 {
            margin-left: 15px;
        }
        .auto-style12 {
            width: 45px;
        }
        .auto-style14 {
            margin-left: 0px;
        }
        .auto-style15 {
            width: 49px;
            height: 23px;
        }
        .auto-style16 {
            width: 100%;
            height: 47px;
            color: #000000;
            background-color: #00CC66;
        }
        .auto-style17 {
            height: 43px;
        }
        .auto-style19 {
            margin-top: 2px;
        }
        .auto-style20 {
            height: 925px;
            background-color: #66CCFF;
        }
        .auto-style21 {
            width: 83px;
            height: 23px;
        }
        .auto-style27 {
            width: 100%;
            height: 126px;
            background-color: #FF6600;
        }
        .auto-style28 {
            width: 100%;
            height: 40px;
            background-color: #FFFFCC;
        }
        .auto-style29 {
            width: 134px;
            height: 37px;
        }
        .auto-style30 {
            height: 37px;
        }
        .auto-style32 {
            width: 22px;
        }
        .auto-style33 {
            background-color: #00CC66;
        }
        .auto-style34 {
            width: 100%;
            background-color: #00CC66;
        }
        .auto-style35 {
            background-color: #FFFFCC;
        }
    </style>
</head>
<body style="height: 905px">
    <form id="form1" runat="server" class="auto-style20">
        <div class="auto-style9">
            <asp:Label ID="LabelTiltle" runat="server" Font-Bold="True" Font-Italic="True" Font-Underline="True" Text="Imobiliária Casinhas de Papel"></asp:Label>
        </div>
        <p class="auto-style17">
            <asp:Label ID="LabelDono" runat="server" Text="Nome do Dono:"></asp:Label>
            <asp:TextBox ID="TextBoxDono" runat="server" CssClass="auto-style1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxDono" ErrorMessage="Preencher Nome do Dono!">*</asp:RequiredFieldValidator>
            <table class="auto-style10">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Labelimovel" runat="server" Text="Tipo do Imóvel:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="DropDownListImóvel" runat="server" CssClass="auto-style2" AutoPostBack="True" OnSelectedIndexChanged="DropDownListImóvel_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Casa</asp:ListItem>
                            <asp:ListItem>Sobrado</asp:ListItem>
                            <asp:ListItem>Apartamento</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListImóvel" ErrorMessage="Escolher um Tipo de Imóvel!!!">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LabelQTDvagas" runat="server" Text="Quantidade de Vagas:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblrespQTDVagas" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LabelQTDrooms" runat="server" Text="Quantidade de Quartos:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblrespQTDrooms" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Lblporcento" runat="server" Text="Porcentagem para Cálculo de Aluguel:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="Lblrespporcentagem" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width:100%;" class="auto-style35">
                <tr>
                    <td>
                        <asp:Label ID="Labelvenda" runat="server" Text="Valor de Venda R$:"></asp:Label>
                        <asp:TextBox ID="TextBoxVenda" runat="server" CssClass="auto-style11"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxVenda" ErrorMessage="Preencher o valor de venda Desejado!">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width:100%;" class="auto-style33">
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="LblPiscina" runat="server" Text="Piscina:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Obrigatório responder se o imóvel possui  Piscina ou Não!">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style32">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" CssClass="auto-style14" Width="82px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Value="200">Sim</asp:ListItem>
                            <asp:ListItem Value="0">Não</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <table class="auto-style34">
                <tr>
                    <td>
                        <table class="auto-style16">
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="LblSuíte" runat="server" Text="Suíte:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RadioButtonList2" ErrorMessage="Obrigatório responder se o imóvel possui  Suíte ou Não!">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style21">
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" CssClass="auto-style14" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                        <asp:ListItem Value="0.15">Sim</asp:ListItem>
                                        <asp:ListItem Value="0">Não</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="auto-style8">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="auto-style28">
                <tr>
                    <td>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style29">
                                    <asp:Label ID="LabelvalueAluguel" runat="server" Text="Valor do Aluguel R$:"></asp:Label>
                                </td>
                                <td class="auto-style30">
                                    <asp:TextBox ID="TextBoxAluguel" runat="server" CssClass="auto-style14" Width="127px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="auto-style27">
                <tr>
                    <td class="auto-style8">
                        <table style="width:100%;">
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="ButtonCalcular" runat="server" OnClick="ButtonCalcular_Click" Text="Calcular o Valor do Aluguel" Width="904px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="ButtonCadastrar" runat="server" Text="Cadastrar" Width="912px" CssClass="auto-style19" OnClick="ButtonCadastrar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Label ID="LblMSG" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="38px" />
                    </td>
                </tr>
            </table>
        </p>
    </form>
</body>
</html>
