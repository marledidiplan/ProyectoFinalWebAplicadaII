<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoFinalWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron " style="background-color:transparent">
        <h1 class="display-4" style="font-family: 'Moon'"  >Bienvenidos a L&M Comercial!
      <%--<asp:Image ID="Image1" runat="server" Height="200px" ImageAlign="Left" ImageUrl="~\Resources\carrito.png" Width="225px" />--%>
        </h1>
    </div>
     <asp:Label ID="Label2" runat="server" Text="Ingrese su nuevo Balance" Font-Bold="True" Font-Size="Large"></asp:Label>
    <asp:TextBox class="form-control col-md-2" ID="nuevobalanceTextBox" runat="server" ></asp:TextBox>
    <asp:Button class="form-control btn btn-dark col-md-2" ID="editarButton" runat="server" Text="Editar"/>
</asp:Content>
