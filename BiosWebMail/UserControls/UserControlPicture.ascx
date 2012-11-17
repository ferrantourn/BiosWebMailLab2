<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlPicture.ascx.cs" Inherits="BiosWebMail.UserControls.UserControlPicture" %>
<div style="width: 100%; text-align: center; height: auto;">
    <table style="width: 100%; height: 100px;" cellspacing="4" cellpadding="4">
        <tr>
            <td style="width: 100%; height: 100px;">
                <div style="width: 100%; height: 100px; text-align: center">
                    <asp:Image ID="imgUser" runat="server" Width="64px" Height="64px" ImageUrl="~/Images/userDefaultPicture.png" />
                    <asp:FileUpload ID="fu1"  runat="server" Height="24px" Width="350px" /><br />
                    &nbsp;<asp:Label ID="lblF1" runat="server"></asp:Label></div>
            </td>
        </tr>
    </table>
</div>
