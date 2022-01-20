<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="utilizadores.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.Admin.Utilizadores.utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Utilizadores</h2>
    <asp:GridView CssClass="table" ID="gvUtilizadores" runat="server"></asp:GridView>
    <h2>Adicionar</h2>
    Email:<asp:TextBox CssClass="form-control" runat="server" ID="tbEmail"></asp:TextBox>
    <br />Nome:<asp:TextBox CssClass="form-control" runat="server" ID="tbNome"></asp:TextBox>
    <br />Morada:<asp:TextBox CssClass="form-control" runat="server" ID="tbMorada"></asp:TextBox>
    <br />Nif:<asp:TextBox CssClass="form-control" runat="server" ID="tbNif"></asp:TextBox>
    <br />Palavra Passe:<asp:TextBox CssClass="form-control" TextMode="Password" runat="server" ID="tbPassword"></asp:TextBox>
    <br />Perfil:
    <asp:DropDownList CssClass="form-control" ID="ddPerfil" runat="server">
        <asp:ListItem Value="0">Administrador</asp:ListItem>
        <asp:ListItem Value="1">Utilizador</asp:ListItem>
    </asp:DropDownList>
    <br /><asp:Button CssClass="btn btn-lg btn-danger" OnClick="btAdicionar_Click" runat="server" ID="btAdicionar" Text="Adicionar" />
    <br /><asp:Label runat="server" ID="lbErro" Text="" />
</asp:Content>
