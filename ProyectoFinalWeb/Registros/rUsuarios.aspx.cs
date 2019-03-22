using BLL;
using Entidades;
using ProyectoFinalWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Util.ToInt(UsuarioIdTextbox.Text);
            usuario.Nombre = NombreTextbox.Text;
            usuario.Contrasena = ContrasenaTextBox.Text;
            usuario.ConfirmarContra = CcontrasenaTextBox.Text;
            usuario.FechaIngreso = Util.ToDate(FechaTextBox.Text);

            return usuario;
        }

        public void Clean()
        {
            UsuarioIdTextbox.Text = "0";
            NombreTextbox.Text = "";
            ContrasenaTextBox.Text = "";
            CcontrasenaTextBox.Text = "";


        }

        protected void NuevoBtton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        protected void GuardarBtton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Usuarios usuario = new Usuarios();
            RepositorioBase<Usuarios> repo = new RepositorioBase<Usuarios>();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }
            usuario = LlenaClase();
            if (UsuarioIdTextbox != null)
                paso = repo.Guardar(usuario);
            else
                paso = repo.Modificar(usuario);
            if (paso)
            {
                Util.ShowToastr(this.Page, " No se pudo Guardar", "Error", "Error");

                Clean();


            }
            else
            {
                Util.ShowToastr(this.Page, " Guardado con EXITO", "Guardado", "Success");
            }
        }

        protected void BuscarBtton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repo = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            usuario = repo.Buscar(Util.ToInt(UsuarioIdTextbox.Text));

            if (usuario != null)
            {
                NombreTextbox.Text = usuario.ToString();
                ContrasenaTextBox.Text = usuario.Contrasena.ToString();
                CcontrasenaTextBox.Text = usuario.ConfirmarContra.ToString();

                FechaTextBox.Text = usuario.FechaIngreso.ToString();
               

                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();
            }
        }

        protected void EliminarBtton_Click(object sender, EventArgs e)
        {
            int id = Util.ToInt(UsuarioIdTextbox.Text);
            RepositorioBase<Usuarios> repo = new RepositorioBase<Usuarios>();

            if (repo.Eliminar(id))
            {
                Util.ShowToastr(this.Page, " Eliminado con EXITO", "Eliminado", "Success");
                Clean();
            }
            else

                Util.ShowToastr(this.Page, " No se pudo eliminar", "Error", "Error");
        }
    }
}