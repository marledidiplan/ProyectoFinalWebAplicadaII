<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoFinalWeb.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div
        class="text-center">
        <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Registro de Usuarios</ins></h1>
    </div>

    <div class="panel-body">

        <div class="form-horizontal col-md-12" role="form">

            <div class="form-gruop col-md-12">
                <label for="Id" class="col-md-3 control-label input-sm">Usuario Id:</label>
                <div class="col-md-1 col-sm-2 col-xm-4">
                    <asp:TextBox ID="UsuarioIdTextbox" runat="server" placeholder="0"  class="form-control input-sm"></asp:TextBox>
                </div>
                
                <div class="col-md-1 col-sm-2 col-xm-4">
                    <asp:Button ID="BuscarBtton" runat="server" Text="Buscar" class="btn btn-info btn" OnClick="BuscarBtton_Click" />
                </div>
                <br />

                <br />
            </div>

            <div class="form-gruop col-md-12">
                <label for="NombreTextbox" class="col-md-3 control-label input-sm">Nombre:</label>
                <div class="col-md-8">
                    <asp:TextBox ID="NombreTextbox" runat="server" class="form-control input-sm"></asp:TextBox>
                    <br />
                </div>
            </div>
            <div class="form-gruop col-md-12">
                <label for="ContrasenaTextbox" class="col-md-3 control-label input-sm">Contraseña:</label>
                <div class="col-md-8">
                    <asp:TextBox ID="ContrasenaTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                    <br />
                </div>
            </div>
            <div class="form-gruop col-md-12">
                <label for="CcontrasenaTextbox" class="col-md-3 control-label input-sm">Confirmar contraseña:</label>
                <div class="col-md-8">
                    <asp:TextBox ID="CcontrasenaTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                    <br />
                </div>
            </div>
             <div class="form-gruop col-md-12">
                    <label for="FechaLabel" class="col-md-3 control-label input-sm">Fecha:</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="FechaTextBox" type="date" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                        <br />
                    </div>
                </div>
            <div class="text-center">
                <asp:Button ID="NuevoBtton" runat="server" Text="Nuevo" class="btn btn-info btn" OnClick="NuevoBtton_Click"  />
                <asp:Button ID="GuardarBtton" runat="server" Text="Guardar" class="btn btn-Warning btn" OnClick="GuardarBtton_Click" />
                <asp:Button ID="EliminarBtton" runat="server" Text="Eliminar" class="btn btn-success btn" OnClick="EliminarBtton_Click"  />
                
           
                </div>
            

        </div>
    </div>
</asp:Content>
