<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ABMGrupos.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.ABMGrupos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <p>
        <br />
    </p>
    <p>
        <asp:Button ID="ButtonAltaGrupo" runat="server" OnClick="ButtonAltaGrupo_Click" Text="Alta Grupo" />
    </p>
    <p>
        <asp:Button ID="ButtonEditarGrupo" runat="server" OnClick="ButtonEditarGrupo_Click" Text="Editar Grupo" />
    </p>
    <p>
        <asp:Button ID="ButtonEliminarGrupo" runat="server" OnClick="ButtonEliminarGrupo_Click" Text="Eliminar Grupo" />
    </p>
    <p>
        <br />
    </p>


</asp:Content>
