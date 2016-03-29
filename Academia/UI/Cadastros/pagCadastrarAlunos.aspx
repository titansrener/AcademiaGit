<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagCadastrarAlunos.aspx.cs" Inherits="UI.Cadastros.pagCadastrarAlunos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="color: #99CC00">Aluno</legend>
        <table style="width: 100%">
            <tr>
                <td style="color: #FFFFFF; height: 7px;">
                    <asp:Label ID="lblNome" runat="server" ForeColor="#99CC00" Text="Nome" Font-Bold="True"></asp:Label>
                </td>
                <td style="color: #FFFFFF; height: 7px;" colspan="3">
                    <asp:TextBox ID="txtNome" runat="server" MaxLength="200" Height="23px" Width="155px" ForeColor="#99CC00"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="color: #FFFFFF; height: 38px;">
                    <asp:Label ID="lblEndereco" runat="server" ForeColor="#99CC00" Text="Endereço" Font-Bold="True"></asp:Label>
                </td>
                <td style="color: #FFFFFF; height: 38px;" colspan="3">
                    <asp:TextBox ID="txtEndereco" runat="server" MaxLength="200" Height="23px" Width="155px" ForeColor="#99CC00"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" ControlToValidate="txtEndereco" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="color: #FFFFFF; height: 33px;">
                    <asp:Label ID="lblCPF" runat="server" ForeColor="#99CC00" Text="CPF" Font-Bold="True"></asp:Label>
                </td>
                <td style="color: #FFFFFF; width: 189px; height: 33px;">
                    <asp:TextBox ID="txtCPF" runat="server" MaxLength="11" Width="155px" Height="23px" ForeColor="#99CC00"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtCPF_MaskedEditExtender" runat="server" Mask="999.999.999-99" MaskType="Number" TargetControlID="txtCPF">
                    </ajaxToolkit:MaskedEditExtender>
                    <asp:RequiredFieldValidator ID="rfvCPF" runat="server" ControlToValidate="txtCPF" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                </td>
                <td style="color: #FFFFFF; height: 33px;">
                    <asp:Label ID="lblCelular" runat="server" ForeColor="#99CC00" Text="Celular" Font-Bold="True"></asp:Label>
                </td>
                <td style="color: #FFFFFF; height: 33px;">
                    <asp:TextBox ID="txtCelular" runat="server" MaxLength="8" Height="23px" ForeColor="#99CC00" Width="155px"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtCelular_MaskedEditExtender" runat="server" Mask="9999-9999" MaskType="Number" TargetControlID="txtCelular">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="color: #FFFFFF; height: 26px;">
                    <asp:Label ID="lblSexo" runat="server" ForeColor="#99CC00" Text="Sexo" Font-Bold="True"></asp:Label>
                </td>
                <td style="color: #FFFFFF; width: 189px; height: 26px;">
                    <asp:DropDownList ID="ddlSexo" runat="server" Font-Bold="True" Height="25px" OnDataBinding="ddlSexo_DataBinding" ForeColor="#99CC00">
                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                        <asp:ListItem Value="F">Feminino</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                </td>
                <td style="color: #FFFFFF; height: 26px;">
                    <asp:Label ID="lblDtNascimento" runat="server" ForeColor="#99CC00" Text="Nascimento" Font-Bold="True"></asp:Label>
                </td>
                <td style="color: #FFFFFF; height: 26px;">
                    <asp:TextBox ID="txtDtNascimento" runat="server" Height="23px" ForeColor="#99CC00" Width="155px"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtDtNascimento_MaskedEditExtender" runat="server" MaskType="Date" TargetControlID="txtDtNascimento" Mask="99/99/9999">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="color: #FFFFFF; height: 30px;">
                    <asp:Label ID="lblFilial" runat="server" ForeColor="#99CC00" Text="Filial" Font-Bold="True"></asp:Label>
                </td>
                <td style="color: #FFFFFF; height: 30px;" colspan="3">
                    <asp:DropDownList ID="ddlFilial" runat="server" Font-Bold="True" OnDataBinding="ddlFilial_DataBinding" ForeColor="#99CC00">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="color: #FFFFFF; text-align: center; height: 23px;">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" ForeColor="#99CC00" />
                </td>
                <td style="color: #FFFFFF; text-align: center; height: 23px;" colspan="3">
                    <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btnCancelar_Click" ForeColor="#99CC00" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
