<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="AltaFuncionario.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.AltaFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <p>
            Alta Funcionario
             <br />-----------------
        </p>
        <asp:Panel ID="PanelStep_Datos" runat="server">
            <asp:LinkButton ID="LinkButton_1_1_Datos" runat="server" OnClick="LinkButton_1_1_Datos_Click">1. Datos del Usuario</asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton_1_2_Grupos" runat="server" OnClick="LinkButton_1_2_Grupos_Click">2. Asignar a grupos</asp:LinkButton>
            <br />
            <br />
            <br />
            Ingrese los datos de un Funcionario:<br />
            <br />
            <br />
            Email:<br />
            <asp:TextBox ID="TextBox_Email" runat="server"></asp:TextBox>
            <asp:Label ID="Label_ErrorEmail" runat="server"></asp:Label>
            <br />
            Password:<br />
            <asp:TextBox ID="TextBox_Password" runat="server"></asp:TextBox>
            <asp:Label ID="Label_ErrorPassword" runat="server"></asp:Label>
            <br />
            Nombre Completo<br />
            <asp:TextBox ID="TextBox_NombreCompleto" runat="server"></asp:TextBox>
            <asp:Label ID="Label_ErrorNombre" runat="server"></asp:Label>
            <br />
            Perfil<br />
            <asp:DropDownList ID="DropDownList_Perfil" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="Button_Siguiente" runat="server" Text="Siguiente" OnClick="ButtonSiguiente_Click" />
        </asp:Panel>
        <p>&nbsp;</p>
        <asp:Panel ID="PanelStep_Grupos" runat="server">
            <br />
            <asp:LinkButton ID="LinkButton_2_1_Datos" runat="server" OnClick="LinkButton_2_1_Datos_Click">1. Datos del Usuario</asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton_2_2_Datos" runat="server" OnClick="LinkButton_2_2_Datos_Click">2. Asignar a grupos</asp:LinkButton>
            <br />
            <br />
            <br />
            Seleccione un Grupo para asignarlo al usuario<br />
            <br />
            Grupo<br />
            <asp:DropDownList ID="DropDownList_Grupos" runat="server" DataTextField="Nombre" DataValueField="Codigo">
            </asp:DropDownList>
            &nbsp;<asp:Button ID="Button_AsignarAGrupo" runat="server" OnClick="Button_AsignarAGrupo_Click" Text="Asignar a Grupo" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label_MsjSinGrupos" runat="server"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox_GruposAsignados" runat="server"></asp:ListBox>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button_Anterior" runat="server" Text="Anterior" OnClick="Button_Anterior_Click" />
            <br />
            <asp:Button ID="Button_AltaFuncionario" runat="server" Text="Agregar nuevo Funcionario" OnClick="Button_AltaFuncionario_Click" />
            <br />
            <br />
        </asp:Panel>
        <p>
        </p>
        <asp:Panel ID="PanelStep_Mensaje" runat="server">
            <br />
            <asp:Label ID="Label_MsjFinal" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button_NewAddProveedor" runat="server" Text="Agregar otro Funcionario" OnClick="Button_NewAddProveedor_Click" />
            <br />
        </asp:Panel>
        <p>
        </p>
        <p>
        </p>
    
</asp:Content>