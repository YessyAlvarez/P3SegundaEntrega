<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilFMantenimiento.Master" AutoEventWireup="true" CodeBehind="EditarEtapa.aspx.cs" Inherits="InterfazWeb.PerfilFMantenimiento.EditarTramite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Editar Etapa <br />-------------</p>
    <asp:Panel ID="Panel1" runat="server">
        <p>
            Seleccionar una Etapa</p>
        <p>
            <asp:DropDownList ID="DropDownList_Etapas" runat="server" DataTextField="IdEtapa" DataValueField="IdEtapa">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="Button_Modificar_Etapa" runat="server" OnClick="Button_Modificar_Etapa_Click" Text="Modificar Etapa" />
        </p>
        <p>
        </p>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        Descripcion<br />
        <asp:TextBox ID="TextBox_Descripcion" runat="server" style="height: 22px"></asp:TextBox>
        <br />
        Lapso Maximo<br />
        <asp:TextBox ID="TextBox_Tiempo" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button_GuardarModificacion" runat="server" OnClick="Button_Guardar_Click" Text="Guardar modificación" />
        &nbsp;<asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar" />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <asp:Panel ID="Panel_Msj" runat="server">
        <br />
        <br />
        <asp:Label ID="Label_Msj" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button_EditNewEtapa" runat="server" OnClick="Button_EditNewEtapa_Click" Text="Editar otra Etapa" />
    </asp:Panel>
</asp:Content>
