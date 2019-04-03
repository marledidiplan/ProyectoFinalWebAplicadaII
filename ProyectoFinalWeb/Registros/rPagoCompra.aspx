<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPagoCompra.aspx.cs" Inherits="ProyectoFinalWeb.Registros.rPagoCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="form-row justify-content-center">
        <div class="col-sm-7">
            <div class=" align-content-center card">
                <div class="text-center">
                    <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Pago Compra</ins></h1>
                    <asp:Image ID="Imagen" runat="server" Height="150px" ImageAlign="Baseline" ImageUrl="~\Resources\pago.png" Width="227px" />
                </div>
                <article class="card-body">
                    <div class="form-group">
                        <%--Pago Id--%>
                        <div class="form-gruop col-md-12">
                            <div class="col-md-8">
                                <asp:Label ID="Label1" runat="server" Text="Pago ID:"></asp:Label>
                                <asp:TextBox ID="PagoIdTextBox" class="form-control col-md-3" Text="0" type="number" runat="server"></asp:TextBox>
                                <asp:Button ID="BuscarButton" ValidationGroup="Buscar" class="form-control btn btn-info col-md-2 btn-sm" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                <asp:RequiredFieldValidator ID="IdRFdValidator" ValidationGroup="Buscar" ControlToValidate="PagoIdTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="IdREValidator" runat="server" ErrorMessage="Solo Números" ControlToValidate="PagoIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
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
                        <%-- Suplidor id--%>
                        <div class="form-group colm-md-12">
                            <label for="Suplidor" class="col-md-3 input-sm">Suplidor</label>
                            <div class="col-md-8">
                                <asp:DropDownList ID="SuplidorDropDownList" runat="server" Width="250"></asp:DropDownList>
                                <br />
                            </div>
                        </div>
                        <%-- Deuda--%>
                        <div class="form-gruop col-md-12">
                            <asp:Label ID="Deuda" runat="server" Text="Deuda"></asp:Label>
                            <div class="col-md-8">
                               <asp:DropDownList ID="DeudaDropDownList" runat="server" Width="250" ></asp:DropDownList> 
                            </div>
                        </div>
                        <%--Pago--%>
                        <div class="form-gruop col-md-12">
                            <label for="Pago" class="col-md-3 control-label input-sm">Pago:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="PagoTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PagoRFValidator" ValidationGroup="Guardar" ControlToValidate="PagoTextbox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="PagoREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="PagoTextbox"></asp:RegularExpressionValidator>
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
