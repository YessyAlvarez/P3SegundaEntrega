<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilFMantenimiento.Master" AutoEventWireup="true" CodeBehind="ABMEtapa.aspx.cs" Inherits="InterfazWeb.PerfilFMantenimiento.ABMEtapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:Button ID="Button_CrearEtapa" runat="server" OnClick="Button_CrearEtapa_Click" Text="Crear Etapa" />
    </p>
    <p>
        <asp:Button ID="Button_EditarEtapa" runat="server" OnClick="Button_EditarEtapa_Click" Text="Editar Etapa" />
    </p>
    <p>
    </p>
</asp:Content>
