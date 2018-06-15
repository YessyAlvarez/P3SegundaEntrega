<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Inicio.Master" AutoEventWireup="true" CodeBehind="InicioWeb.aspx.cs" Inherits="InterfazWeb.InicioWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="textIntroductorio">
        En esta oficina se definen los trámites que en un futuro serán utilizados 
        por la oficina de Gestión de Expedientes de la Junta.
    </div>
    <div class="Accesos">
        <div class="bottonLink">
             <asp:LinkButton ID="LinkButtonAltaGrupo" runat="server" OnClick="AltaGrupo_Click">Alta de Grupo</asp:LinkButton>
        </div>
        <div class="bottonLink">
             <asp:LinkButton ID="LinkButtonLogin" runat="server" OnClick="Login_Click">Login</asp:LinkButton>
        </div>
    </div>

</asp:Content>
