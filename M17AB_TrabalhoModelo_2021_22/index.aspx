<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modulo 17AB</h1>
    <!--Login-->
    <div>
    Email:<asp:TextBox placeholder="Email" runat="server" ID="tbEmail" TextMode="Email" />
    Password:<asp:TextBox runat="server" ID="tbPassword" TextMode="Password" />
    <asp:Label ID="lbErro" runat="server" />
    <asp:Button OnClick="btLogin_Click" runat="server" Text="Login" ID="btLogin" />
    <asp:Button OnClick="btRecuperar_Click" runat="server" Text="Recuperar" ID="btRecuperar" />
    </div>
    <!--Pesquisa-->
    
    <!--Lista dos livros-->

</asp:Content>
