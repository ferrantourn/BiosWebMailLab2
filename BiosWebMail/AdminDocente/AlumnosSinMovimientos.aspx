<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlumnosSinMovimientos.aspx.cs"
    Inherits="BiosWebMail.AlumnosSinMovimientos" MasterPageFile="~/Masters/SiteDocente.Master" %>

<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; margin: auto">
        <table style="width: 100%; text-align: left" cellpadding="5px" cellspacing="0px">
            <tr>
                <td colspan="2">
                    <h1>
                        <cc1:Header ID="Header" HEADER_TEXT="Alumnos sin movimientos" IMAGE_URL="~/Images/ActivateAccount.png"
                            runat="server" />
                    </h1>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    Lapso de dias sin movimientos
                </td>
                <td style="width: 70%">
                    <asp:TextBox runat="server" ID="txtNumDias" Width="50px"></asp:TextBox>&nbsp;<asp:Button
                        runat="server" ID="btnBuscar" Text="Buscar" />
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    Alumnos
                </td>
                <td style="width: 70%">
                    <asp:Repeater ID="UsersListRepeater" runat="server" OnItemCommand="UsersListRepeater_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <th>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblNombreAlumno" Text="Nombre Alumno"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblStatus" Text="Activo"></asp:Label>
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton runat="server" ID="lnkButtonDesactivar" Text="Desactivar" CommandArgument='<%# Eval("CI") %>'
                                        CommandName="DESACTIVAR"></asp:LinkButton>
                                </td>
                                <td>
                                    <%# Eval("NOMBRE_USUARIO") %>
                                </td>
                                <td>
                                    <%# Eval("ACTIVO").ToString().Trim() == "True" ? "Si" : "No" %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblInfo"></asp:Label>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnCancelar" PostBackUrl="~/AdminDocente/HomeDocente.aspx"
                        Text="Cancelar" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
