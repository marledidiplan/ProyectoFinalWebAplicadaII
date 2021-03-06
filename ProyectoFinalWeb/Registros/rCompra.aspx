﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCompra.aspx.cs" Inherits="ProyectoFinalWeb.Registros.rCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="form-row justify-content-center">
        <div class="col-sm-11">
            <div class=" align-content-center card">
                <div class="text-center">
                    <h1 style="font-size: xx-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Compra</ins></h1>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Imagen" runat="server" Height="209px" ImageAlign="left" ImageUrl="~\Resources\compra.png" Width="414px" />
                    <%-- Compra ID--%>
                    <div class="form-row">
                        &nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-0">
                                <asp:Label ID="Label2" runat="server" Text="Balance:" Font-Size="X-Large"></asp:Label>
                            </div>
                        <div class="form-group col-md-1">
                            <%--<asp:TextBox ID="BalanceTextBox" class="form-control" Text="0" type="number" Width="200" runat="server" ReadOnly="True"></asp:TextBox>--%>
                            <asp:DropDownList ID="BalanceDropDownList1" class="form-control input-sm" runat="server" Width="200" ReadOnly="true"></asp:DropDownList>

                        </div>
                    </div>
                    <br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <%--<article class="card-body">--%>
                    <div class="form-group">
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-0">
                                <asp:Label ID="Label1" runat="server" Text="Compra Id:"></asp:Label>
                            </div>
                            <div class="form-group col-md-1">
                                <asp:TextBox ID="CompraIdTextBox" class="form-control" Text="0" type="number" Width="100" runat="server"></asp:TextBox>
                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-sm-0">
                                <asp:Button ID="BuscarButton" ValidationGroup="Buscar" class="form-control btn btn-info btn-sm" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <div class="form-group col-md-1">
                                    <label for="FechaTextbox" runat="server">Fecha:</label>
                                </div>
                            &nbsp;&nbsp;
                            <div class="form-group col-sm-0">
                                <asp:TextBox ID="FechaTextBox" type="date" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                            </div>

                            <div class="form-gruop col-md-12">
                                <div class="col-md-8">
                                    <asp:RequiredFieldValidator ID="IdRFdValidator" ValidationGroup="Buscar" ControlToValidate="CompraIdTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <%--  Tipo de pago--%>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <div class="form-group colm-md-12">
                        <label for="Tipo" class="col-md-6 control-label input-sm">Tipo Pago</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="TipoDropDownList" class="form-control input-sm" runat="server" Width="250" OnSelectedIndexChanged="TipoDropDownList_SelectedIndexChanged">
                                <asp:ListItem>Contado</asp:ListItem>
                                <asp:ListItem>Credito</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%-- Usuario ID--%>
                    <div class="form-group colm-md-12">
                        <label for="Usuario" class="col-md-6 control-label input-sm">Usuario</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="UsuarioDropDownList" class="form-control input-sm" runat="server" Width="250"></asp:DropDownList>
                        </div>
                    </div>
                    <%--Suplidor --%>
                    <div class="form-group colm-md-12">
                        <label for="Suplidor" class="col-md-6 control-label input-sm">Suplidor</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="SuplidorsDropDownList" class="form-control input-sm" runat="server" Width="250"></asp:DropDownList>

                        </div>
                    </div>
                    <%--Articulo --%>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <div class="form-group colm-md-12">
                        <label for="Articulo" class="col-md-6 control-label input-sm">Articulo</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ArticuloDropDownList" class="form-control input-sm" runat="server" Width="250"></asp:DropDownList>
                        </div>
                    </div>
                    <%-- Cantidad--%>
                    <div class="form-gruop col-md-2">
                        <label for="CantidadTextbox" class="col-md-10 control-label input-sm">Cantidad:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="CantidadTextBox" runat="server" class="form-control input-sm" AutoPostBack="true" type="number" OnTextChanged="CantidadTextBox_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CantidadRFValidator" ValidationGroup="Guardar" ControlToValidate="CantidadTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="CantidadREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="CantidadTextBox"></asp:RegularExpressionValidator>
                            <br />
                        </div>
                    </div>
                    <%--Precio--%>
                    <div class="form-gruop col-md-2">
                        <label for="Precio" class="col-md-10 control-label input-sm">Precio:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="PrecioTextBox" runat="server" class="form-control input-sm" AutoPostBack="true" ReadOnly="True" OnTextChanged="PrecioTextBox_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <%--Importe--%>
                    <div class="form-gruop col-md-2">
                        <label for="Importe" class="col-md-10 control-label input-sm">Importe:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="ImporteTextBox" runat="server" class="form-control input-sm" AutoPostBack="true" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <%--Agregar--%>
                    <div class="form-gruop col-md-2">
                        <%--<label for="AgregarTextBox" class="col-md-10 control-label input-sm"></label>--%>
                        <div class="col-md-12">
                            <asp:Button ID="AgregarButton" ValidationGroup="Buscar" class="form-control btn btn-info btn-sm" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                        </div>
                    </div>
                    <%--Remover--%>
                    <%--<div class="form-gruop col-md-2">--%>
                    <%--<label for="Remover" class="col-md-10 control-label input-sm"></label>--%>
                    <%-- <div class=" form-gruop col-md-12">
                            <asp:Button ID="RemoverButton" ValidationGroup="Buscar" class="form-control btn btn-danger btn-sm" runat="server" Text="Remover" />
                        </div>
                    </div>--%>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:GridView ID="DetalleGridView" runat="server" class="table table-condensed table-bordered table-responsive" CellPadding="4" ForeColor="Black" GridLines="None" BackColor="White" OnRowCommand="DetalleGridView_RowCommand" OnPageIndexChanging="DetalleGridView_PageIndexChanging">
                         <AlternatingRowStyle BackColor="Silver" />
                         <Columns>
                             <asp:TemplateField ShowHeader="False" HeaderText="Opciones">
                                 <ItemTemplate>
                                     <asp:Button ID="Remover" runat="server" CausesValidation="false" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).DataItemIndex %>"
                                         Text="Remover" class="btn btn-danger btn-sm" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         <HeaderStyle BackColor="SkyBlue" Font-Bold="True" />
                     </asp:GridView>
                </div>
                <div class="col-md-12">
                    <div class="panel">
                        <%--Sub-Total--%>
                        <div class="form-gruop col-md-2">
                            <label for="SubTotal" class="col-md-10 control-label input-sm">Sub Total:</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="SubTotalTextBox" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <%--Itbis--%>
                        <div class="form-gruop col-md-2">
                            <label for="Itbis" class="col-md-10 control-label input-sm">Itbis:</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="ItbisTextBox" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <%--Total--%>
                        <div class="form-gruop col-md-2">
                            <label for="Total" class="col-md-10 control-label input-sm">Total:</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="TotalTextBox" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <%-- Efectivo--%>
                        <div class="form-gruop col-md-2">
                            <label for="EfectivoTextbox" class="col-md-10 control-label input-sm">Efectivo:</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="EfectivoTextBox" runat="server" class="form-control input-sm" type="number" OnTextChanged="EfectivoTextBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" ControlToValidate="EfectivoTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="EfectivoTextBox"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <%-- Devuelta--%>
                        <div class="form-gruop col-md-2">
                            <label for="DevueltaTextbox" class="col-md-10 control-label input-sm">Devuelta:</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="DevueltaTextbox" runat="server" class="form-control input-sm" type="number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Guardar" ControlToValidate="DevueltaTextbox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="DevueltaTextbox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>

                    </div>

                </div>
                <%--<Botones>--%>
                <div class="panel">
                    <div class="text-center">
                        <div class="form-group">
                            <asp:Button ID="NuevoBtton" runat="server" Text="Nuevo" class="btn btn-dark btn" OnClick="NuevoBtton_Click" />
                            <asp:Button ID="GuardarBtton" ValidationGroup="Guardar" runat="server" Text="Guardar" class="btn btn-success btn" OnClick="GuardarBtton_Click" />
                            <asp:Button ID="EliminarBtton" ValidationGroup="Buscar" runat="server" Text="Eliminar" class="btn btn-danger btn" OnClick="EliminarBtton_Click" />
                        </div>
                    </div>
                </div>

                <br />
            </div>
        </div>
    </div>

</asp:Content>
