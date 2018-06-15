<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="GuardarEnTxt.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.GuardarEnTxt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Button ID="Button_Grupos" runat="server" Text="Guardar Grupos" OnClick="Button_Grupos_Click" />
    </p>
    <p>
        <asp:Button ID="Button_Funcionarios" runat="server" Text="Guardar Funcionarios" OnClick="Button_Funcionarios_Click" />
    </p>
    <p>
        <asp:Button ID="Button_Tramites" runat="server" Text="Guardar Tramites" OnClick="Button_Tramites_Click" />
    </p>
    <p>
        <asp:Label ID="Label_Msj" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
