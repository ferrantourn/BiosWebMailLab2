﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarDocentes.aspx.cs"
    Inherits="BiosWebMail.ListarDocentes" MasterPageFile="~/Masters/SiteDocente.Master" %>

<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>
<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; margin: auto">
        <table style="width: 100%" cellpadding="5px" cellspacing="0px">
            <tr>
                <td colspan="2">
                    <h1>
                        <cc1:Header ID="Header" HEADER_TEXT="Docentes del sistema" IMAGE_URL="~/Images/ActivateAccount.png"
                            runat="server" />
                    </h1>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Repeater ID="UsersListRepeater" runat="server" 
                        onitemcommand="UsersListRepeater_ItemCommand" 
                        onitemdatabound="UsersListRepeater_ItemDataBound">
                        <HeaderTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <th>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblUsuario" Text="Usuario"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblNombre" Text="Nombre"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblApellido" Text="Apellido"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblDocumento" Text="Documento"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblMateriasHeader" Text="Materias"></asp:Label>
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton runat="server" ID="lnkButtonDesactivar" Text="Editar" CommandArgument='<%# Eval("NOMBRE_USUARIO") %>'
                                        CommandName="Editar"></asp:LinkButton>
                                </td>
                                <td>
                                    <%# Eval("NOMBRE_USUARIO") %>
                                </td>
                                <td>
                                    <%# Eval("NOMBRE") %>
                                </td>
                                <td>
                                    <%# Eval("APELLIDO") %>
                                </td>
                                <td>
                                    <%# Eval("CI") %>
                                </td>
                                <td>
                                 <asp:Label ID="lblMaterias" runat="server" ></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label runat="server" ID="lblInfo"></asp:Label>
    </div>
</asp:Content>
