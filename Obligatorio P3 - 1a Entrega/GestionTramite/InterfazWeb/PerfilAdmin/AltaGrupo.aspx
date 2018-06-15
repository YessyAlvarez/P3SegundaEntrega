<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="AltaGrupo.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.AltaGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Alta Grupo
        <br />
        -------------</p>
    <p>
        </p>
    <asp:Panel ID="PanelAdd" runat="server">
        Nombre
        <br />
        <asp:TextBox ID="TextBox_NombreGrupo" runat="server"></asp:TextBox>
        <asp:Label ID="Label_MsjError" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Alta_crearGrupo" runat="server" OnClick="Alta_crearGrupo_Click" Text="Crear Grupo" />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="PanelMsj" runat="server">
        <br />
        <asp:Label ID="LabelMensaje" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonNewGrupo" runat="server" Text="Crear nuevo grupo" OnClick="ButtonNewGrupo_Click" />
    </asp:Panel>
    <p>
        &nbsp;</p>
</asp:Content>
