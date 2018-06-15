<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilFMantenimiento.Master" AutoEventWireup="true" CodeBehind="CrearEtapa.aspx.cs" Inherits="InterfazWeb.PerfilFMantenimiento.CrearEtapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Crear Etapa<br />-------------
    </p>
    <asp:Panel ID="Panel_CrearEtapa" runat="server">
        <br />
        Codigo<br />
        <asp:TextBox ID="TextBox_Codigo" runat="server"></asp:TextBox>
        <asp:Label ID="Label_CodigoError" runat="server"></asp:Label>
        <br />
        Descripcion<br />
        <asp:TextBox ID="TextBox_Descripcion" runat="server" style="height: 22px"></asp:TextBox>
        <asp:Label ID="Label_DescError" runat="server"></asp:Label>
        <br />
        Lapso maximo<br />
        <asp:TextBox ID="TextBox_Tiempo" runat="server" ></asp:TextBox>
        <asp:Label ID="Label_LapsoError" runat="server"></asp:Label>
        <br />
        Tramite al que pertenece esta Etapa<br />
        <asp:DropDownList ID="DropDownList_Tramites" runat="server" DataTextField="Titulo" DataValueField="Id">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button_CrearEtapa" runat="server" OnClick="Button_CrearEtapa_Click" Text="Crear Etapa" />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <asp:Panel ID="Panel_Msj" runat="server">
        <br />
        <asp:Label ID="Label_Msj" runat="server"></asp:Label>
        &nbsp;<br />
        <br />
        <asp:Button ID="Button_NewEtapa" runat="server" OnClick="Button_NewEtapa_Click" Text="Crear nueva Etapa" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
