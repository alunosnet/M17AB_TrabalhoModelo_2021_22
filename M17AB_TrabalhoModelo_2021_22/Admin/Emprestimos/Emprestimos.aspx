<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Emprestimos.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.Admin.Emprestimos.Emprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Empréstimos</h2>
    <div class="form-check form-check-inline">
        <asp:CheckBox AutoPostBack="true" OnCheckedChanged="cbEmprestimos_CheckedChanged" CssClass="form-check-input" ID="cbEmprestimos" runat="server" />
        <label class="form-check-label" for="ContentPlaceHolder1_cbEmprestimos">Só empréstimos por concluir</label>
    </div>
    <asp:GridView CssClass="table" id="GvEmprestimos" runat="server"></asp:GridView>
    <h2>Registar empréstimo</h2>
    Livro:<asp:DropDownList CssClass="form-control" runat="server" ID="DDLivro"></asp:DropDownList>
    <br />Leitor:<asp:DropDownList CssClass="form-control" runat="server" ID="DDLeitor"></asp:DropDownList>
    <br />Data devolução:<asp:TextBox CssClass="form-control" runat="server" ID="tbData" TextMode="Date"></asp:TextBox>
    <br /><asp:Label runat="server" ID="lbErro"></asp:Label>
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" id="btAdicionar" OnClick="btAdicionar_Click" Text="Registar" />
</asp:Content>
