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
    public partial class rCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioBalance repo = new RepositorioBalance();
            int id = 1;
            foreach (var item in RepositorioBalance.GetList(f => f.BalanceId == id))
            {
                BalanceTextBox.Text = item.Monto.ToString();
            }

            if (!Page.IsPostBack)
            {
                
                LlenaCombo();
            }
           
        }

        protected void NuevoBtton_Click(object sender, EventArgs e)
        {

            Clean();
        }

        private Compra LlenaClase(Compra compra)
        {
           
            compra.CompraId = Util.ToInt(CompraIdTextBox.Text);
            compra.BalanceId = 1;
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                compra.Fecha = date;
            compra.Total = Util.ToInt(TotalTextBox.Text.ToString());
            compra.SubTotal = Convert.ToInt32(SubTotalTextBox.Text.ToString());
            compra.Itbis = Convert.ToDecimal(ItbisTextBox.Text.ToString());
            compra.SuplidorId = Util.ToIntObject(SuplidorsDropDownList.SelectedValue);
            compra.UsuarioId = Convert.ToInt32(UsuarioDropDownList.SelectedValue);
            //compra.Efectivo = Convert.ToInt32(EfectivonumericUpDown.Value);
            //compra.Devuelta = Convert.ToInt32(DevueltanumericUpDown.Value);
            compra.Detalles = (List<CompraDetalle>)ViewState["ArticuloDetalles"];

            return compra;

        }

        private void Clean()
        {
            CompraIdTextBox.Text = "0";
            TotalTextBox.Text = string.Empty;
            SubTotalTextBox.Text = string.Empty;
            ItbisTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
            ViewState["CompraDetalle"] = new CompraDetalle();
        }

        private void LlenaCombo()
        {
            RepositorioBase<Usuarios> repoUsuario = new RepositorioBase<Usuarios>();
            UsuarioDropDownList.DataSource = repoUsuario.GetList(m => true);
            UsuarioDropDownList.DataValueField = "UsuarioId";
            UsuarioDropDownList.DataTextField = "Nombre";
            UsuarioDropDownList.DataBind();

            RepositorioBase<Suplidores> repoSuplidor = new RepositorioBase<Suplidores>();
            SuplidorsDropDownList.DataSource = repoSuplidor.GetList(m => true);
            SuplidorsDropDownList.DataValueField = "SuplidorId";
            SuplidorsDropDownList.DataTextField = "Nombre";
            SuplidorsDropDownList.DataBind();

            RepositorioBase<Articulos> repoArticulo = new RepositorioBase<Articulos>();
            ArticuloDropDownList.DataSource = repoArticulo.GetList(m => true);
            ArticuloDropDownList.DataValueField = "ArticuloId";
            ArticuloDropDownList.DataTextField = "Descripcion";
            ArticuloDropDownList.DataBind();



        }

        protected void LlenarCampos(Compra compra)
        {
            Clean();
            CompraIdTextBox.Text = compra.CompraId.ToString();
            UsuarioDropDownList.SelectedValue = compra.UsuarioId.ToString();
            SuplidorsDropDownList.SelectedValue = compra.SuplidorId.ToString();
            TotalTextBox.Text = compra.Total.ToString();
            SubTotalTextBox.Text = compra.SubTotal.ToString();
            ItbisTextBox.Text = compra.Itbis.ToString();

            Expression<Func<CompraDetalle, bool>> filtro = m => true;
            RepositorioBase<CompraDetalle> repositorioBase = new RepositorioBase<CompraDetalle>();
            int id = compra.CompraId;
            filtro = c => c.CompraId == id;
            DetalleGridView.DataSource = repositorioBase.GetList(filtro);
            DetalleGridView.DataBind();
        }

        protected void EliminarBtton_Click(object sender, EventArgs e)
        {
            int id = Util.ToInt(CompraIdTextBox.Text);
            RepositorioDetalle repo = new RepositorioDetalle();

            if (repo.Eliminar(id))
            {
                Util.ShowToastr(this.Page, " Eliminado con EXITO", "Eliminado", "Success");
                Clean();
            }
            else

                Util.ShowToastr(this.Page, " No se pudo eliminar", "Error", "Error");
        }

        protected void GuardarBtton_Click(object sender, EventArgs e)
        {
         
            bool paso = false;
            Compra compra = new Compra();
            Balance balance = new Balance();
            PagoCompra pago = new PagoCompra();
            RepositorioDetalle repo = new RepositorioDetalle();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }
            if (TipoDropDownList.SelectedIndex == 0)
            {
                balance.Monto -= compra.Total;

            }
            else
            {
                pago.Deuda += compra.Total;
            }

            compra = LlenaClase(compra);
            if (compra.CompraId ==0)
            {
                paso = repo.Guardar(compra);
                Util.ShowToastr(this.Page, " Guardado con EXITO", "Guardado", "Success");
            }
            else
            {
                paso = repo.Modificar(compra);
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioDetalle repo = new RepositorioDetalle();
            var cmp = repo.Buscar(Util.ToInt(CompraIdTextBox.Text));

            if (cmp != null)
            {
                //Clean();
                LlenarCampos(cmp);
                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();



            }
        }
        public void CalcularValores(IList<CompraDetalle> ArtiDetalles)
        {
            int Total = 0;



            foreach (var item in ArtiDetalles)
            {
                Total += item.Importe;
            }
            int SubTotal = 0;
            decimal Itbis = 0;
            Itbis = Total * Convert.ToDecimal(0.18);
            SubTotal = Convert.ToInt32(Total) - Convert.ToInt32(Itbis);
            SubTotalTextBox.Text = SubTotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
            DetalleGridView.DataSource = ArtiDetalles;

        }
        private void EvaluarPrecio()
        {

            int id = Util.ToInt(ArticuloDropDownList.SelectedValue);
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            List<Articulos> arti = repositorio.GetList(c => c.ArticuloId == id);
            //RepositorioBase<Articulos> repo = new RepositorioBase<Articulos>();
            //List<Articulos> articulos = repo.GetList(m => m.Descripcion == ArticuloDropDownList.Text);
            foreach (var item in arti)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }

        private int CalcularImporte(int cantidad, int precio)
        {
            return cantidad * precio;
        }

        private  int CalcularDevuelta(int efectivo, int total)
        {
            return efectivo - total;
        }
        private void EvaluarImporte()
        {
            RepositorioDetalle repo = new RepositorioDetalle();
            int cantidad;
            int precio;
            CompraDetalle compra = new CompraDetalle();

            cantidad = Util.ToInt(CantidadTextBox.Text);
            precio = Util.ToInt(PrecioTextBox.Text);
           
            ImporteTextBox.Text = CalcularImporte(cantidad, precio).ToString();
            //compra.Cantidad = cantidad;
            //compra.Precio = precio;

        }

        protected void TipoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (TipoDropDownList.SelectedIndex == 1)
            //{
            //   .Enabled = false;
            //    DevueltanumericUpDown.Enabled = false;
            //}
            //else
            //{
            //    EfectivonumericUpDown.Enabled = true;
            //    DevueltanumericUpDown.Enabled = true;
            //}
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                List<CompraDetalle> detalle = new List<CompraDetalle>();

                if (DetalleGridView.DataSource != null)
                {
                    detalle = (List<CompraDetalle>)DetalleGridView.DataSource;
                }
                else
                {
                    DateTime date = DateTime.Now.Date;
                    int cantidad = Util.ToInt(CantidadTextBox.Text);
                    int precio = Util.ToInt(PrecioTextBox.Text);
                    int importe = Util.ToInt(ImporteTextBox.Text);

                    CompraDetalle compraD = new CompraDetalle();
                    detalle.Add(new CompraDetalle(0, compraD.ArticuloId, cantidad, precio, importe));

                    ViewState["CompraDetalle"] = detalle;
                    DetalleGridView.DataSource = ViewState["CompraDetalle"];
                    DetalleGridView.DataBind();

                    CalcularValores(detalle);

                }
            }
        }

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            EvaluarPrecio();
            EvaluarImporte();
        }
    }
}