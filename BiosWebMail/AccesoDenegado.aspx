<%@ Page Title="Acceso Denegado" Language="C#" MasterPageFile="~/Masters/Site.Master"
    AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="BiosWebMail.Registro" %>

<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <cc1:Header ID="Header" HEADER_TEXT="Acceso Denegado" IMAGE_URL="~/Images/accessdenied.png"
            runat="server" />
    </h1>
    <div>
        NO TIENE ACCESO A ESTA PAGINA<br />
        PARA OBTENER ACCESO DEBE LOGUEARSE<br />
        O DIRIGASE A UN ADMINISTRADOR DE RED</div>
</asp:Content>
