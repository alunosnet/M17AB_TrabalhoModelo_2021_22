﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="M17AB_TrabalhoModelo_2021_22.User.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divPerfil">
        Nome:<asp:Label runat="server" ID="lbNome" />
        <br />Morada:<asp:Label CssClass="form-control" runat="server" ID="lbMorada" />
        <br />Nif:<asp:Label CssClass="form-control" runat="server" ID="lbNif" />
        <br /><asp:Button CssClass="btn btn-lg btn-danger" OnClick="btEditar_Click" runat="server" ID="btEditar" Text="Editar" />
    </div>
    <div runat="server" id="divEditar">
        Nome:<asp:TextBox CssClass="form-control" runat="server" ID="tbNome" />
        <br />Morada:<asp:TextBox CssClass="form-control" runat="server" ID="tbMorada" />
        <br />Nif:<asp:TextBox CssClass="form-control" runat="server" ID="tbNif" />
        <br /><asp:Button CssClass="btn btn-lg btn-danger" OnClick="btAtualizar_Click" runat="server" ID="btAtualizar" Text="Atualizar" />
        <br /><asp:Button CssClass="btn btn-lg btn-info" OnClick="btCancelar_Click" runat="server" ID="btCancelar" Text="Cancelar" />
    </div>
</asp:Content>
