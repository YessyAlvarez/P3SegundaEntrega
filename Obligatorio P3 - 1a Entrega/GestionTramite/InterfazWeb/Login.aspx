<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InterfazWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <asp:Login ID="LoginInicio" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnAuthenticate="Login1_Authenticate" Height="130px" LoginButtonText="Ingresar">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
    </asp:Login>
    <p>
    </p>
    <br />
    <br />
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>

    <style>
        table {
            width: 20rem;
            border-color: transparent !important;
            margin: 8rem;
            background: #FFF;
            padding: 1rem;
        }

         table table {
            width: 100% !important;
            border: 3px solid #BDD3F2 !important;
        }

         table table tr:nth-child(n+1) td {
            color: #333333 !important;
            font-size: 0.8rem !important;
        }

        table table tr:nth-child(1) td {
            background: none !important;
            color: #30547F !important;
            font-size: 1.1rem !important;
        }

        table table tr {
            height: 30px;
        }
        input[type="submit"] {
            padding: 1rem;
            background-color: #DAE7F8 !important;
            border: none !important;
            cursor: pointer;
            font-size: 10pt !important;
        }
        input[type="submit"]:hover {
            background-color: #BDD3F2 !important;
        }

    </style>

</asp:Content>
