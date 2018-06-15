<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ListarGrupos.aspx.cs" Inherits="InterfazWeb.Master.ListarGrupos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Listado de grupos<br />
    --------------------&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Panel ID="Panel1" runat="server" Height="102px">
    <asp:ListBox ID="ListBox_listaGrupos" runat="server" DataTextField="Nombre" DataValueField="Codigo"></asp:ListBox>
</asp:Panel>
</asp:Content>
