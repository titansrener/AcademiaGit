<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagConsultarMensalidades.aspx.cs" Inherits="UI.Matriculas.pagConsultarMensalidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnNovo" runat="server" Text="Novo" CausesValidation="False" ForeColor="#99CC00" OnClick="btnNovo_Click" />
    <Fieldset>
        <legend style="color: #99CC00">Mensalidades</legend>
        <table style="width: 100%">
            <tr>
                <td style="width: 83px">
                    <asp:Label ID="lblAluno" runat="server" Text="Aluno" ForeColor="#99CC00"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlAlunos" runat="server" AppendDataBoundItems="True" DataSourceID="odsAlunos" DataTextField="nome" DataValueField="id" OnDataBinding="ddlAlunos_DataBinding" ForeColor="#99CC00">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvAluno" runat="server" ControlToValidate="ddlAlunos" ErrorMessage="RequiredFieldValidator" ToolTip="Campo obrigatório" ForeColor="#99CC00">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 83px">
                    <asp:Label ID="lblAno" runat="server" Text="Ano" ForeColor="#99CC00"></asp:Label>
                </td>
                <td style="width: 323px">
                    <asp:TextBox ID="txtAno" runat="server" MaxLength="4" ForeColor="#99CC00"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAno" runat="server" ControlToValidate="txtAno" ErrorMessage="RequiredFieldValidator" ToolTip="Campo obrigatório" ForeColor="#99CC00">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revAno" runat="server" ControlToValidate="txtAno" ErrorMessage="RegularExpressionValidator" ToolTip="Somente números" ValidationExpression="[0-9]+" ForeColor="#99CC00">*</asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" ForeColor="#99CC00" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="margin-left: 80px">
                    <asp:GridView ID="grvMensalidades" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" DataKeyNames="ID_TITULO" OnSelectedIndexChanged="grvMensalidades_SelectedIndexChanged" OnRowDataBound="grvMensalidades_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="DT_VENCIMENTO" DataFormatString="{0:d}" HeaderText="Data de Vencimento" />
                            <asp:BoundField DataField="NU_PARCELA" HeaderText="Parcela" />
                            <asp:BoundField DataField="VL_TITULO" HeaderText="Valor (R$)" />
                            <asp:BoundField DataField="DT_PAGAMENTO" DataFormatString="{0:d}" HeaderText="Data de Pagamento" />
                            <asp:TemplateField HeaderText="Valor multa (R$)">
                                <ItemTemplate>
                                    <asp:Label ID="lblMulta" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:CommandField ButtonType="Button" SelectText="Pagar" ShowSelectButton="True" >
                            
                            <ControlStyle ForeColor="#99CC00" />
                            </asp:CommandField>
                            
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsAlunos" runat="server" SelectMethod="ConsultarTodosAlunos" TypeName="BLL.AlunoBLL"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 83px">
                    &nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
    </Fieldset>
</asp:Content>
