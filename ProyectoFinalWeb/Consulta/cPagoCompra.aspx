<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cPagoCompra.aspx.cs" Inherits="ProyectoFinalWeb.Consulta.cPagoCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="text-center">
        <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;">Consulta Pago Compra</h1>
    </div>
    <div class=" form-row justify-content-center">
        <%--Filtro--%>
        <div class="form-group col-md-3">
            <asp:Label ID="Filtro" runat="server" Text="Filtro"></asp:Label>
            <asp:DropDownList ID="FiltroDropDownList" Class="form-control" runat="server">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>PagoCompraId</asp:ListItem>
                <asp:ListItem>SuplidorId</asp:ListItem>
                <asp:ListItem>Montopagar</asp:ListItem>
                <asp:ListItem>Deuda</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--  Criterio--%>
        <div class="form-group col-md-3">
            <asp:Label for="CriterioTextBox" runat="server" Text="Criterio"></asp:Label>
            <asp:TextBox ID="CriterioTextBox" Class="form-control" runat="server"></asp:TextBox>
        </div>
        <%--  Boton--%>
        <div class="form-group col-md-1">
            <asp:Button ID="BuscarBotton" runat="server" Text="Buscar" class="btn btn-dark btn" />
            <br />
        </div>
    </div>
    <div class=" form-row justify-content-center">
        <%-- Rango de fecha--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Desde" runat="server" />
            <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
        <div class="form-group col-md-3">
            <asp:Label Text="Hasta" runat="server" />
            <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>
    <div class=" form-row justify-content-center">
        <asp:GridView ID="PagoGridView" runat="server" class="table table-condensed table-bordered table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="Gray" />
            <Columns>
                <asp:HyperLinkField ControlStyle-ForeColor="SteelBlue"
                    DataNavigateUrlFields="PagoCompraId"
                    DataNavigateUrlFormatString="\Registros\rPagoCompra.aspx?Id={0}"
                    Text="Editar">
                    <ControlStyle ForeColor="Brown"></ControlStyle>
                </asp:HyperLinkField>

            </Columns>
            <HeaderStyle BackColor="Window" Font-Bold="true" ForeColor="blue" />
            <RowStyle BackColor="PaleGreen" />
        </asp:GridView>
    </div>




</asp:Content>
