<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modulo 17AB</h1>
    <!--Login-->
    <div runat="server" id="divLogin" class="float-right col-sm-3 table-bordered divLogin" style="z-index:1">
    Email:<asp:TextBox CssClass="form-control" placeholder="Email" runat="server" ID="tbEmail" TextMode="Email" />
    Password:<asp:TextBox CssClass="form-control" runat="server" ID="tbPassword" TextMode="Password" />
    <asp:Label ID="lbErro" runat="server" />
    <asp:Button CssClass="btn btn-info" OnClick="btLogin_Click" runat="server" Text="Login" ID="btLogin" />
    <asp:Button CssClass="btn btn-danger" OnClick="btRecuperar_Click" runat="server" Text="Recuperar" ID="btRecuperar" />
    </div>
    <!--Pesquisa-->
    
    <!--Lista dos livros-->

</asp:Content>
