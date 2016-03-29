<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagConsultarMensalidadesAbertas.aspx.cs" Inherits="UI.Matriculas.pagConsultarMensalidadesAbertas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="color: #99CC00">Mensalidades em Aberto</legend>
        <table style="width: 100%">
            <tr>
                <td style="width: 86px">
                    <asp:Label ID="lblFilial" runat="server" ForeColor="#99CC00" Text="Filial"></asp:Label>
                </td>
                <td style="width: 204px">
                    <asp:DropDownList ID="ddlFilial" runat="server" ForeColor="#99CC00" OnDataBinding="ddlFilial_DataBinding" OnSelectedIndexChanged="ddlFilial_SelectedIndexChanged" DataSourceID="odsFilial" DataTextField="descricao" DataValueField="id" AppendDataBoundItems="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvFilial" runat="server" ControlToValidate="ddlFilial" ErrorMessage="RequiredFieldValidator" ForeColor="#99CC00" ToolTip="Campo Obrigatório">*</asp:RequiredFieldValidator>
                    <asp:ObjectDataSource ID="odsFilial" runat="server" SelectMethod="ConsultarTodasFiliais" TypeName="BLL.FilialBLL"></asp:ObjectDataSource>
                </td>
                <td>
                    <asp:Button ID="btnPesquisar" runat="server" ForeColor="#99CC00" OnClick="btnPesquisar_Click" Text="Pesquisar" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="grvMensalidadesAbertas" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:TemplateField HeaderText="Aluno" SortExpression="id">
                    <ItemTemplate>
                        <asp:Label ID="lblAluno" runat="server" Text='<%# Bind("ALUNO.nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NU_PARCELA" HeaderText="Parcela" />
                <asp:BoundField DataField="DT_VENCIMENTO" HeaderText="Data Vencimento" DataFormatString="{0:d}" />
                <asp:BoundField DataField="DT_PAGAMENTO" HeaderText="Data Pagamento" />
                <asp:BoundField DataField="ST_TITULO" HeaderText="Situação" />
                <asp:BoundField DataField="VL_TITULO" HeaderText="Valor (R$)" />
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
    </fieldset>
</asp:Content>
