<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagMatricularAlunos.aspx.cs" Inherits="UI.Matriculas.pagMatricularAlunos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="color: #99CC00">Matrícula</legend>
        <table style="width: 100%">
            <tr>
                <td style="width: 135px; color: #66CCFF;">
                    <asp:Label ID="lblAluno" runat="server" ForeColor="#99CC00" Text="Aluno"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlAlunos" runat="server" DataSourceID="obsAlunos" DataTextField="nome" DataValueField="id" OnDataBinding="ddlAlunos_DataBinding" AppendDataBoundItems="True" ForeColor="#99CC00">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvAluno" runat="server" ControlToValidate="ddlAlunos" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                    <asp:ObjectDataSource ID="obsAlunos" runat="server" SelectMethod="ConsultarAlunosNMatriculados" TypeName="BLL.AlunoBLL"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 135px">
                    <asp:Label ID="lblAno" runat="server" ForeColor="#99CC00" Text="Ano"></asp:Label>
                </td>
                <td style="width: 346px">
                    <asp:TextBox ID="txtAno" runat="server" ReadOnly="True" ForeColor="#99CC00" MaxLength="4"></asp:TextBox>
                </td>
                <td style="width: 99px">
                    <asp:Label ID="lblPagamento" runat="server" ForeColor="#99CC00" Text="Pagamento"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblDiaPagamento" runat="server" ForeColor="#99CC00" RepeatDirection="Horizontal" Width="181px">
                        <asp:ListItem Value="5" Selected="True">Dia 5</asp:ListItem>
                        <asp:ListItem Value="20">Dia 20</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 135px">
                    <asp:Label ID="lblParcela" runat="server" ForeColor="#99CC00" Text="Parcela"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlParcelas" runat="server" OnDataBinding="ddlParcelas_DataBinding" ForeColor="#99CC00" AppendDataBoundItems="True">
                        <asp:ListItem Value=" ">Selecione</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvParcela" runat="server" ControlToValidate="ddlParcelas" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 135px">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" ForeColor="#99CC00" />
                </td>
                <td colspan="3">
                    <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btnCancelar_Click" ForeColor="#99CC00" />
                    <asp:Label ID="lblStatus" runat="server" ForeColor="#99CC00"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
