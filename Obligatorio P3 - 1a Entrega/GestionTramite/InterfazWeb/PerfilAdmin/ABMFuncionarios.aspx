<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ABMFuncionarios.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.ABMFuncionarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <p>
        <br />
    </p>
    <p>
        <asp:Button ID="ButtonAltaFuncionario" runat="server" OnClick="ButtonAltaFuncionario_Click" Text="Alta Funcionario" />
    </p>
    <p>
        <asp:Button ID="ButtonEditarFuncionario" runat="server" OnClick="ButtonEditarFuncionario_Click" Text="Editar Funcionario" />
    </p>
      <p>
        <br />
    </p>


</asp:Content>
