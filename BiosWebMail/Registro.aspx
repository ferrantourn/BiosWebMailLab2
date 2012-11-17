<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="Registro.aspx.cs" Inherits="BiosWebMail.Registro" %>

<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>
<%@ Register Src="UserControls/Usuario.ascx" TagName="Usuario" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <cc1:Header ID="Header" HEADER_TEXT="Registro" IMAGE_URL="~/Images/register.png"
            runat="server" />
    </h1>
    <uc1:Usuario ID="Usuario" runat="server" />
</asp:Content>
