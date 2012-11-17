<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="BiosWebMail.Email"
    MasterPageFile="~/Masters/SiteAlumno.Master" %>

<%@ MasterType VirtualPath="~/Masters/SiteAlumno.Master" %>
<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; margin: auto">
        <table style="width: 100%" cellpadding="5px" cellspacing="0px">
            <tr>
                <td colspan="2">
                    <h1>
                        <cc1:Header ID="Header" IMAGE_URL="~/Images/newemail.png" HEADER_TEXT="Nuevo Email"
                            runat="server" />
                    </h1>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    <asp:Label runat="server" ID="lblFrom" Text="De" Visible="false"></asp:Label>
                </td>
                <td style="width: 70%">
                    <asp:TextBox runat="server" ID="txtFrom" Visible="false" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    Para
                </td>
                <td style="width: 70%">
                    <asp:TextBox runat="server" ID="txtPara" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    Asunto
                </td>
                <td style="width: 70%">
                    <asp:TextBox runat="server" ID="txtAsunto" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    Contenido
                </td>
                <td style="width: 70%">
                    <asp:TextBox runat="server" ID="txtContenido" TextMode="MultiLine" Height="150px"
                        Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    <asp:Label runat="server" ID="lblMover" Text="Mover a"></asp:Label>
                </td>
                <td style="width: 70%">
                    <asp:DropDownList runat="server" Visible="false" AutoPostBack="true" DataTextField="NOMBRE_CARPETA"
                        DataValueField="NUMERO_CARPETA" AppendDataBoundItems="true" ID="ddlFolders" OnSelectedIndexChanged="ddlFolders_SelectedIndexChanged">
                        <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    &nbsp;
                </td>
                <td style="width: 70%">
                    <asp:Button runat="server" ID="btnCancelar" PostBackUrl="~/AdminAlumno/Home.aspx"
                        Text="Cancelar" />
                    &nbsp;<asp:Button runat="server" ID="btnAceptar" Text="Enviar" OnClick="btnAceptar_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblInfo"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
