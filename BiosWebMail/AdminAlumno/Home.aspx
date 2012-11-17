<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BiosWebMail._Home"
    MasterPageFile="~/Masters/SiteAlumno.Master" %>

<%@ Register Assembly="Controles" Namespace="Controles" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/ConsultaCarpeta.ascx" TagName="ConsultaCarpeta"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; margin: auto">
        <h1>
            <cc1:Header ID="Header" HEADER_TEXT="Home" IMAGE_URL="~/Images/home.png" runat="server" />
        </h1>
        <table style="width: 100%" cellpadding="5px" cellspacing="0px">
                <tr>
                    <td style="width: 30%">
                        <h2>
                            Carpetas</h2>
                        <asp:Repeater ID="FolderListRepeater" runat="server" 
                            OnItemCommand="FolderListRepeater_ItemCommand" 
                            onitemdatabound="FolderListRepeater_ItemDataBound">
                            <HeaderTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <th>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" ID="lblNombreCarpeta" Text="Nombre"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" ID="lblNoLeidos" Text="No leidos"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" ID="lblCantidadEmails" Text="Cantidad"></asp:Label>
                                        </th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:LinkButton runat="server" ID="lnkEliminar" Text="Eliminar" CommandArgument='<%# Eval("NUMERO_CARPETA") %>'
                                            CommandName="ELIMINAR"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="lnkNombreCarpeta" Text='<%# Eval("NOMBRE_CARPETA") %>'
                                            CommandArgument='<%# Eval("NUMERO_CARPETA") %>' CommandName="CONSULTAR"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <%# Eval("TOTAL_EMAILS_NOLEIDOS")%>
                                    </td>
                                    <td>
                                        <%# Eval("TOTAL_EMAILS")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNuevaCarpetaNombre"></asp:TextBox>&nbsp;
                                    <asp:Button runat="server" OnClick="btnNuevaCarpeta_Click" ID="btnNuevaCarpeta" Text="Crear Carpeta" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 70%">
                        <uc1:ConsultaCarpeta ID="ConsultaCarpeta" runat="server" />
                    </td>
                </tr>
        </table>
        <br />
        <asp:Label runat="server" ID="lblInfo"></asp:Label>
    </div>
</asp:Content>
