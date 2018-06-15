<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="EliminarGrupo.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.EliminarGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Eliminar un Grupo<br />-----------------------</p>
    <p>
    </p>
    <asp:Panel ID="PanelBuscarGrupo" runat="server">
        <br />
        Seleccione un grupo para eliminar:<br />
        <asp:DropDownList ID="DropDownListGruposAEliminar" runat="server" DataTextField="Nombre" DataValueField="Codigo">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button_Eliminar_Grupo" runat="server" OnClick="Button_Eliminar_Grupo_Click" Text="Eliminar este grupo" />
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="PanelDatosGrupo" runat="server">
        <br />
        Id:
        <asp:Label ID="Label_Id" runat="server"></asp:Label>
        <br />
        Nombre Grupo:
        <asp:Label ID="LabelNombre" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        ¿Seguro desea eliminar este grupo?<br />
        <br />
        <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminarProveedor_Click" />
        <br />
        <br />
        <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" />
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <asp:Panel ID="PanelMensaje" runat="server">
        <br />
        <br />
        <asp:Label ID="LabelMensaje" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Eliminar_Otro" runat="server" OnClick="Button_Eliminar_Otro_Click" Text="Eliminar otro grupo" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
