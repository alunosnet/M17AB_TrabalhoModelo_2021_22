<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="RemoverLivro.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.Admin.Livros.RemoverLivro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Confirmar apagar livro</h1>
    Nº Livro:<asp:Label CssClass="form-control" runat="server" id="lbNLivro"></asp:Label>
    <br />Nome:<asp:Label CssClass="form-control" runat="server" id="lbNome"></asp:Label>
    <br />Capa:<br /><asp:Image CssClass="figure-img" runat="server" id="imgCapa"></asp:Image>
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btRemover" Text="Remover"
        OnClick="btRemover_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btVoltar" Text="Voltar" 
        PostBackUrl="~/Admin/Livros/Livros.aspx"/>
    <asp:Label runat="server" id="lbErro"></asp:Label>

</asp:Content>
