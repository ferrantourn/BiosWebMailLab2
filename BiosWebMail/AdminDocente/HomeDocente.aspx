<%@ Page Title="Home Docente" Language="C#" MasterPageFile="~/Masters/SiteDocente.Master"
    AutoEventWireup="true" CodeBehind="HomeDocente.aspx.cs" Inherits="BiosWebMail.AdminDocente.HomeDocente" %>
<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <cc1:header id="Header" header_text="Home" image_url="~/Images/home.png"
            runat="server" />
    </h1>
</asp:Content>
