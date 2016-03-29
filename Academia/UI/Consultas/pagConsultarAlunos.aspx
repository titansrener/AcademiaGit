<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagConsultarAlunos.aspx.cs" Inherits="UI.Consultas.pagConsultarAlunos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" ForeColor="#99CC00" />
    <asp:GridView ID="gvwAlunos" runat="server" AutoGenerateColumns="False" DataSourceID="odsAlunos" OnRowDataBound="gvwAlunos_RowDataBound" DataKeyNames="id" OnSelectedIndexChanged="gvwAlunos_SelectedIndexChanged" CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" Width="100%">
        <Columns>
            <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
            <asp:TemplateField HeaderText="Excluir">
                <ItemTemplate>
                    <asp:LinkButton ID="lkbExcluir" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Deseja realmente excluir?')">Excluir</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome" />
            <asp:BoundField DataField="nrCPF" HeaderText="CPF" SortExpression="nrCPF" />
            <asp:BoundField DataField="nrCelular" HeaderText="Celular" SortExpression="nrCelular" />
            <asp:BoundField DataField="endereco" HeaderText="Endereço" SortExpression="endereco" />
            <asp:TemplateField HeaderText="Sexo" SortExpression="sexo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("sexo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="dtNascimento" DataFormatString="{0:d}" HeaderText="Nascimento" SortExpression="dtNascimento" />
            <asp:TemplateField HeaderText="Academia" SortExpression="idFilial">
                <ItemTemplate>
                    <asp:Label ID="lblAcademia" runat="server" Text='<%# Bind("FILIAL.descricao") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:ObjectDataSource ID="odsAlunos" runat="server" SelectMethod="ConsultarTodosAlunos" TypeName="BLL.AlunoBLL" DataObjectTypeName="CLASSES.Aluno" DeleteMethod="Excluir" OnDeleted="odsAlunos_Deleted"></asp:ObjectDataSource>
</asp:Content>
