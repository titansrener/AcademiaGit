<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagCadastrarFiliais.aspx.cs" Inherits="UI.Cadastros.pagCadastrarFiliais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="color: #99CC00">Filial</legend>
        <table style="width: 100%; color: #FFFFFF;">
            <tr>
                <td>
                    <asp:Label ID="lblDescricao" runat="server" ForeColor="#99CC00" Text="Descrição" Font-Bold="True"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtDescricao" runat="server" MaxLength="50" Height="23px" Width="264px" ForeColor="#99CC00"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ControlToValidate="txtDescricao" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndereco" runat="server" ForeColor="#99CC00" Text="Endereço" Font-Bold="True"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtEndereco" runat="server" MaxLength="150" Height="23px" Width="219px" ForeColor="#99CC00"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" ControlToValidate="txtEndereco" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTelefone" runat="server" ForeColor="#99CC00" Text="Telefone" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefone" runat="server" MaxLength="8" Height="23px" ForeColor="#99CC00"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtTelefone_MaskedEditExtender" runat="server" Mask="9999-9999" TargetControlID="txtTelefone">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
                <td style="width: 72px; height: 28px;">
                    <asp:Label ID="lblBairro" runat="server" ForeColor="#99CC00" Text="Bairro" Font-Bold="True"></asp:Label>
                </td>
                <td style="height: 28px">
                    <asp:TextBox ID="txtBairro" runat="server" MaxLength="50" Height="23px" Width="210px" ForeColor="#99CC00"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBairro" runat="server" ControlToValidate="txtBairro" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" ForeColor="#99CC00" Text="Email" Font-Bold="True"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Height="23px" Width="220px" ForeColor="#99CC00"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ForeColor="#99CC00" ToolTip="Email inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPreco" runat="server" Font-Bold="True" ForeColor="#99CC00" Text="Preco (R$)"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtPreco" runat="server" ForeColor="#99CC00" MaxLength="10"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtPreco_MaskedEditExtender" runat="server" Mask="999,99" TargetControlID="txtPreco">
                    </ajaxToolkit:MaskedEditExtender>
                    <asp:RequiredFieldValidator ID="rfvPreco" runat="server" ControlToValidate="txtPreco" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo obrigatório">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" ForeColor="#99CC00" />
                </td>
                <td colspan="3">
                    <asp:Button ID="btnCancelar" runat="server" style="text-align: center" Text="Cancelar" CausesValidation="False" OnClick="btnCancelar_Click" ForeColor="#99CC00" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
