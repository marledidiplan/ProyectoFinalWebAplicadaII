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
            //RepositorioBalance repo = new RepositorioBalance();
            //int id = 1;
            //foreach (var item in RepositorioBalance.GetList(f => f.BalanceId == id))
            //{
            //    BalanceTextBox.Text = item.Monto.ToString();
            //}

            if (!Page.IsPostBack)
            {

                LlenaCombo();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

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
            compra.Efectivo = Util.ToInt(EfectivoTextBox.Text);
            compra.Devuelta = Util.ToInt(DevueltaTextbox.Text);
            compra.General = Util.ToInt(EfectivoTextBox.Text) - Util.ToInt(DevueltaTextbox.Text);
            compra.Detalles = (List<CompraDetalle>)ViewState["CompraDetalle"];

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
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();
        }
        protected void BindGrid()
        {
            DetalleGridView.DataSource = ((Compra)ViewState["Compra"]).Detalles;
            DetalleGridView.DataBind();
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
            EfectivoTextBox.Text = compra.Efectivo.ToString();
            DevueltaTextbox.Text = compra.Devuelta.ToString();
            

            ViewState["CompraDetalle"] = compra.Detalles;
            DetalleGridView.DataSource = (List<CompraDetalle>)ViewState["CompraDetalle"];
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
            //RepositorioBase<Compra> repositorio = new RepositorioBase<Compra>();
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
            if (compra.CompraId == 0)
            {
                paso = repo.Guardar(compra);
               
                Util.ShowToastr(this.Page, " Guardado con EXITO", "Guardado", "Success");
                Clean();
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
               
                LlenarCampos(cmp);
                LlenaCombo();
                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();
            }
        }

        private void EvaluarPrecio()
        {

            int id = Util.ToInt(ArticuloDropDownList.SelectedValue);
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            List<Articulos> arti = repositorio.GetList(c => c.ArticuloId == id);

            foreach (var item in arti)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }
        private void EvaluarDevuelta()
        {

            int efectivo;
            int total;
            //bool resul = int.TryParse(TotaltextBox.Text, out t);
            //if (!resul)
            //    return;


            //int ef;
            //bool result = int.TryParse(EfectivonumericUpDown.Value.ToString(), out ef);
            //if (!resul)
            //    return;

            efectivo = Util.ToInt(TotalTextBox.Text);
            total = Util.ToInt(EfectivoTextBox.Text);


            DevueltaTextbox.Text = CalcularDevuelta(efectivo, total).ToString();

        }


        private int CalcularImporte(int cantidad, int precio)
        {
            return cantidad * precio;
        }

        private int CalcularDevuelta(int efectivo, int total)
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

            if (TipoDropDownList.SelectedIndex == 0)
            {
                EfectivoTextBox.Enabled = true;
                DevueltaTextbox.Enabled = true;
            }
            else
            {
                DevueltaTextbox.Enabled = false;
                EfectivoTextBox.Enabled = false;

                DevueltaTextbox.Text = "0";
                EfectivoTextBox.Text = "0";
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Compra compra = new Compra();

                if (DetalleGridView.Rows.Count != 0)
                {
                    compra.Detalles = (List<CompraDetalle>)ViewState["CompraDetalle"];
                }

                int cantidad = Util.ToInt(CantidadTextBox.Text);
                int precio = Util.ToInt(PrecioTextBox.Text);
                int importe = Util.ToInt(ImporteTextBox.Text);
                int articulo = Util.ToInt(ArticuloDropDownList.SelectedValue);

                compra.Detalles.Add(new CompraDetalle(0, articulo, cantidad, precio, importe));
                //CalcularValores(compra.Detalles);
                int Total = 0;



                foreach (var item in compra.Detalles)
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

                ViewState["CompraDetalle"] = compra.Detalles;
                DetalleGridView.DataSource = ViewState["CompraDetalle"];
                DetalleGridView.DataBind();
            }
        }
    


        //protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        //{

        //}

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            EvaluarPrecio();
            EvaluarImporte();
        }
    }
}