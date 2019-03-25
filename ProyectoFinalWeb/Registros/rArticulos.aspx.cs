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
    public partial class rArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public Articulos LlenaClase()
        {
            Articulos articulo = new Articulos();
            articulo.ArticuloId = Util.ToInt(ArticuloIdTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                articulo.Fecha = date;
            articulo.Descripcion = DescripcionTextbox.Text;
            articulo.Costo = Util.ToInt(CostoTextBox.Text);
            articulo.Precio = Util.ToInt(PrecioTextBox.Text);
            articulo.Ganancia = Util.ToInt(GananciaTextBox.Text);
            return articulo;
        }
         private void Clean()
        {
            ArticuloIdTextBox.Text = "0";
            DescripcionTextbox.Text = string.Empty;
            CostoTextBox.Text = "0";
            PrecioTextBox.Text="0";
            GananciaTextBox.Text = "0";
        }
        public int CalcularGanancia(int costo, int precio)
        {
            int resultado;
            resultado = precio - costo;
            resultado = resultado / costo;
            resultado *= 100;
            return resultado;

        }

        protected void NuevoBtton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        protected void GuardarBtton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Articulos arti = new Articulos();
            RepositorioBase<Articulos> repo = new RepositorioBase<Articulos>();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }
            arti = LlenaClase();
            if (ArticuloIdTextBox != null)
                paso = repo.Guardar(arti);
            else
                paso = repo.Modificar(arti);
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
            int id = Util.ToInt(ArticuloIdTextBox.Text);
            RepositorioBase<Articulos> repo = new RepositorioBase<Articulos>();

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
            RepositorioBase<Articulos> repo = new RepositorioBase<Articulos>();
            Articulos arti = new Articulos();
            arti = repo.Buscar(Util.ToInt(ArticuloIdTextBox.Text));

            if (arti != null)
            {
                DescripcionTextbox.Text = arti.Descripcion;
                CostoTextBox.Text = arti.Costo.ToString();
                PrecioTextBox.Text = arti.Precio.ToString();
                GananciaTextBox.Text = arti.Ganancia.ToString();
                InventarioTextBox.Text = arti.Inventario.ToString();

                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();
            }
        }

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            int cos;
            bool resul = int.TryParse(CostoTextBox.Text, out cos);
            if (!resul)
                return;

            int pre;
            bool resu = int.TryParse(PrecioTextBox.Text, out pre);
            if (!resul)
                return;

            GananciaTextBox.Text =CalcularGanancia(cos, pre).ToString();
        }
    }
}