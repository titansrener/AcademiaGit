<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagPagamentoMensalidades.aspx.cs" Inherits="UI.Matriculas.pagPagamentoMensalidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="color: #99CC00">Pagamento</legend>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblAluno" runat="server" Text="Aluno" ForeColor="#99CC00"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAluno" runat="server" ReadOnly="True" ForeColor="#99CC00"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblAno" runat="server" Text="Ano" ForeColor="#99CC00"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAno" runat="server" ReadOnly="True" ForeColor="#99CC00"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblParcela" runat="server" Text="Parcela" ForeColor="#99CC00"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtParcela" runat="server" ReadOnly="True" ForeColor="#99CC00"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblVencimento" runat="server" Text="Vencimento" ForeColor="#99CC00"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVencimento" runat="server" ReadOnly="True" ForeColor="#99CC00"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblValor" runat="server" Text="Valor" ForeColor="#99CC00"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtValor" runat="server" ReadOnly="True" ForeColor="#99CC00"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblMulta" runat="server" Text="Valor Multa (R$)" ForeColor="#99CC00"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtValorMulta" runat="server" ReadOnly="True" ForeColor="#99CC00"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotal" runat="server" Text="Total" ForeColor="#99CC00"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" ForeColor="#99CC00"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="btnPagar" runat="server" OnClick="btnPagar_Click" Text="Realizar Pagamento" ForeColor="#99CC00" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
