<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoFinalWeb.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="form-row justify-content-center">
        <div class="col-sm-9">
            <div class=" align-content-center card">
                <div class="text-center">
                    <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Registro de Usuarios</ins></h1>
                    <asp:Image ID="Imagen" runat="server" Height="150px" ImageAlign="Baseline" ImageUrl="~/Resources/icono-user.png" Width="227px" />
                </div>
                <article class="card-body">
                    <div class="form-group">
                        <%--<Usuario Id>--%>
                        <div class="form-gruop col-md-12">
                            <label for="Id" class="col-md-3 control-label input-sm">Usuario Id:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="UsuarioIdTextbox" runat="server" placeholder="0" class="form-control input-sm"></asp:TextBox>
                                <asp:Button ID="BuscarBtton" ValidationGroup="Buscar" runat="server" Text="Buscar" class="btn btn-info btn" OnClick="BuscarBtton_Click" />
                                <asp:RequiredFieldValidator ID="IdRFdValidator" ValidationGroup="Buscar" ControlToValidate="UsuarioIdTextbox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                        </div>
                        <%-- <Nombre>--%>
                        <div class="form-gruop col-md-12">
                            <label for="NombreTextbox" class="col-md-3 control-label input-sm">Nombre:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="NombreTextbox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NombreRFValidator" ValidationGroup="Guardar" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="NombreREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo letras" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ValidationGroup="Guardar" ControlToValidate="NombreTextBox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%-- <Contraseña>--%>
                        <div class="form-gruop col-md-12">
                            <label for="ContrasenaTextbox" class="col-md-3 control-label input-sm">Contraseña:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="ContrasenaTextBox" type="password" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="contraRFValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="ContrasenaTextBox" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="contraCompareValidator" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="CcontrasenaTextBox" ControlToValidate="ContrasenaTextBox" Display="Dynamic" ForeColor="DarkRed" SetFocusOnError="True"></asp:CompareValidator>
                                <br />
                            </div>
                        </div>
                        <%--<Confirmar Contraseña>--%>
                        <div class="form-gruop col-md-12">
                            <label for="CcontrasenaTextbox" class="col-md-3 control-label input-sm">Confirmar contraseña:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="CcontrasenaTextBox" type="password" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CorfimarRFValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="CcontrasenaTextbox" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ConfirmarCompareValidator" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="ContrasenaTextBox" ControlToValidate="CcontrasenaTextbox" Display="Dynamic" ForeColor="DarkRed" SetFocusOnError="True"></asp:CompareValidator>
                                <br />
                            </div>
                        </div>
                        <%--   <Fecha>--%>
                        <div class="form-gruop col-md-12">
                            <label for="FechaLabel" class="col-md-3 control-label input-sm">Fecha:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="FechaTextBox" type="date" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                                <br />
                            </div>
                        </div>
                        <%--<Botones>--%>
                        <div class="text-center">
                            <asp:Button ID="NuevoBtton" runat="server" Text="Nuevo" class="btn btn-dark btn" OnClick="NuevoBtton_Click" />
                            <asp:Button ID="GuardarBtton" runat="server" Text="Guardar" class="btn btn-success btn" OnClick="GuardarBtton_Click" />
                            <asp:Button ID="EliminarBtton" runat="server" Text="Eliminar" class="btn btn-danger btn" OnClick="EliminarBtton_Click" />
                        </div>
                    </div>
                </article>
            </div>
        </div>
    </div>
</asp:Content>
