<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="ProyectoFinalWeb.Consulta.cUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
       <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="text-center">
        <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;">Consulta Usuarios</h1>
    </div>
    <div class=" form-row justify-content-center">
        <%--Filtro--%>
        <div class="form-group col-md-3">
            <asp:Label ID="Filtro" runat="server" Text="Filtro"></asp:Label>
            <asp:DropDownList ID="FiltroDropDownList" Class="form-control" runat="server">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>UsuarioId</asp:ListItem>
                <asp:ListItem>Nombre</asp:ListItem>
                <asp:ListItem>Email</asp:ListItem>
                <asp:ListItem>Telefono</asp:ListItem>
                <asp:ListItem>Cedula</asp:ListItem>

            </asp:DropDownList>
        </div>
        <%--  Criterio--%>
        <div class="form-group col-md-3">
            <asp:Label for="CriterioTextBox" runat="server" Text="Criterio"></asp:Label>
            <asp:TextBox ID="CriterioTextBox" Class="form-control" runat="server"></asp:TextBox>
        </div>
        <%--  Boton--%>
        <div class="form-group col-md-1">
            <asp:Button ID="BuscarBotton" runat="server" Text="Buscar" class="btn btn-dark btn" OnClick="BuscarBotton_Click" />
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
        <asp:GridView ID="UsuariosGridView" runat="server" class="table table-condensed table-bordered table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="Gray" />
            <Columns>
                <asp:HyperLinkField ControlStyle-ForeColor="SteelBlue"
                    DataNavigateUrlFields="UsuarioId"
                    DataNavigateUrlFormatString="\Registros\rUsuarios.aspx?Id={0}"
                    Text="Editar">
                    <ControlStyle ForeColor="Brown"></ControlStyle>
                </asp:HyperLinkField>

            </Columns>
            <HeaderStyle BackColor="Window" Font-Bold="true" ForeColor="blue" />
            <RowStyle BackColor="PaleGreen" />
        </asp:GridView>
        <%--Boton Imprimir--%>
        <div class="form-group" style="display: inline-block">
            <button type="button" class="btn btn-info mt-4" data-toggle="modal" data-target=".bd-example-modal-lg">Imprimir</button>
        </div>
    </div>
     <%--Modal para el reporte--%>
            <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" style="max-width: 600px!important; min-width: 300px!important">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="ModalLabel">Reporte Usuarios</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <%--Viewer--%>
                            <rsweb:ReportViewer ID="UsuariosReportViewer" runat="server" ProcessingMode="Remote" Height="400px" Width="500px">
                                <ServerReport ReportPath="" ReportServerUrl="" />
                            </rsweb:ReportViewer>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                </div>
            </div>

</asp:Content>
