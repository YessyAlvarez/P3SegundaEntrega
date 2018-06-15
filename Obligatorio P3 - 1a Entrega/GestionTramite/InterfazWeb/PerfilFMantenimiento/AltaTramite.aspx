<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilFMantenimiento.Master" AutoEventWireup="true" CodeBehind="AltaTramite.aspx.cs" Inherits="InterfazWeb.PerfilFMantenimiento.AltaTramite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Alta Tramite<br />-------------
    </p>
    <p>
    </p>
<asp:Panel ID="Panel_Paso1" runat="server">
    <asp:LinkButton ID="LinkButton_1_datos" runat="server" OnClick="LinkButton_1_datos_Click">1. Ingresar datos del tramite</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton_2_add_grupos" runat="server" OnClick="LinkButton_2_add_grupos_Click">2. Asignar Grupos</asp:LinkButton>
    <br />
    <br />
    Titulo<br />
    <asp:TextBox ID="TextBox_Titulo" runat="server"></asp:TextBox>
    <asp:Label ID="Label_Titulo_Error" runat="server"></asp:Label>
    <br />
    Descripcion<br />
    <asp:TextBox ID="TextBox_Descripcion" runat="server"></asp:TextBox>
    <asp:Label ID="Label_Desc_Error" runat="server"></asp:Label>
    <br />
    Costo<br />
    <asp:TextBox ID="TextBox_Costo" runat="server"></asp:TextBox>
    <asp:Label ID="Label_Costo_Error" runat="server"></asp:Label>
    <br />
    Tiempo de ejecución (dias)<br />
    <asp:TextBox ID="TextBox_Tiempo" runat="server"></asp:TextBox>
    <asp:Label ID="Label_Tiempo_Error" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button_Siguiente" runat="server" OnClick="Button_Siguiente_Click" Text="Siguiente" />
    <br />
</asp:Panel>
<p>
    </p>
<p>
    </p>
<asp:Panel ID="Panel_Paso2" runat="server">
    <asp:LinkButton ID="LinkButton_1_datos_P2" runat="server" OnClick="LinkButton_1_datos_P2_Click">1. Ingresar datos del tramite</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton_2_add_gruposP2" runat="server" OnClick="LinkButton_2_add_gruposP2_Click">2. Asignar Grupos</asp:LinkButton>
    <br />
    <br />
    Seleccione un grupo<br />
    <asp:DropDownList ID="DropDownList_Grupos" runat="server" DataTextField="Nombre" DataValueField="Codigo">
    </asp:DropDownList>
    <br />
    Descripcion<br />
    <asp:TextBox ID="TextBox_DescripcionGrupo" runat="server"></asp:TextBox>
    <asp:Label ID="Label_DescGrupo_Error" runat="server"></asp:Label>
    <br />
    Cantidad Maxima de funcionarios<br />
    <asp:TextBox ID="TextBox_MaxFunc" runat="server"></asp:TextBox>
    <asp:Label ID="Label_CantGrupo_Error" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button_AgregarGrupo" runat="server" OnClick="Button_AgregarGrupo_Click" Text="Agregar Grupo" />
    &nbsp;
    <br />
    <br />
    <br />
    <asp:Label ID="Label_Msj_SinGrupos" runat="server"></asp:Label>
    <br />
    <asp:ListBox ID="ListBox_GruposAgregados" runat="server" DataTextField="Descripcion" DataValueField="IdGrupoTramite"></asp:ListBox>
    <br />
    <br />
    <asp:Button ID="Button_NewTramite" runat="server" OnClick="Button_NewTramite_Click" Text="Crear Tramite" />
    &nbsp;<asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar" />
    <br />
</asp:Panel>
<p>
    </p>
<p>
    </p>
<asp:Panel ID="Panel_Msj" runat="server">
    <br />
    <asp:Label ID="Label_Msj" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button_NuevoTramite" runat="server" OnClick="Button_NuevoTramite_Click" Text="Agregar nuevo Tramite" />
    <br />
</asp:Panel>
<p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
