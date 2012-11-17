<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConsultaCarpeta.ascx.cs"
    Inherits="BiosWebMail.UserControls.ConsultaCarpeta" %>
<h2>
    <asp:Label runat="server" ID="lblFolderName"></asp:Label></h2>
<asp:Repeater ID="EmailListRepeater" runat="server" OnItemCommand="EmailListRepeater_ItemCommand"
    OnItemDataBound="EmailListRepeater_ItemDataBound">
    <HeaderTemplate>
        <table style="width: 100%">
            <tr>
                <th>
                </th>
                <th>
                    <asp:Label runat="server" ID="lblRemitente" Text="Remitente"></asp:Label>
                </th>
                <th>
                    <asp:Label runat="server" ID="lblDestinatario" Text="Destinatario"></asp:Label>
                </th>
                <th>
                    <asp:Label runat="server" ID="lblFecha" Text="Fecha"></asp:Label>
                </th>
                <th>
                    <asp:Label runat="server" ID="lblAsunto" Text="Asunto"></asp:Label>
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:LinkButton runat="server" ID="lnkButtonVer" Text="Ver" CommandArgument='<%# Eval("NUMERO_EMAIL") %>'
                    CommandName="VER"></asp:LinkButton>&nbsp;
                <asp:LinkButton runat="server" ID="lnkbuttonEliminar" Text="Eliminar" CommandArgument='<%# Eval("NUMERO_EMAIL") %>'
                    CommandName="ELIMINAR"></asp:LinkButton>
                <asp:Image runat="server" ID="imageState" Width="24px" Height="24px" />
            </td>
            <td>
                <asp:Label runat="server" ID="Label1" Text='<%# Eval("CARPETA_REMITENTE.USUARIO.NOMBRE") %>'></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="Label2" Text='<%# Eval("CARPETA_DESTINATARIO.USUARIO.NOMBRE") %>'></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblFecha" Text='<%# String.Format("{0:dd/MM/yyyy HH:mm}", Convert.ToDateTime(Eval("FECHA"))) %>'></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblAsunto" Text='<%# Eval("ASUNTO") %>'></asp:Label>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Label runat="server" ID="lblInfo"></asp:Label>
