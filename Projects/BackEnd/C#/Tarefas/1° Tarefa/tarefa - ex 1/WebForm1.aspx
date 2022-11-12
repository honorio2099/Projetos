<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="tarefa___ex_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 31px;
        }
        .auto-style3 {
            width: 100%;
            height: 93px;
        }
        .auto-style4 {
            height: 25px;
        }
        .auto-style5 {
            margin-left: 23px;
        }
        .auto-style6 {
            margin-left: 18px;
        }
        .auto-style7 {
            width: 100%;
            height: 62px;
        }
        .auto-style8 {
            width: 135px;
        }
        .auto-style9 {
            width: 100%;
        }
        .auto-style10 {
            height: 34px;
        }
        .auto-style11 {
            background-color: #99FFCC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style11">
        <div>
        </div>
        <asp:Label ID="LabelTITLE" runat="server" Font-Bold="True" Font-Italic="True" Font-Underline="True" Text="Consultório Médico XYZ"></asp:Label>
        <p>
            <asp:Label ID="Labelname" runat="server" Text="Nome do Paciente:"></asp:Label>
            <asp:TextBox ID="TextBoxname" runat="server" style="margin-left: 26px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxname" ErrorMessage="Campo nome Obrigatório!!!">*</asp:RequiredFieldValidator>
        </p>
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="LabelConvênio" runat="server" Text="Convênio:"></asp:Label>
                    <asp:DropDownList ID="DropDownListConvênio" runat="server" style="margin-left: 20px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Unimed</asp:ListItem>
                        <asp:ListItem>Policin</asp:ListItem>
                        <asp:ListItem>Sul América</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListConvênio" ErrorMessage="Convênio Obrigatório!!!">*</asp:RequiredFieldValidator>
                    <asp:Button ID="ButtonConvênio" runat="server" OnClick="ButtonConvênio_Click" style="margin-left: 17px" Text="OK" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Labelvalueconvenio" runat="server" Text="Valor da Consulta R$:"></asp:Label>
                    <asp:Label ID="LabelrespValueconvenio" runat="server"></asp:Label>
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style4"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table class="auto-style3">
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="LabelMédico" runat="server" Text="Médico:"></asp:Label>
                    <asp:DropDownList ID="DropDownListMédico" runat="server" CssClass="auto-style6">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>João</asp:ListItem>
                        <asp:ListItem>Maria</asp:ListItem>
                        <asp:ListItem>Antônio</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListMédico" ErrorMessage="Médico desejado Obrigatório!!!">*</asp:RequiredFieldValidator>
                    <asp:Button ID="ButtonMédico" runat="server" CssClass="auto-style5" OnClick="ButtonMédico_Click" Text="OK" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LabelEspecialidade" runat="server" Text="Especialidade:"></asp:Label>
                    <asp:Label ID="LblrespEspecialidade" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelvalueMedico" runat="server" Text="Valor da Consulta R$:"></asp:Label>
                    <asp:Label ID="lblrespValueMedico" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelqtdVagas" runat="server" Text="Quantidade de Vagas:"></asp:Label>
                    <asp:Label ID="lblrespQTDvagas" runat="server"></asp:Label>
                    <table style="width:100%;">
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table class="auto-style7">
            <tr>
                <td class="auto-style8" rowspan="2">
                    <asp:Label ID="LabelconsultaTipo" runat="server" Text="Tipo de Consulta:"></asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonEmergência" runat="server" EnableTheming="True" Text="Emergência" GroupName="VideoKilledTheRadioStar" />
                    <asp:Label ID="Lblerror1" runat="server" Visible="False" ForeColor="#CC0000">*</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="RadioButtonNormal" runat="server" Text="Normal" GroupName="VideoKilledTheRadioStar" />
                    <asp:Label ID="Lblerror2" runat="server" Visible="False" ForeColor="#CC0000">*</asp:Label>
                </td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1"></td>
            </tr>
        </table>
        <table class="auto-style9">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LabelMAINrespvalues" runat="server" Text="Valor da Consulta R$:"></asp:Label>
                    <asp:TextBox ID="TextBoxCalculate" runat="server" CssClass="auto-style5" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="Buttoncalculate" runat="server" OnClick="Buttoncalculate_Click" Text="Calcular Valor da Consulta:" Width="285px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelErro" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonCadastrar" runat="server" OnClick="ButtonCadastrar_Click" Text="Cadastrar" Width="908px" />
        <table class="auto-style9">
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td>
        <asp:Label ID="LabelMensagem" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Label ID="LabelerrorMSG" runat="server" ForeColor="#CC0000" Text="Favor Escolher um dos Tipos de Consulta!" Visible="False"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
