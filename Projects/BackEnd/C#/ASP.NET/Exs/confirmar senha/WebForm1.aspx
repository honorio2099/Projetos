<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="confirmar_senha.WebForm1" %>

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
        <asp:Label ID="LabelName" runat="server" Text="Nome:"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server" OnTextChanged="TextBox1_TextChanged" style="margin-left: 29px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName" ErrorMessage="Campo Nome Obrigatório!!!">******</asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="LabelIdade" runat="server" Text="Idade:"></asp:Label>
            <asp:TextBox ID="TextBoxIdade" runat="server" style="margin-left: 23px"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="idade entre 16 e 99 anos" MaximumValue="99" MinimumValue="16" Type="Integer" ControlToValidate="TextBoxIdade">***</asp:RangeValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxIdade" ErrorMessage="Campo Idade Obrigatório!!!">***</asp:RequiredFieldValidator>
        </p>
        <asp:Label ID="LabelData" runat="server" Text="Data de Nascimento:"></asp:Label>
        <asp:TextBox ID="TextBoxData" runat="server" style="margin-left: 18px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Data deve ser no formato dd-mm-aaaa" ValidationExpression="\d{2}-\d{2}-\d{4}" ControlToValidate="TextBoxData">***</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxData" ErrorMessage="Campo Data Obrigatório!!!">***</asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="LabelSenha" runat="server" Text="Senha:"></asp:Label>
            <asp:TextBox ID="TextBoxSenha" runat="server" style="margin-left: 22px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Senha Obrigatório!!!">******</asp:RequiredFieldValidator>
        </p>
        <asp:Label ID="LabelConfirmar" runat="server" Text="Confirmar Senha:"></asp:Label>
        <asp:TextBox ID="TextBoxConfirmar" runat="server" style="margin-left: 17px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxSenha" ControlToValidate="TextBoxConfirmar" ErrorMessage="Senhas não são iguais!!!">***</asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Confirmar Senha Obrigatório!!!">***</asp:RequiredFieldValidator>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Cadastrar" />
        </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
</body>
</html>
