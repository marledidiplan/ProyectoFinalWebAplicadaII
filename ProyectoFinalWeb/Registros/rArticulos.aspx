<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rArticulos.aspx.cs" Inherits="ProyectoFinalWeb.Registros.rArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="form-row justify-content-center">
        <div class="col-sm-7">
            <div class=" align-content-center card">
                <div class="text-center">
                    <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Articulos</ins></h1>
                    <asp:Image ID="Imagen" runat="server" Height="150px" ImageAlign="Baseline" ImageUrl="~\Resources\icono-productos.jpg" Width="227px" />
                </div>
                <article class="card-body">
                    <div class="form-group">

                        <%-- <Articulo id>--%>
                        <div class="form-gruop col-md-12">
                            <div class="col-md-8">
                                <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                                <asp:TextBox ID="ArticuloIdTextBox" class="form-control col-md-3" Text="0" type="number" runat="server"></asp:TextBox>
                                <asp:Button ID="BuscarButton" ValidationGroup="Buscar" class="form-control btn btn-info col-md-2 btn-sm" runat="server" Text="Buscar" />
                                <asp:RequiredFieldValidator ID="IdRFdValidator" ValidationGroup="Buscar" ControlToValidate="ArticuloIdTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- <Fecha>--%>
                        <div class="form-gruop col-md-12">
                            <label for="FechaTextbox" class="col-md-3 control-label input-sm">Fecha:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="FechaTextBox" type="date" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                                <br />
                            </div>
                        </div>
                        <%--<Descripcion>--%>
                        <div class="form-gruop col-md-12">
                            <label for="DescripcionTextbox" class="col-md-3 control-label input-sm">Descripcion::</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="DescripcionTextbox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="DescripcionRFValidator" ValidationGroup="Guardar" ControlToValidate="DescripcionTextbox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                        </div>
                        <%--<Precio>--%>
                        <div class="form-gruop col-md-12">
                            <label for="PrecioTextbox" class="col-md-3 control-label input-sm">Precio:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="PrecioTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PrecioRFValidator" ValidationGroup="Guardar" ControlToValidate="PrecioTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="PrecioREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="PrecioTextBox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%--<Costo>--%>
                        <div class="form-gruop col-md-12">
                            <label for="CostoTextbox" class="col-md-3 control-label input-sm">Costo:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="CostoTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CostoRFValidator" ValidationGroup="Guardar" ControlToValidate="CostoTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="CostoREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="CostoTextBox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%--<Ganacia>--%>
                        <div class="form-gruop col-md-12">
                            <label for="GananciaTextbox" class="col-md-3 control-label input-sm">Ganancia:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="GananciaTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="GanaciaRFValidator" ValidationGroup="Guardar" ControlToValidate="GananciaTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="GananciaREValidator1" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="GananciaTextBox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%--<Inventario>--%>
                        <div class="form-gruop col-md-12">
                            <label for="InventarioTextbox" class="col-md-3 control-label input-sm">Inventario:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" ControlToValidate="" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate=""></asp:RegularExpressionValidator>--%>
                                <br />
                            </div>
                        </div>
                        <%--<Botones>--%>
                        <div class="panel">
                            <div class="text-center">
                                <div class="form-group">
                                    <asp:Button ID="NuevoBtton" runat="server" Text="Nuevo" class="btn btn-dark btn" />
                                    <asp:Button ID="GuardarBtton" ValidationGroup="Guardar" runat="server" Text="Guardar" class="btn btn-success btn" />
                                    <asp:Button ID="EliminarBtton" ValidationGroup="Eliminar" runat="server" Text="Eliminar" class="btn btn-danger btn" />
                                </div>
                            </div>
                        </div>
                    </div>
                </article>
            </div>
        </div>
    </div>
</asp:Content>
