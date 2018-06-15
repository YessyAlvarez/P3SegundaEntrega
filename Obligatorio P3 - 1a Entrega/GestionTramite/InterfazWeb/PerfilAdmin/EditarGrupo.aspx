<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="EditarGrupo.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.EditarGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Editar Grupo<br />
    --------------------<br />
    <asp:Panel ID="Panel_Seleccion_Grupo" runat="server">
        <br />
        Seleccione un Grupo:
        <asp:DropDownList ID="DropDownList_Grupos" runat="server" Width="72px" DataTextField="Nombre" DataValueField="Codigo">
        </asp:DropDownList>

        <br />
        <asp:Button ID="Button_Editar_Grupo" runat="server" OnClick="Button_Editar_Grupo_Click" Text="Editar Grupo" />

        <br />
        <br />
        ! Falta controlar que el nombre no se repita!!!<br />
        <br />
    </asp:Panel>
    <p></p>
    <asp:Panel ID="Panel_Edicion_Grupo" runat="server">
        <br />
        Id:
        <asp:Label ID="Label_CodigoGrupo" runat="server"></asp:Label>
        <br />
        Nombre:
        <asp:TextBox ID="TextBox_Nombre_Grupo" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button_Guardar" runat="server" Text="Guardar cambios" OnClick="Button_Guardar_Click" />
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar" />
        <br />
        <br />
    </asp:Panel>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
   



</asp:Content>
