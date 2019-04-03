using BLL;
using Entidades;
using ProyectoFinalWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.Registros
{
    public partial class rArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }


        protected bool Valida(Articulos arti)
        {

            bool validar = false;
            Expression<Func<Articulos, bool>> filtar = m => true;
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            var ValiNombre = repositorio.GetList(d => true);
            foreach (var item in ValiNombre)
            {
                if (arti.Descripcion == item.Descripcion)
                {
                    Util.ShowToastr(this.Page, "El articulo ya existe", "Error", "error");
                    return validar = true;
                }
                
            }
            if(Util.ToInt(ArticuloIdTextBox.Text) > 0)
            {
                Util.ShowToastr(this.Page, "Debe estar en 0", "Error", "error");
                return validar = true;
            }
            return validar;
        }

        protected void GuardarBotton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Articulos arti = new Articulos();
            RepositorioBase<Articulos> repo = new RepositorioBase<Articulos>();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }

            arti = LlenaClase();
            if(Valida(arti))
            {
                return;
            }
            else
            {
                if (Util.ToInt(ArticuloIdTextBox.Text) == 0)
                {
                    paso = repo.Guardar(arti);
                    Util.ShowToastr(this.Page, "Guardado con EXITO", "Guardado", "Success");
                    Clean();
                }
                else
                {
                    paso = repo.Modificar(arti);
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
            CostoTextBox.Text = "";
            PrecioTextBox.Text = "";
            GananciaTextBox.Text = "";
            InventarioTextBox.Text = "0";
        }
        private int CalcularGanancia(int costo, int precio)
        {

            int resultado;
            resultado = precio - costo;
            resultado = resultado / costo;
            resultado *= 100;
            return resultado;

        }

        protected void NuevoBotton_Click(object sender, EventArgs e)
        {
            Clean();
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

        protected void EliminarBotton_Click(object sender, EventArgs e)
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

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            int cos = Util.ToInt(CostoTextBox.Text);

            int pre = Util.ToInt(PrecioTextBox.Text);
           

            GananciaTextBox.Text = CalcularGanancia(cos, pre).ToString();
        }

        protected void GananciaTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}