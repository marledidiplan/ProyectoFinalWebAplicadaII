﻿using BLL;
using Entidades;
using ProyectoFinalWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IniciarBtton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            RepositorioUsuario repositorio = new RepositorioUsuario();
            if (repositorio.Authentic(UserTextBox.Text, PassawordTextBox.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(user.NombreUsuario, true);

            }
            else
            {
                Util.ShowToastr(this.Page, "Usuario o contraseña incorrectos", "Error", "error");
            }
        }
    }
}