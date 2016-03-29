<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarSenha.aspx.cs" Inherits="UI.AlterarSenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ChangePassword ID="ChangePassword1" runat="server" CancelButtonText="Cancelar" ChangePasswordButtonText="Resetar Senha" ChangePasswordTitleText="Trocar Senha" ConfirmNewPasswordLabelText="Confirme sua nova senha:" NewPasswordLabelText="Nova senha:" PasswordLabelText="Senha Atual:">
            </asp:ChangePassword>
        </div>
    </form>
</body>
</html>
