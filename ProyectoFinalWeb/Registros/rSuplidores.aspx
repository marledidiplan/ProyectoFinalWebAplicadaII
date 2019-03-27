<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rSuplidores.aspx.cs" Inherits="ProyectoFinalWeb.Registros.rSuplidores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="form-row justify-content-center">
        <div class="col-sm-7">
            <div class=" align-content-center card">
                <div class="text-center">
                    <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Suplidores</ins></h1>
                    <asp:Image ID="Imagen" runat="server" Height="150px" ImageAlign="Baseline" ImageUrl="~\Resources\Iconos-prove.png" Width="227px" />
                </div>
                <article class="card-body">
                    <div class="form-group">
                        <%--Suplidor Id--%>
                        <div class="form-gruop col-md-12">
                            <div class="col-md-8">
                                <asp:Label ID="Label1" runat="server" Text="Suplidor ID:"></asp:Label>
                                <asp:TextBox ID="SuplidorIdTextBox" class="form-control col-md-3" Text="0" type="number" runat="server"></asp:TextBox>
                                <asp:Button ID="BuscarButton" ValidationGroup="Buscar" class="form-control btn btn-info col-md-2 btn-sm" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                <asp:RequiredFieldValidator ID="IdRFdValidator" ValidationGroup="Buscar" ControlToValidate="SuplidorIdTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%--Nombre--%>
                        <div class="form-gruop col-md-12">
                            <label for="Nombre" class="col-md-3 control-label input-sm">Nombre:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="NombreTextbox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NombreRFValidator" ValidationGroup="Guardar" ControlToValidate="NombreTextbox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="NombreREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo letras" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ValidationGroup="Guardar" ControlToValidate="NombreTextbox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%-- Fecha--%>
                        <div class="form-gruop col-md-12">
                            <label for="FechaTextbox" class="col-md-3 control-label input-sm">Fecha:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="FechaTextBox" type="date" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                                <br />
                            </div>
                        </div>
                        <%-- Cedula--%>
                        <div class="form-gruop col-md-12">
                            <label for="Cedula" class="col-md-3 control-label input-sm">Cedula:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="CedulaTextBox" runat="server" placeholder="###-#######-#" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CedulaRFValidator" ValidationGroup="Guardar" ControlToValidate="CedulaTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="CedulaREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="CedulaTextBox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%--Direccion--%>
                        <div class="form-gruop col-md-12">
                            <label for="direccion" class="col-md-3 control-label input-sm">Direccion:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="DireccionTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" ControlToValidate="DireccionTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                        </div>
                        <%-- Telefono--%>
                        <div class="form-gruop col-md-12">
                            <label for="Telefono" class="col-md-3 control-label input-sm">Telefono:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="TelefonoTextBox" runat="server" placeholder="###-###-####" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="TelefonoRFValidator" ValidationGroup="Guardar" ControlToValidate="TelefonoTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="TelefonoREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="TelefonoTextBox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%--Email--%>
                        <div class="form-gruop col-md-12">
                            <label for="Email" class="col-md-3 control-label input-sm">Email:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="EmailTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRFValidator" ValidationGroup="Guardar" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                        </div>
                        <%--Cuentas por pagar--%>
                        <div class="form-gruop col-md-12">
                            <label for="Cuenta" class="col-md-3 control-label input-sm">Cuenta a Pagar:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="CuentaTextbox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PrecioRFValidator" ValidationGroup="Guardar" ControlToValidate="CuentaTextbox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="PrecioREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="CuentaTextbox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>

                        <%--<Botones>--%>
                        <div class="panel">
                            <div class="text-center">
                                <div class="form-group">
                                    <asp:Button ID="NuevoBtton" runat="server" Text="Nuevo" class="btn btn-dark btn" OnClick="NuevoBtton_Click" />
                                    <asp:Button ID="GuardarBtton" ValidationGroup="Guardar" runat="server" Text="Guardar" class="btn btn-success btn" OnClick="GuardarBtton_Click" />
                                    <asp:Button ID="EliminarBtton" ValidationGroup="Eliminar" runat="server" Text="Eliminar" class="btn btn-danger btn" OnClick="EliminarBtton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </article>
            </div>
        </div>
    </div>





</asp:Content>
