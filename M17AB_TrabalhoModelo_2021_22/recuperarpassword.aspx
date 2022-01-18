<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="recuperarpassword.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.recuperarpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Recuperação da palavra passe</h2>
    Nova palavra passe:<asp:TextBox runat="server" ID="tbPassword" TextMode="Password" />
    <br />
    <asp:Button runat="server" ID="btRecuperar" 
        OnClick="btRecuperar_Click" Text="Atualizar a password" />
    <asp:Label runat="server" ID="lbErro"></asp:Label>
</asp:Content> 
