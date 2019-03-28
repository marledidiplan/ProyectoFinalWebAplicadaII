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
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Util.ToInt(UsuarioIdTextbox.Text);
            usuario.Nombre = NombreTextbox.Text;
            usuario.NombreUsuario = NombreUsuarioTextBox.Text;
            usuario.Contrasena = ContrasenaTextBox.Text;
            usuario.ConfirmarContra = CcontrasenaTextBox.Text;
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                usuario.FechaIngreso = date;

            return usuario;
        }

        public void Clean()
        {
            UsuarioIdTextbox.Text = "0";
            NombreTextbox.Text = "";
            NombreUsuarioTextBox.Text = "";
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
            Usuarios usu = new Usuarios();
            RepositorioBase<Usuarios> repo = new RepositorioBase<Usuarios>();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }

            usu = LlenaClase();
            if (Util.ToInt(UsuarioIdTextbox.Text) == 0)
            {
                paso = repo.Guardar(usu);
                Util.ShowToastr(this.Page, "Guardado con EXITO", "Guardado", "Success");
            }
            else
            {
                paso = repo.Modificar(usu);
                Util.ShowToastr(this.Page, "Modificado con EXITO", "Guardado", "Success");
            }

            if (paso)
            {
                Clean();
            }
            else
            {
                Util.ShowToastr(this.Page, "No se pudo Guardar", "Error", "Error");
            }
        }

        protected void BuscarBtton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repo = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            usuario = repo.Buscar(Util.ToInt(UsuarioIdTextbox.Text));

            if (usuario != null)
            {
                NombreTextbox.Text = usuario.Nombre;
                NombreUsuarioTextBox.Text = usuario.NombreUsuario.ToString();
                EmailTextBox.Text = usuario.Email;
                ContrasenaTextBox.Text = usuario.Contrasena.ToString();
                CcontrasenaTextBox.Text = usuario.ConfirmarContra.ToString();
                TelefonoTextBox.Text = usuario.Telefono;
                CedulaTextBox.Text = usuario.Cedula;

                FechaTextBox.Text = usuario.FechaIngreso.ToString("yyyy-MM-dd");
               

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