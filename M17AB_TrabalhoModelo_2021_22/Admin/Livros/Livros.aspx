<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Livros.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.Admin.Livros.Livros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista Livros</h2>
    <asp:GridView runat="server" ID="GvLivros" CssClass="table" />
    <h2>Adicionar Livro</h2>
    <!--Nome-->
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox MaxLength="100" placeholder="Nome do livro" 
            CssClass="form-control" runat="server" ID="tbNome"></asp:TextBox>
    </div>
    <!--Ano-->
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbAno">Ano:</label>
        <asp:TextBox TextMode="Number" placeholder="Ano de edição" 
            CssClass="form-control" runat="server" ID="tbAno"></asp:TextBox>
    </div>
    <!--Data aquisição-->
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbData">Data Aquisição:</label>
        <asp:TextBox TextMode="Date" 
            CssClass="form-control" runat="server" ID="tbData"></asp:TextBox>
    </div>
    <!--Preço-->
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbPreco">Preço:</label>
        <asp:TextBox  placeholder="Preço do livro" 
            CssClass="form-control" runat="server" ID="tbPreco"></asp:TextBox>
    </div>
    <!--Autor-->
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbAutor">Autor:</label>
        <asp:TextBox MaxLength="100" placeholder="Autor do livro" 
            CssClass="form-control" runat="server" ID="tbAutor"></asp:TextBox>
    </div>
    <!--Tipo-->
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbTipo">Tipo:</label>
        <asp:TextBox MaxLength="50" placeholder="Tipo de livro" 
            CssClass="form-control" runat="server" ID="tbTipo"></asp:TextBox>
    </div>
    <!--Capa-->
    <div class="form-group">
        <label for="ContentPlaceHolder1_fuCapa">Capa:</label>
        <asp:FileUpload runat="server" ID="fuCapa" CssClass="form-control-file" />
    </div>
    <asp:Label runat="server" id="lbErro"></asp:Label>
    <br />
    <asp:Button runat="server" ID="btAdicionar" Text="Adicionar" 
        CssClass="btn btn-align-content-lg-around btn-danger"
        OnClick="btAdicionar_Click"/>
</asp:Content>
