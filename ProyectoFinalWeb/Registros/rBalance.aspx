<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rBalance.aspx.cs" Inherits="ProyectoFinalWeb.Registros.rBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="form-row justify-content-center">
        <div class="col-sm-6">
            <div class=" align-content-center card">
                <div class="text-center">
                    <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Balance</ins></h1>
                    <asp:Image ID="Imagen" runat="server" Height="150px" ImageAlign="Baseline" ImageUrl="~\Resources\cash_icon.png" Width="227px" />
                </div>
                <article class="card-body">
                    <div class="form-group">
                        <%--Balance Id--%>
                        <div class="form-gruop col-md-12">
                            <div class="col-md-8">
                                <asp:Label ID="Label1" runat="server" Text="Balance ID:"></asp:Label>
                                <asp:TextBox ID="BalanceIdTextBox" class="form-control col-md-3" Text="0" type="number" runat="server"></asp:TextBox>
                                <asp:Button ID="BuscarButton" ValidationGroup="Buscar" class="form-control btn btn-info col-md-2 btn-sm" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                <asp:RequiredFieldValidator ID="IdRFdValidator" ValidationGroup="Buscar" ControlToValidate="BalanceIdTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
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
                        <%--Monto--%>
                        <div class="form-gruop col-md-12">
                            <label for="Monto" class="col-md-3 control-label input-sm">Monto:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="MontoBalanceTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="MontoRFValidator" ValidationGroup="Guardar" ControlToValidate="MontoBalanceTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="MontoREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="MontoBalanceTextBox"></asp:RegularExpressionValidator>
                                <br />
                            </div>
                        </div>
                        <%--<Botones>--%>
                        <div class="panel">
                            <div class="text-center">
                                <div class="form-group">
                                    <asp:Button ID="NuevoBtton" runat="server" Text="Nuevo" class="btn btn-dark btn" OnClick="NuevoBtton_Click"/>
                                    <asp:Button ID="GuardarBtton" ValidationGroup="Guardar" runat="server" Text="Guardar" class="btn btn-success btn" OnClick="GuardarBtton_Click"  />
                                    <asp:Button ID="EliminarBtton" ValidationGroup="Eliminar" runat="server" Text="Eliminar" class="btn btn-danger btn" OnClick="EliminarBtton_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </article>
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
