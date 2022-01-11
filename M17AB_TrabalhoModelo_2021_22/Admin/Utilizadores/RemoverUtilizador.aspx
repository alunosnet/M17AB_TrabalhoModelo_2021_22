<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="RemoverUtilizador.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.Admin.Utilizadores.RemoverUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Remover utilizador</h2>
    <br />
    Nome: <asp:Label ID="lbNome" runat="server" Text=""></asp:Label><br />
    ID do utilizador: <asp:Label ID="lbId" runat="server" Text=""></asp:Label><br/>
    <asp:Button ID="btnRemover" 
        runat="server" 
        CssClass="btn btn-lg btn-danger" 
        Text="Remover" OnClick="btnRemover_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" 
        runat="server" 
        ID="btVoltar" 
        Text="Voltar" 
        PostBackUrl="~/Admin/Utilizadores/utilizadores.aspx"/>
</asp:Content>
