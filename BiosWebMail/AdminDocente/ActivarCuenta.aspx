<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivarCuenta.aspx.cs"
    Inherits="BiosWebMail.ActivarCuenta" MasterPageFile="~/Masters/SiteDocente.Master" %>
<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>

<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; margin: auto">
        <table style="width: 100%" cellpadding="5px" cellspacing="0px">
            <tr>
                <td colspan="2">
                    <h1>
                        <cc1:Header ID="Header" HEADER_TEXT="Activar cuenta de alumno" IMAGE_URL="~/Images/ActivateAccount.png"
                            runat="server" />
                    </h1>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    Documento del alumno
                </td>
                <td style="width: 70%">
                    <asp:TextBox runat="server" ID="txtDocumento" Width="200px"></asp:TextBox>
                    <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <div id="PanelUsuario" runat="server" visible="false">
                        <table>
                            <tr>
                                <td>
                                    Nombre Completo
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblNombreAlumno"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Documento
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblDocumento"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Usuario
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblUserName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Status
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblStatus"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnActivar" Text="Activar" Visible="false" OnClick="btnActivar_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label runat="server" ID="lblInfo"></asp:Label>
    </div>
</asp:Content>
