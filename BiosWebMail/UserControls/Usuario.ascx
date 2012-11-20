<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Usuario.ascx.cs" Inherits="BiosWebMail.UserControls.Usuario" %>
<%@ Register Src="~/UserControls/UserControlPicture.ascx" TagName="UserControlPicture"
    TagPrefix="uc1" %>
<table style="width: 100%; text-align: left" cellpadding="5px" cellspacing="0px">
    <tr>
        <td colspan="2" style="text-align: right">
            (*) Indica un campo requerido
        </td>
    </tr>
    <%--<tr>
        <td style="width: 30%">
            <asp:Label runat="server" ID="lblRegistrarme" Text="Registrarme como:"></asp:Label>
        </td>
        <td style="width: 70%">
            <asp:DropDownList runat="server" Width="250px" ID="ddlRegistroComo" AutoPostBack="true"
                OnSelectedIndexChanged="ddlRegistroComo_SelectedIndexChanged">
                <asp:ListItem Text="Alumno" Value="Alumno"> </asp:ListItem>
                <asp:ListItem Text="Docente" Value="Docente"> </asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>--%>
    <tr>
        <td style="width: 30%">
            Nombre *
        </td>
        <td style="width: 70%">
            <asp:TextBox runat="server" ValidationGroup="Grupo1" ID="txtNombre" Width="100%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="No te olvides del nombre..."
                Display="Dynamic" ValidationGroup="Grupo1" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Apellido *
        </td>
        <td style="width: 70%">
            <asp:TextBox runat="server" ValidationGroup="Grupo1" ID="txtApellido" Width="100%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" ErrorMessage="No te olvides del apellido..."
                Display="Dynamic" ValidationGroup="Grupo1" ControlToValidate="txtApellido"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Documento *
        </td>
        <td style="width: 70%">
            <asp:TextBox runat="server" ValidationGroup="Grupo1" ID="txtDocumento" Width="100%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDocumento" runat="server" ErrorMessage="No te olvides del documento..."
                Display="Dynamic" ValidationGroup="Grupo1" ControlToValidate="txtDocumento"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Usuario Sistema *
        </td>
        <td style="width: 70%">
            <asp:TextBox runat="server" ValidationGroup="Grupo1" ID="txtUserName" Width="100%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsuarioSistema" runat="server"
                ErrorMessage="No te olvides del nombre de usario del sistema..." Display="Dynamic"
                ValidationGroup="Grupo1" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Contraseña *
        </td>
        <td style="width: 70%">
            <asp:TextBox runat="server" ValidationGroup="Grupo1" ID="txtContraseña" Width="100%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="No te olvides de la contraseña..."
                Display="Dynamic" ValidationGroup="Grupo1" ControlToValidate="txtContraseña"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExpPassword" runat="server" ErrorMessage="La contraseña debe tener entre 6 y 10 caracteres, proba de nuevo."
                ControlToValidate="txtContraseña" ValidationExpression="^[a-zA-Z0-9'@&#)(!$%^='&*_.\s]{6,10}$"
                ValidationGroup="Grupo1" />
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            <asp:Label runat="server" ID="lblUserPicture" Text="Foto"></asp:Label>
        </td>
        <td style="width: 70%">
            <uc1:UserControlPicture ID="UCPicture" runat="server" />
        </td>
    </tr>
    <%--<tr>
        <td style="width: 30%">
            <asp:Label runat="server" Visible="false" ID="lblMaterias" Text="Materias"></asp:Label>
        </td>
        <td style="width: 70%">
            <asp:TextBox Visible="false" runat="server" ToolTip="Ingresa la lista de materias separadas por ','"
                ValidationGroup="Grupo1" ID="txtMateriasDesc" Width="100%"></asp:TextBox>
            <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidatorMaterias" runat="server"
                ErrorMessage="Te olvidas de las materias..." Display="Dynamic" ValidationGroup="Grupo1"
                ControlToValidate="txtMateriasDesc"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Visible="false" ValidationGroup="Grupo1" Display="Dynamic"
                ID="RegularExpressionValidatorMaterias" ValidationExpression="^([A-Za-z0-9]\s?)+([,]\s?([A-Za-z0-9]\s?)+)*$"
                ControlToValidate="txtMateriasDesc" runat="server" ErrorMessage="Ingresa las materias separadas por ','. Te doy otra chance..."></asp:RegularExpressionValidator>
        </td>
    </tr>--%>
    <tr>
        <td>
        </td>
        <td>
            <%--  <asp:Button runat="server" ID="btnCancelar" CausesValidation="false" PostBackUrl="~/index.aspx"
                Text="Cancelar" />&nbsp;--%><asp:Button runat="server" ID="btnRegistrar" Text="Registrar"
                    ValidationGroup="Grupo1" OnClick="btnRegistrar_Click" />&nbsp;<asp:Button runat="server"
                        ID="btnUpdate" Text="Actualizar" ValidationGroup="Grupo1" OnClick="btnUpdate_Click"
                        Visible="false" />
        </td>
    </tr>
</table>
<br />
<asp:Label runat="server" ID="lblInfo"></asp:Label>