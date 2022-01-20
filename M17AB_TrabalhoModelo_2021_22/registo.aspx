<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Email:<asp:TextBox runat="server" ID="tbEmail"></asp:TextBox>
    <br />Nome:<asp:TextBox runat="server" ID="tbNome"></asp:TextBox>
    <br />Morada:<asp:TextBox runat="server" ID="tbMorada"></asp:TextBox>
    <br />Nif:<asp:TextBox runat="server" ID="tbNif"></asp:TextBox>
    <br />Palavra Passe:<asp:TextBox TextMode="Password" runat="server" ID="tbPassword"></asp:TextBox>
    <br /><asp:Label ID="lbErro" runat="server" />
    <!--Recaptcha-->
    <div class="g-recaptcha" 
        data-sitekey="6LepgmgdAAAAAEvfiS0Xdhh1S-i1Py8w8VBiuViE"></div>
    <!--Recaptcha-->
    <asp:Button runat="server" ID="btRegistar" Text="Registar" OnClick="btRegistar_Click" />
</asp:Content>
