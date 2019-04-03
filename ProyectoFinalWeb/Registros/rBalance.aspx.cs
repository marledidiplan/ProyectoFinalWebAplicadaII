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
    public partial class rBalance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }
        }
         private Balance LlenaClase()
         {
            Balance balance = new Balance();
            balance.BalanceId = Util.ToInt(BalanceIdTextBox.Text);
            balance.Monto = Util.ToInt(MontoBalanceTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                balance.Fecha = date;

            return balance;
         }

        private void Clean()
        {
            BalanceIdTextBox.Text = "0";
            MontoBalanceTextBox.Text = "";
        }

        protected void NuevoBtton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        protected void GuardarBtton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Balance balance = new Balance();
            RepositorioBase<Balance> repo = new RepositorioBase<Balance>();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }

            balance = LlenaClase();
            if (Util.ToInt(BalanceIdTextBox.Text) == 0)
            {
                paso = repo.Guardar(balance);
                Util.ShowToastr(this.Page, "Guardado con EXITO", "Guardado", "Success");
                Clean();
            }
            else
            {
                paso = repo.Modificar(balance);
                Util.ShowToastr(this.Page, "Modificado con EXITO", "Guardado", "Success");
                Clean();
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Balance> repo = new RepositorioBase<Balance>();
            Balance balance = new Balance();
            balance = repo.Buscar(Util.ToInt(BalanceIdTextBox.Text));

            if (balance != null)
            {

                MontoBalanceTextBox.Text = balance.Monto.ToString();
                FechaTextBox.Text = balance.Fecha.ToString();

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
            int id = Util.ToInt(BalanceIdTextBox.Text);
            RepositorioBase<Balance> repo = new RepositorioBase<Balance>();

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