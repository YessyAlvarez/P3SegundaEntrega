<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilFMantenimiento.Master" AutoEventWireup="true" CodeBehind="ABMTramite.aspx.cs" Inherits="InterfazWeb.PerfilFMantenimiento.ABMTramite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:Button ID="ButtonAltaTramite" runat="server" OnClick="ButtonAltaTramite_Click" Text="Alta Tramite" />
    </p>
    <p>
        <asp:Button ID="ButtonEditarTramite" runat="server" OnClick="ButtonEditarTramite_Click" Text="Editar Tramite" />
    </p>
    <p>
    </p>
</asp:Content>
