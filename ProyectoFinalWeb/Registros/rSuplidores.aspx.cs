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
    public partial class rSuplidores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NuevoBtton_Click(object sender, EventArgs e)
        {
            Clean();  
        }
        private void Clean()
        {
            SuplidorIdTextBox.Text = "0";
            NombreTextbox.Text = "";
            DireccionTextBox.Text = "";
            CedulaTextBox.Text = "";
            TelefonoTextBox.Text = "";
            CuentaTextbox.Text = "";
            EmailTextBox.Text = "";
        }
        private Suplidores LlenaClase()
        {
            Suplidores suplidor = new Suplidores();

            suplidor.SuplidorId = Util.ToInt(SuplidorIdTextBox.Text);
            suplidor.Nombre = NombreTextbox.Text;
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                suplidor.FechaIngreso = date;
            suplidor.Direccion = DireccionTextBox.Text;
            suplidor.Cedula = CedulaTextBox.Text;
            suplidor.Telefono = TelefonoTextBox.Text;
            suplidor.Email = EmailTextBox.Text;

            return suplidor;

        }

        protected void GuardarBtton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Suplidores supli = new Suplidores();
            RepositorioBase<Suplidores> repo = new RepositorioBase<Suplidores>();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }
            supli = LlenaClase();
            if (SuplidorIdTextBox != null)
                paso = repo.Guardar(supli);
            else
                paso = repo.Modificar(supli);
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

        protected void EliminarBtton_Click(object sender, EventArgs e)
        {
            int id = Util.ToInt(SuplidorIdTextBox.Text);
            RepositorioBase<Suplidores> repo = new RepositorioBase<Suplidores>();

            if (repo.Eliminar(id))
            {
                Util.ShowToastr(this.Page, " Eliminado con EXITO", "Eliminado", "Success");
                Clean();
            }
            else

                Util.ShowToastr(this.Page, " No se pudo eliminar", "Error", "Error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Suplidores> repo = new RepositorioBase<Suplidores>();
            Suplidores suplidor = new Suplidores();
            suplidor = repo.Buscar(Util.ToInt(SuplidorIdTextBox.Text));

            if (suplidor != null)
            {

                NombreTextbox.Text = suplidor.Nombre;
                DireccionTextBox.Text = suplidor.Direccion;
                CedulaTextBox.Text = suplidor.Cedula;
                TelefonoTextBox.Text = suplidor.Telefono;
                EmailTextBox.Text = suplidor.Email;
                CuentaTextbox.Text = suplidor.CuentasPorPagar.ToString();

                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();
            }
        }
    }
}