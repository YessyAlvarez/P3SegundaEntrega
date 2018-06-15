<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilFMantenimiento.Master" AutoEventWireup="true" CodeBehind="EditarTramite.aspx.cs" Inherits="InterfazWeb.Master.EditarTramite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Editar Tramite <br /> ---------------
    </p>
    <asp:Panel ID="Panel1" runat="server">
        Seleccionar un Tramite<br />
        <asp:DropDownList ID="DropDownList_Tramite" runat="server" DataTextField="Titulo" DataValueField="Id">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button_Modificar_Tramite" runat="server" OnClick="Button_Modificar_Etapa_Click" Text="Modificar" />
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <br />
        Descripcion<br />&nbsp;<asp:TextBox ID="TextBox_Descripcion" runat="server"></asp:TextBox>
        <br />
        Costo<br />
        <asp:TextBox ID="TextBox_Costo" runat="server"></asp:TextBox>
        <br />
        Tiempo<br />
        <asp:TextBox ID="TextBox_Tiempo" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Guardar" runat="server" OnClick="Button_Guardar_Click" Text="Guardar modificación" />
        &nbsp; &nbsp;<asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar" />
    </asp:Panel>
</asp:Content>
