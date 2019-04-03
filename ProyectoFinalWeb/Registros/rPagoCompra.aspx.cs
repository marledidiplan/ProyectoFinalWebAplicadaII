using BLL;
using Entidades;
using ProyectoFinalWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.Registros
{
    public partial class rPagoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                LlenaComboBox();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }


        }
        public PagoCompra LlenaClase()
        {
            PagoCompra pago = new PagoCompra();
            pago.PagoCompraId = Util.ToInt(PagoIdTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                pago.Fecha = date;
            pago.SuplidorId = Util.ToInt(SuplidorDropDownList.Text);
            pago.MontoPagar = Util.ToInt(PagoTextBox.Text);
            pago.Deuda = Util.ToInt(DeudaDropDownList.Text);

            return pago;
        }
        private void LlenaCampos(PagoCompra pagoCompra)
        {
            PagoTextBox.Text = pagoCompra.MontoPagar.ToString();
            DeudaDropDownList.Text = pagoCompra.Deuda.ToString();
            SuplidorDropDownList.SelectedValue = pagoCompra.SuplidorId.ToString();


        }
        private void LlenaComboBox()
        {
          
            RepositorioBase<Suplidores> sRepositorio = new RepositorioBase<Suplidores>();
            SuplidorDropDownList.DataSource = sRepositorio.GetList(u => true);
            SuplidorDropDownList.DataValueField = "SuplidorId";
            SuplidorDropDownList.DataTextField = "Nombre";
            SuplidorDropDownList.DataBind();

            RepositorioBase<PagoCompra> Repositorio = new RepositorioBase<PagoCompra>();
            DeudaDropDownList.DataSource = Repositorio.GetList(u => true);
            DeudaDropDownList.DataValueField = "PagoCompraId";
            DeudaDropDownList.DataTextField = "Deuda";
            DeudaDropDownList.DataBind();

            //CargarDeuda(Util.ToInt(DeudaTextBox.Text));
        }
        private void Clean()
        {
            PagoIdTextBox.Text = "0";
            PagoTextBox.Text = "";
            DeudaDropDownList.Text = "0";

        }

        //private void CargarDeuda()
        //{
        //    //RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
        //    //DeudatextBox.DataBindings.Clear();
        //    //var Suplidor = repositorio.GetList(s => true);
        //    //Binding binding = new Binding("Text", SuplidorDropDownList.DataSource, "CuentasPorPagar");
        //    //DeudaTextBox.DataBindings.Add(binding);

        //}
        public int CargarDeuda(int Id)
        {
            RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
            Suplidores supli = new Suplidores();
            supli = repositorio.Buscar(Id);

            int Deuda = supli.CuentasPorPagar;

            return Deuda;
        }


        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioPago repo = new RepositorioPago();
            PagoCompra pago = new PagoCompra();
            pago = repo.Buscar(Util.ToInt(PagoIdTextBox.Text));

            if (pago != null)
            {
                //Clean();
                LlenaCampos(pago);
                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();
            }
        }

        protected void NuevoBtton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        protected void GuardarBtton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            PagoCompra pago = new PagoCompra();
            RepositorioPago repo = new RepositorioPago();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }

            pago = LlenaClase();
            if (Util.ToInt(PagoIdTextBox.Text) == 0)
            {
                paso = repo.Guardar(pago);
                Util.ShowToastr(this.Page, "Guardado con EXITO", "Guardado", "Success");
                Clean();
            }
            else
            {
                paso = repo.Modificar(pago);
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

        protected void EliminarBtton_Click(object sender, EventArgs e)
        {
            int id = Util.ToInt(PagoIdTextBox.Text);
            RepositorioPago repo = new RepositorioPago();

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