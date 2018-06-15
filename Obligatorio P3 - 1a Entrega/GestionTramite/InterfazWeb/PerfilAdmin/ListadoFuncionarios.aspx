<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ListadoFuncionarios.aspx.cs" Inherits="InterfazWeb.Master.ListadoFuncionarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Listado de Funcionarios<br />
    --------------------&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Panel ID="Panel1" runat="server" Height="102px">
    <asp:ListBox ID="ListBox_listaFuncionarios" runat="server" DataTextField="NombreCompleto" DataValueField="Email"></asp:ListBox>
</asp:Panel>
</asp:Content>
