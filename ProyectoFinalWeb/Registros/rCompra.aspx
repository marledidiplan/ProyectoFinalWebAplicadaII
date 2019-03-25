<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCompra.aspx.cs" Inherits="ProyectoFinalWeb.Registros.rCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="form-row justify-content-center">
        <div class="col-sm-8">
            <div class=" align-content-center card">
                <div class="text-center">
                    <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Compra</ins></h1>
                    <asp:Image ID="Imagen" runat="server" Height="150px" ImageAlign="Baseline" ImageUrl="~\Resources\compra.png" Width="227px" />
                </div>
                <article class="card-body">
                    <div class="form-group">
                        <%-- Compra ID--%>
                        <div class="form-gruop col-md-12">
                            <div class="col-md-8">
                                <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                                <asp:TextBox ID="CompraIdTextBox" class="form-control col-md-3" Text="0" type="number" runat="server"></asp:TextBox>
                                <asp:Button ID="BuscarButton" ValidationGroup="Buscar" class="form-control btn btn-info col-md-2 btn-sm" runat="server" Text="Buscar" />
                                <asp:RequiredFieldValidator ID="IdRFdValidator" ValidationGroup="Buscar" ControlToValidate="CompraIdTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%--Fecha--%>
                        <div class="form-gruop col-md-12">
                            <label for="FechaTextbox" class="col-md-3 control-label input-sm">Fecha:</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="FechaTextBox" type="date" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                      <%--  Tipo de pago--%>
                          <div class="form-group colm-md-12">
                            <label for="Tipo" class="col-md-3 control-label input-sm">Tipo Pago</label>
                            <div class="col-md-8">
                                <asp:DropDownList ID="TipoDropDownList" class="form-control input-sm" runat="server" Width="250">
                                        <asp:ListItem>Contado</asp:ListItem>
                                        <asp:ListItem>Credito</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%-- Usuario ID--%>
                        <div class="form-group colm-md-12">
                            <label for="Usuario" class="col-md-3 control-label input-sm">Usuario</label>
                            <div class="col-md-8">
                                <asp:DropDownList ID="UsuarioDropDownList" class="form-control input-sm" runat="server" Width="250"></asp:DropDownList>
                            </div>
                        </div>
                        <%--Suplidor --%>
                        <div class="form-group colm-md-12">
                            <label for="Suplidor" class="col-md-3 control-label input-sm">Suplidor</label>
                            <div class="col-md-8">
                                <asp:DropDownList ID="SuplidorsDropDownList" class="form-control input-sm" runat="server" Width="250"></asp:DropDownList>

                            </div>
                        </div>
                        <%--Articulo --%>
                        <div class="form-group colm-md-12">
                            <label for="Articulo" class="col-md-3 control-label input-sm">Articulo</label>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ArticuloDropDownList" class="form-control input-sm" runat="server" Width="250"></asp:DropDownList>
                            </div>
                        </div>
                        <%-- Cantidad--%>
                        <div class="form-gruop col-md-12">
                            <label for="CantidadTextbox" class="col-md-3 control-label input-sm">Cantidad:</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="CantidadTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CantidadRFValidator" ValidationGroup="Guardar" ControlToValidate="CantidadTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="CantidadREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="CantidadTextBox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%--Precio--%>
                        <div class="form-gruop col-md-12">
                            <label for="Precio" class="col-md-3 control-label input-sm">Precio:</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="PrecioTextBox" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <%--Importe--%>
                        <div class="form-gruop col-md-12">
                            <label for="Importe" class="col-md-3 control-label input-sm">Importe:</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="ImporteTextBox" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </article>
            </div>
        </div>
    </div>

</asp:Content>
