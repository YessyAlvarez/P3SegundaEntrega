<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="EditarFuncionario.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.EditarFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Editar Funcionario<br />
        -------------------
    </p>
    <asp:Panel ID="Panel_BuscadorPorID" runat="server">
        Ingrese email funcionario<br />
        <asp:TextBox ID="Text_EmailBuscar" runat="server"></asp:TextBox>
        <asp:Label ID="Label_ErrorEmail" runat="server"></asp:Label>
        <br />
        <asp:Button ID="ButtonBuscarFuncionario" runat="server" OnClick="ButtonBuscarFuncionario_Click" Text="Buscar Funcionario" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="Panel_ResultadoFuncionario" runat="server">
        Email:
        <asp:Label ID="Label_Email" runat="server"></asp:Label>
        <br />
        Nombre completo<br />
        <asp:TextBox ID="TextBoxNombreCompleto" runat="server"></asp:TextBox>
        <asp:Label ID="Label_ErrorNombre" runat="server"></asp:Label>
        <br />
        Contraseña<br />
        <asp:TextBox ID="TextBoxContrasenia" runat="server"></asp:TextBox>
        <asp:Label ID="Label_ErrorPass" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button_GuardarCambios" runat="server" OnClick="Button_GuardarCambios_Click1" Text="Guardar" />
        <br />
        <br />
    </asp:Panel>
    <p>
        &nbsp;</p>
    <asp:Panel ID="Panel_Mensaje" runat="server">
        <br />
        <asp:Label ID="LabelMensaje" runat="server" Text=" "></asp:Label>
        <asp:Label ID="Label_Msj" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button_NewEdit" runat="server" OnClick="Button_NewEdit_Click" Text="Editar otro funcionario" />
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
