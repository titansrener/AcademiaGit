<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagConsultarFiliais.aspx.cs" Inherits="UI.Consultas.pagConsultarFiliais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" ForeColor="#99CC00" />
    <br />
    <asp:GridView ID="gvwFiliais" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="odsConsultar" DataKeyNames="id" OnSelectedIndexChanged="gvwFiliais_SelectedIndexChanged" GridLines="Horizontal" Width="100%">
        <Columns>
            <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbExcluir" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Deseja realmente excluir?')">Excluir</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="descricao" HeaderText="Descricao" SortExpression="descricao" />
            <asp:BoundField DataField="endereco" HeaderText="Endereco" SortExpression="endereco" />
            <asp:BoundField DataField="nrTelefone" HeaderText="Telefone" SortExpression="nrTelefone" />
            <asp:BoundField DataField="dsBairro" HeaderText="Bairro" SortExpression="dsBairro" />
            <asp:BoundField DataField="dsEmail" HeaderText="Email" SortExpression="dsEmail" />
            <asp:BoundField DataField="VL_PRECO" HeaderText="Preco (R$)" />
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
    <br />
    <asp:ObjectDataSource ID="odsConsultar" runat="server" SelectMethod="ConsultarTodos" TypeName="BLL.FilialBLL" DeleteMethod="Excluir" OnDeleted="odsConsultar_Deleted">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>

</asp:Content>
