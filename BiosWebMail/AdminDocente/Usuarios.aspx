<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/SiteDocente.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="BiosWebMail.AdminDocente.Usuarios" %>
<%@ Register src="../UserControls/Usuario.ascx" tagname="Usuario" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Usuario ID="Usuario1" runat="server" />
</asp:Content>
